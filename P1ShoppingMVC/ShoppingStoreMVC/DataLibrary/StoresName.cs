using System;
using System.Collections.Generic;

#nullable disable

namespace DataLibrary
{
    public partial class StoresName
    {
        public StoresName()
        {
            StoreBranches = new HashSet<StoreBranch>();
        }

        public int StoreNameId { get; set; }
        public string StoreName { get; set; }

        public virtual ICollection<StoreBranch> StoreBranches { get; set; }
    }
}
