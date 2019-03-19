using ComputerShopServiceDAL.BindingModels;
using ComputerShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopServiceDAL.Interfaces
{
    public interface IItemService
    {
        List<ItemViewModel> GetList();

        ItemViewModel GetElement(int id);

        void AddElement(ItemBindingModel model);

        void UpdElement(ItemBindingModel model);

        void DelElement(int id);
    }
}
