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
    public class PartServiceDB: IPartService
    {
        private ComputerDbContext context;

        public PartServiceDB(ComputerDbContext context)
        {
            this.context = context;
        }
        public List<PartViewModel> GetList()
        {
            List<PartViewModel> result = context.Parts.Select(rec => new
            PartViewModel
            {
                Id = rec.Id,
                PartName = rec.PartName
            })
            .ToList();
            return result;
        }
        public PartViewModel GetElement(int id)
        {
            Part element = context.Parts.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new PartViewModel
                {
                    Id = element.Id,
                    PartName = element.PartName
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(PartBindingModel model)
        {
            Part element = context.Parts.FirstOrDefault(rec => rec.PartName ==
            model.PartName);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            context.Parts.Add(new Part
            {
                PartName = model.PartName
            });
            context.SaveChanges();
        }
        public void UpdElement(PartBindingModel model)
        {
            Part element = context.Parts.FirstOrDefault(rec => rec.PartName ==
            model.PartName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            element = context.Parts.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.PartName = model.PartName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Part element = context.Parts.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Parts.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
