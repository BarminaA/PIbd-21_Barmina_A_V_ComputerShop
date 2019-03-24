using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopServiceDAL.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public List<ItemPartViewModel> ItemParts { get; set; }
    }
}
