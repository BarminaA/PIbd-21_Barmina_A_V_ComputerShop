using ComputerShop;
using ComputerShopServiceDAL.BindingModels;
using ComputerShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopServiceDAL.Interfaces
{
   public interface IRecordService
    {
        void SaveItemPrice(RecordBindingModel model);

        List<StorageLoadViewModel> GetStorageLoad();

        void SaveStorageLoad(RecordBindingModel model);

        List<CustomerBookingModel> GetCustomerBooking(RecordBindingModel model);

        void SaveCustomerBooking(RecordBindingModel model);
    }
}
