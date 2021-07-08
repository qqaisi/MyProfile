using System;
using System.Collections.Generic;

#nullable disable

namespace ShopDbContext.Models
{
    public partial class User
    {
        public User()
        {
            OrderNumbers = new HashSet<OrderNumber>();
        }

        /* public int UserPk { get; set; }
         public string Userid { get; set; }
         public string UserPwd { get; set; }
         public string Ustreet { get; set; }
         public string Ucity { get; set; }
         public string Ustate { get; set; }
         public string Uzip { get; set; }
         public string Email { get; set; }*/

        //------------------------------------------------------
        private int _UserPk;
        private string _Userid;
        private string _UserPwd;

        private string _Ustreet;
        private string _Ucity;
        private string _Ustate;
        private string _Uzip;
        private string _Email;

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
        public string Userid
        {
            get
            {
                return _Userid;
            }
            set
            {
                if (value.Length < 20 && value.Length > 1)
                {
                    _Userid = value;
                }
            }
        }

        public string UserPwd
        {
            get
            {
                return _UserPwd;
            }
            set
            {
                if (value.Length < 20 && value.Length > 1)
                {
                    _UserPwd = value;
                }
            }
        }




        public string Ustreet
        {
            get
            {
                return _Ustreet;
            }
            set
            {
                if (value.Length < 20 && value.Length > 1)
                {
                    _Ustreet = value;
                }
            }
        }

        public string Ucity
        {
            get
            {
                return _Ucity;
            }
            set
            {
                if (value.Length < 20 && value.Length > 1)
                {
                    _Ucity = value;
                }
            }
        }

        public string Ustate
        {
            get
            {
                return _Ustate;
            }
            set
            {
                if (value.Length < 20 && value.Length > 1)
                {
                    _Ustate = value;
                }
            }
        }

        public string Uzip
        {
            get
            {
                return _Uzip;
            }
            set
            {
                if (value.Length < 20 && value.Length > 1)
                {
                    _Uzip = value;
                }
            }
        }


        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (value.Length < 20 && value.Length > 1)
                {
                    _Email = value;
                }
            }
        }













        //-----------------------------------------------------

        public virtual ICollection<OrderNumber> OrderNumbers { get; set; }
    }
}
