using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop
{
    public class Storage
    {
        public int Id { get; set; }

        [Required]
        public string StorageName { get; set; }

        public virtual List<StoragePart> StorageParts { get; set; }
    }
}
