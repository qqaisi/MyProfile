using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Shopping.Models
{
    public partial class StoresName
    {
        public StoresName()
        {
            StoreBranches = new HashSet<StoreBranch>();
        }
        [Key]
        public int StoreNameId { get; set; }
        public string StoreName { get; set; }

        public virtual ICollection<StoreBranch> StoreBranches { get; set; }
    }
}
