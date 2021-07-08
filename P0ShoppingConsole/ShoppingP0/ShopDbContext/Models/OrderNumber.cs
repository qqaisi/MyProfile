using System;
using System.Collections.Generic;

#nullable disable

namespace ShopDbContext.Models
{
    public partial class OrderNumber
    {
        public OrderNumber()
        {
            Orders = new HashSet<Order>();
        }


        //public int OrderNo { get; set; }
        //public int? UserPk { get; set; }
        //public DateTime OrderDate { get; set; }
        //public int StoreBranchId { get; set; }
        private int _OrderNo;
        private int _UserPk;
        private DateTime _OrderDate;
        private int _StoreBranchId;


        public int StoreBranchId
        {
            get
            {
                return _StoreBranchId;
            }
            set
            {
                _StoreBranchId = value;

            }
        }

        public DateTime OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                _OrderDate = value;

            }
        }

        public int UserPk
        {
            get
            {
                return _UserPk;
            }
            set
            {
                _UserPk = value;

            }
        }

        public int OrderNo
        {
            get
            {
                return _OrderNo;
            }
            set
            {
                _OrderNo = value;

            }
        }




        public virtual StoreBranch StoreBranch { get; set; }
        public virtual User UserPkNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
