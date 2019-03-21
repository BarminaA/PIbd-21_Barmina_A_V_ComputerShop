using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopServiceDAL.ViewModels
{
   public  class StoragePartViewModel
    {
        public int Id { get; set; }

        public int StorageId { get; set; }

        public int PartId { get; set; }

        [DisplayName("Название компонента")]
        public string PartName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
