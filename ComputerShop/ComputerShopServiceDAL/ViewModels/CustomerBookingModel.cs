using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopServiceDAL.ViewModels
{
    public class CustomerBookingModel
    {
        public string CustomerName { get; set; }

        public string DateCreate { get; set; }

        public string ItemName { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public string Status { get; set; }
    }
}
