using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Shopping.Models
{
    public partial class User
    {
        public User()
        {
            OrderNumbers = new HashSet<OrderNumber>();
        }
        public int UserPk { get; set; }
        [Required]
        public string Userid { get; set; }
        [Required]
        [DataType(dataType: DataType.Password)]
        public string User_Pwd { get; set; }
        [Required]
        [DataType(dataType: DataType.Password)]
        [Compare("User_Pwd",ErrorMessage ="The confirmed Password Does not Match the entered password")]
        public string ConfirmedUserPwd { get; set; }

        [Required]
        public string Ustreet { get; set; }
        [Required]
        public string Ucity { get; set; }
        [Required]
        public string Ustate { get; set; }
        [Required]
        public string Uzip { get; set; }
        [Required]
        [DataType(dataType:DataType.EmailAddress)]
        public string Email { get; set; }
        public int StoreBranchId { get; set; }

        public virtual StoreBranch StoreBranch { get; set; }
        public virtual ICollection<OrderNumber> OrderNumbers { get; set; }
    }
}
