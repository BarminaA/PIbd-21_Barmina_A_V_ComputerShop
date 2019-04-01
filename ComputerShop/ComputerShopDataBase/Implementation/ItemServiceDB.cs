using ComputerShop;
using ComputerShopServiceDAL.BindingModels;
using ComputerShopServiceDAL.Interfaces;
using ComputerShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopDataBase.Implementation
{
    public class ItemServiceDB : IItemService
    {
        private ComputerDbContext context;

        public ItemServiceDB(ComputerDbContext context)
        {
            this.context = context;
        }
        public List<ItemViewModel> GetList()
        {
            List<ItemViewModel> result = context.Items.Select(rec => new
            ItemViewModel
            {
                Id = rec.Id,
                ItemName = rec.ItemName,
                Price = rec.Price,
                ItemParts = context.ItemParts
                    .Where(recPC => recPC.ItemId == rec.Id)
                    .Select(recPC => new ItemPartViewModel
                    {
                        Id = recPC.Id,
                        ItemId = recPC.ItemId,
                        PartId = recPC.PartId,
                        PartName = recPC.Part.PartName,
                        Count = recPC.Count
                    })
                    .ToList()
            })
            .ToList();
            return result;
        }
        public ItemViewModel GetElement(int id)
        {
            Item element = context.Items.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new ItemViewModel
                {
                    Id = element.Id,
                    ItemName = element.ItemName,
                    Price = element.Price,
                    ItemParts = context.ItemParts
                        .Where(recPC => recPC.ItemId == element.Id)
                        .Select(recPC => new ItemPartViewModel
                        {
                            Id = recPC.Id,
                            ItemId = recPC.ItemId,
                            PartId = recPC.PartId,
                            PartName = recPC.Part.PartName,
                            Count = recPC.Count
                        })
                        .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ItemBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Item element = context.Items.FirstOrDefault(rec =>
                    rec.ItemName == model.ItemName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть мороженое с таким названием");
                    }
                    element = new Item
                    {
                        ItemName = model.ItemName,
                        Price = model.Price
                    };
                    context.Items.Add(element);
                    context.SaveChanges();
                    // убираем дубли по ингредиентам
                    var groupParts = model.ItemParts
                                                .GroupBy(rec => rec.PartId)
                                                .Select(rec => new
                                                {
                                                    PartId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    // добавляем ингредиенты
                    foreach (var groupPart in groupParts)
                    {
                        context.ItemParts.Add(new ItemPart
                        {
                            ItemId = element.Id,
                            PartId = groupPart.PartId,
                            Count = groupPart.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void UpdElement(ItemBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Item element = context.Items.FirstOrDefault(rec =>
                    rec.ItemName == model.ItemName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть мороженое с таким названием");
                    }
                    element = context.Items.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.ItemName = model.ItemName;
                    element.Price = model.Price;
                    context.SaveChanges();
                    // обновляем существуюущие ингредиенты
                    var compIds = model.ItemParts.Select(rec =>
                    rec.PartId).Distinct();
                    var updateParts = context.ItemParts.Where(rec =>
                    rec.ItemId == model.Id && compIds.Contains(rec.PartId));
                    foreach (var updatePart in updateParts)
                    {
                        updatePart.Count =
                        model.ItemParts.FirstOrDefault(rec => rec.Id == updatePart.Id).Count;
                    }
                    context.SaveChanges();
                    context.ItemParts.RemoveRange(context.ItemParts.Where(rec =>
                    rec.ItemId == model.Id && !compIds.Contains(rec.PartId)));
                    context.SaveChanges();
                    // новые записи
                    var groupParts = model.ItemParts
                                                .Where(rec => rec.Id == 0)
                                                .GroupBy(rec => rec.PartId)
                                                .Select(rec => new
                                                {
                                                    PartId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupPart in groupParts)
                    {
                        ItemPart elementPC =
                        context.ItemParts.FirstOrDefault(rec => rec.ItemId == model.Id &&
                        rec.PartId == groupPart.PartId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupPart.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.ItemParts.Add(new ItemPart
                            {
                                ItemId = model.Id,
                                PartId = groupPart.PartId,
                                Count = groupPart.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Item element = context.Items.FirstOrDefault(rec => rec.Id ==
                    id);
                    if (element != null)
                    {
                        // удаяем записи по ингредиентам при удалении изделия
                        context.ItemParts.RemoveRange(context.ItemParts.Where(rec =>
                        rec.ItemId == id));
                        context.Items.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
