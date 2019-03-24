using ComputerShop;
using ComputerShopServiceDAL.BindingModels;
using ComputerShopServiceDAL.Interfaces;
using ComputerShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerShopServiceImplement.Implementations
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;

        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<BookingViewModel> GetList()
        {
            List<BookingViewModel> result = source.Bookings.Select(rec => new BookingViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
                ItemId = rec.ItemId,
                DateCreate = rec.DateCreate.ToLongDateString(),
                DateImplement = rec.DateImplement?.ToLongDateString(),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                CustomerFIO = source.Customers.FirstOrDefault(recC => recC.Id == rec.CustomerId)?.CustomerFIO,
                ItemName = source.Items.FirstOrDefault(recP => recP.Id == rec.ItemId)?.ItemName,
            })
            .ToList();
            return result;
        }

        public void CreateBooking(BookingBindingModel model)
        {
            int maxId = source.Bookings.Count > 0 ? source.Bookings.Max(rec => rec.Id) : 0;
            source.Bookings.Add(new Booking
            {
                Id = maxId + 1,
                CustomerId = model.CustomerId,
                ItemId = model.ItemId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = BookingStatus.Принят
            });
        }

        public void TakeBookingInWork(BookingBindingModel model)
        {
            Booking element = source.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            // смотрим по количеству компонентов на складах
            var itemParts = source.ItemParts.Where(rec => rec.ItemId == element.ItemId);
            foreach (var itemPart in itemParts)
            {
                int countOnStorages = source.StorageParts
                    .Where(rec => rec.PartId == itemPart.PartId)
                    .Sum(rec => rec.Count);
                if (countOnStorages < itemPart.Count * element.Count)
                {
                    var PartName = source.Parts.FirstOrDefault(rec => rec.Id == itemPart.PartId);
                    throw new Exception("Не достаточно ингредиента " + PartName?.PartName + " требуется " + (itemPart.Count * element.Count) + ", в наличии " + countOnStorages);
                }
            }
            // списываем
            foreach (var itemPart in itemParts)
            {
                int countOnStorages = itemPart.Count * element.Count;
                var StorageParts = source.StorageParts.Where(rec => rec.PartId
                == itemPart.PartId);
                foreach (var StoragePart in StorageParts)
                {
                    // компонентов на одном складе может не хватать
                    if (StoragePart.Count >= countOnStorages)
                    {
                        StoragePart.Count -= countOnStorages;
                        break;
                    }
                    else
                    {
                        countOnStorages -= StoragePart.Count;
                        StoragePart.Count = 0;
                    }
                }
            }
            element.DateImplement = DateTime.Now;
            element.Status = BookingStatus.Готовится;
        }

        public void FinishBooking(BookingBindingModel model)
        {
            Booking element = source.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Готовится)
            {
                throw new Exception("Заказ не в статусе \"Готовится\"");
            }
            element.Status = BookingStatus.Готов;
        }

        public void PayBooking(BookingBindingModel model)
        {
            Booking element = source.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = BookingStatus.Оплачен;
        }

        public void PutPartOnStorage(StoragePartBindingModel model)
        {
            StoragePart element = source.StorageParts.FirstOrDefault(rec =>
            rec.StorageId == model.StorageId && rec.PartId == model.PartId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.StorageParts.Count > 0 ?
                source.StorageParts.Max(rec => rec.Id) : 0;
                source.StorageParts.Add(new StoragePart
                {
                    Id = ++maxId,
                    StorageId = model.StorageId,
                    PartId = model.PartId,
                    Count = model.Count
                });
            }
        }
    }
}
