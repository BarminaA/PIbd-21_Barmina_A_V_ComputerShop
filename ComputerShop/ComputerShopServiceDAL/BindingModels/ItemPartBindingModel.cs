using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopServiceDAL.BindingModels
{
    public class ItemPartBindingModel
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public int PartId { get; set; }

        public string PartName { get; set; }

        public int Count { get; set; }
    }
}
