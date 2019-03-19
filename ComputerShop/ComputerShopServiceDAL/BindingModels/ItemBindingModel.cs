using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopServiceDAL.BindingModels
{
    public class ItemBindingModel
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public List<ItemPartBindingModel> ItemParts { get; set; }
    }
}
