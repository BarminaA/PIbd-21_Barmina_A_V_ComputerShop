using ComputerShop;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopDataBase
{
    public class ComputerDbContext : DbContext
    {
        public ComputerDbContext() : base("ComputerDatabase")
        {
            //настройки конфигурации для entity      
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Part> Parts { get; set; }

        public virtual DbSet<Booking> Bookings { get; set; }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<ItemPart> ItemParts { get; set; }

        public virtual DbSet<Storage> Storages { get; set; }

        public virtual DbSet<StoragePart> StorageParts { get; set; }
    }
}