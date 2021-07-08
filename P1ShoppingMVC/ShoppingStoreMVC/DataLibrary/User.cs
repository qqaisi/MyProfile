using System;
using System.Collections.Generic;

#nullable disable

namespace DataLibrary
{
    public partial class User
    {
        public User()
        {
            OrderNumbers = new HashSet<OrderNumber>();
        }

        public int UserPk { get; set; }
        public string Userid { get; set; }
        public string User_Pwd { get; set; }
        public string Ustreet { get; set; }
        public string Ucity { get; set; }
        public string Ustate { get; set; }
        public string Uzip { get; set; }
        public string Email { get; set; }
        public int StoreBranchId { get; set; }

        public virtual StoreBranch StoreBranch { get; set; }
        public virtual ICollection<OrderNumber> OrderNumbers { get; set; }
    }
}
