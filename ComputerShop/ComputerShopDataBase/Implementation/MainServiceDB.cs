using ComputerShop;
using ComputerShopServiceDAL.BindingModels;
using ComputerShopServiceDAL.Interfaces;
using ComputerShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopDataBase.Implementation
{
    public class MainServiceDB : IMainService
    {
        private ComputerDbContext context;

        public MainServiceDB(ComputerDbContext context)
        {
            this.context = context;
        }
        public List<BookingViewModel> GetList()
        {
            List<BookingViewModel> result = context.Bookings.Select(rec => new BookingViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
               ItemId = rec.ItemId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
                             SqlFunctions.DateName("mm", rec.DateCreate) + " " +
                            SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
                            SqlFunctions.DateName("dd",
            rec.DateImplement.Value) + " " +
                            SqlFunctions.DateName("mm",
            rec.DateImplement.Value) + " " +
                            SqlFunctions.DateName("yyyy",
            rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                CustomerFIO = rec.Customer.CustomerFIO,
               ItemName = rec.Item.ItemName
            })
            .ToList();
            return result;
        }
        public void CreateBooking(BookingBindingModel model)
        {
            context.Bookings.Add(new Booking
            {
                CustomerId = model.CustomerId,
               ItemId = model.ItemId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = BookingStatus.Принят
            });
            context.SaveChanges();
        }
        public void TakeBookingInWork(BookingBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Booking element = context.Bookings.FirstOrDefault(rec => rec.Id ==
                    model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != BookingStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var itemParts = context.ItemParts.Include(rec => rec.Part).Where(rec => rec.ItemId == element.ItemId);
                    // списываем
                    foreach (var itemPart in itemParts)
                    {
                        int countOnStorages = itemPart.Count * element.Count;
                        var stockParts = context.StorageParts.Where(rec =>
                        rec.PartId == itemPart.PartId);
                        foreach (var stockPart in stockParts)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (stockPart.Count >= countOnStorages)
                            {
                                stockPart.Count -= countOnStorages;
                                countOnStorages = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStorages -= stockPart.Count;
                                stockPart.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnStorages > 0)
                        {
                            throw new Exception("Не достаточно ингредиента" + itemPart.Part.PartName + " требуется " + itemPart.Count + ", не хватает " + countOnStorages);
                        }
                    }
                    element.DateImplement = DateTime.Now;
                    element.Status = BookingStatus.Готовится;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void FinishBooking(BookingBindingModel model)
        {
            Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Готовится)
            {
                throw new Exception("Заказ не в статусе \"Готовится\"");
            }
            element.Status = BookingStatus.Готов;
            context.SaveChanges();
        }
        public void PayBooking(BookingBindingModel model)
        {
            Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = BookingStatus.Оплачен;
            context.SaveChanges();
        }
        public void PutPartOnStorage(StoragePartBindingModel model)
        {
            StoragePart element = context.StorageParts.FirstOrDefault(rec =>
            rec.StorageId == model.StorageId && rec.PartId == model.PartId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.StorageParts.Add(new StoragePart
                {
                    StorageId = model.StorageId,
                    PartId = model.PartId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}
