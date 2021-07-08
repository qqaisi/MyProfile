using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDbContext.Models;

namespace BusinessLayer
{
    public class User
    {

            private string _UserId;
            private string _UserPwd;
            private int _UserPK;
            private string _Ustreet;
            private string _Ucity;
            private string _Ustate;
            private string _Uzip;
            private string _Uemail;


            public string UserId
            {
                get
                {
                    return _UserId;
                }
                set
                {
                    if (value.Length < 20 && value.Length > 1)
                    {
                        _UserId = value;
                    }
                }
            }

            public int UserPK
            {
                get
                {
                    return _UserPK;
                }
                set
                {
                    if (value != 0)
                    {
                        _UserPK = value;
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


            public string Uemail
            {
                get
                {
                    return _Uemail;
                }
                set
                {
                    if (value.Length < 20 && value.Length > 1)
                    {
                        _Uemail = value;
                    }
                }
            }


            public LogingIn(string UserId, string UserPwd)
            {
                SHOPPING_DBContext context = new SHOPPING_DBContext();
                string TUserId = "";
                int TUserPK = 0;
                string TUserPWD = "";
                string answer = "Y";
                do
                {
                    Console.WriteLine("Please Enter your User Name :");
                    TUserId = Console.ReadLine();

                    Console.WriteLine("Please Enter your Password :");
                    TUserPWD = Console.ReadLine();
                    var DBUser = context.Users.Where(s => s.Userid.ToLower() == TUserId.ToLower() && s.UserPwd.ToLower() == TUserPWD.ToLower()).ToList();
                    if (DBUser.Count != 0)
                    {
                        this.UserId = TUserId;
                        this.UserPK = Convert.ToInt32(DBUser[0].UserPk);
                        this.Ustreet = DBUser[0].Ustreet;
                        this.Ucity = DBUser[0].Ucity;
                        this.Ustate = DBUser[0].Ustate;
                        this.Uzip = DBUser[0].Uzip;
                        this.Uemail = DBUser[0].Email;



                        TUserPK = this.UserPK;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Sorry Your Username Or Password Can not be matched ...Try again");
                        Console.WriteLine("If you dont have an account , would you like to register?(Y/N)");
                        answer = Console.ReadLine().ToLower();

                        if (answer == "y")
                        {
                            String UID = "";
                            String Ustreet1 = "";
                            String Ucity1 = "";
                            String Ustate1 = "";
                            String Uzip1 = "";
                            String Uemail1 = "";
                            string Upwd1 = "";
                            while (UID == "" && DBUser.Count() == 0)
                            {
                                Console.Clear();
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.Write("Enter Your Username : ", Console.ForegroundColor = ConsoleColor.White);
                                UID = Console.ReadLine();
                                DBUser = context.Users.Where(s => s.Userid.ToLower() == UID.ToLower()).ToList();
                                if (DBUser.Count() != 0)
                                {

                                    Console.WriteLine("The selected Username Has Been Used Please Try Different User Name");
                                    UID = "";
                                    DBUser.Clear();
                                    Console.ReadLine();
                                }
                            }

                            while (Ustreet1 == "")
                            {
                                Console.Clear();
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Username : {UID}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.Write("Enter Your Street : ", Console.ForegroundColor = ConsoleColor.White);

                                Ustreet1 = Console.ReadLine();
                            }

                            while (Ucity1 == "")
                            {
                                Console.Clear();
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Username : {UID}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Street : {Ustreet1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.Write("Enter Your City : ", Console.ForegroundColor = ConsoleColor.White);
                                Ucity1 = Console.ReadLine();
                            }


                            while (Ustate1 == "")
                            {
                                Console.Clear();
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Username : {UID}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Street : {Ustreet1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your City : {Ucity1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.Write("Enter Your State : ", Console.ForegroundColor = ConsoleColor.White);
                                Ustate1 = Console.ReadLine();
                            }

                            while (Uzip1 == "")
                            {
                                Console.Clear();
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Username : {UID}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Street : {Ustreet1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your City : {Ucity1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your State : {Ustate1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.Write("Enter Your Zip : ", Console.ForegroundColor = ConsoleColor.White);
                                Uzip1 = Console.ReadLine();
                            }


                            while (Uemail1 == "")
                            {
                                Console.Clear();
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Username : {UID}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Street : {Ustreet1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your City : {Ucity1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your State : {Ustate1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Zip : {Uzip1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.Write("Enter Your Email : ", Console.ForegroundColor = ConsoleColor.White);
                                Uemail1 = Console.ReadLine();
                            }

                            while (Upwd1 == "")
                            {
                                Console.Clear();
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Username : {UID}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Street : {Ustreet1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your City : {Ucity1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your State : {Ustate1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Zip : {Uzip1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Email : {Uemail1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.Write("Enter Your Password : ", Console.ForegroundColor = ConsoleColor.White);
                                Upwd1 = Console.ReadLine();

                            }


                            Console.WriteLine();
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("Press [ 1 ] to S.A.V.E     or    [ 0 ] to E.X.I.T);");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");


                            int Choice = 0;
                            while (!int.TryParse(Console.ReadLine(), out Choice) || !(Choice <= 1 && Choice >= 0))
                            {
                                Console.Clear();
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Username : {UID}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Street : {Ustreet1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your City : {Ucity1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your State : {Ustate1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Zip : {Uzip1}", Console.ForegroundColor = ConsoleColor.White);
                                Console.Write("[ X ]", Console.ForegroundColor = ConsoleColor.Red);
                                Console.WriteLine($"Enter Your Email : {Uemail}", Console.ForegroundColor = ConsoleColor.White);
                                Console.WriteLine();
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("Press [ 1 ] to S.A.V.E     or    [ 0 ] to E.X.I.T);");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

                            }


                            if (Choice == 0)
                            {
                            }
                            else
                            {
                            }



                        }
                    }
                } while (TUserPK == 0);
            }
        }
    }

