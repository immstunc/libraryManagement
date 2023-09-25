using LibraryManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class UserProccess : IProccessRepository
    {
        UserRepository repository;
        public UserProccess()
        {
            repository = new UserRepository();
        }

        public void Add()
        {
            bool status = true;
            while (status)
            {
                Console.Clear();
                User user = new User();
                Console.WriteLine("-------------------------");
                Console.WriteLine("------- User Add --------");
                Console.WriteLine("-------------------------");
                Console.Write("Name : ");
                user.Name = Console.ReadLine();
                Console.Write("Surname : ");
                user.Surname = Console.ReadLine();
                Console.Write("Balance : ");
                user.Balance = Convert.ToDouble(Console.ReadLine());

                if (repository.Add(user))
                {
                    Console.WriteLine("User Added Successful.");
                }
                else
                {
                    Console.WriteLine("User Added Failed");
                }
                while (true)
                {
                    Console.WriteLine("Devam Etmek İstersen Evet(E) Hayır(H)");
                    string devam = Console.ReadLine();
                    devam = devam.ToUpper();
                    if (devam == "E")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (devam == "H")
                    {
                        Console.Clear();
                        status = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Tanımsız İşlem. Tekrar Deneyiniz");
                    }


                }

            }

        }

        public void Delete()
        {
            bool status = true;
            while (status)
            {
                Console.Clear();

                Console.WriteLine("-------------------------");
                Console.WriteLine("------ User Delete ------");
                Console.WriteLine("-------------------------");
                Console.Write("User Id : ");
                int id = Convert.ToInt32(Console.ReadLine());

                if (GetUser(id)!=null)
                {
                    Console.WriteLine("\nKullanıcı Silinsin mi? Evet (E) Hayır (H)");
                    string sil = Console.ReadLine().Substring(0, 1).ToUpper();
                    if (sil == "E")
                    {
                        if (repository.Delete(id))
                        {
                            Console.WriteLine("Kullanıcı Silme Başarılı");
                        }
                        else
                        {
                            Console.WriteLine("Silme İşlmei Başarısız");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Silme İşlemi İptal Edildi");
                    }
                };


                while (true)
                {
                    Console.WriteLine("Devam Etmek İstersen Evet(E) Hayır(H)");
                    string devam = Console.ReadLine();
                    devam = devam.ToUpper();
                    if (devam == "E")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (devam == "H")
                    {
                        Console.Clear();
                        status = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Tanımsız İşlem. Tekrar Deneyiniz");
                    }


                }
            }
        }

        public void Get()
        {
            bool status = true;
            while (status)
            {
                Console.Clear();

                Console.WriteLine("-------------------------");
                Console.WriteLine("------ User Detail ------");
                Console.WriteLine("-------------------------");
                Console.Write("User Id : ");
                int id = Convert.ToInt32(Console.ReadLine());

                GetUser(id);

                while (true)
                {
                    Console.WriteLine("Devam Etmek İstersen Evet(E) Hayır(H)");
                    string devam = Console.ReadLine();
                    devam = devam.ToUpper();
                    if (devam == "E")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (devam == "H")
                    {
                        Console.Clear();
                        status = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Tanımsız İşlem. Tekrar Deneyiniz");
                    }


                }
            }

        }

        public void GetAll()
        {
            Console.Clear();

            Console.WriteLine("-------------------------");
            Console.WriteLine("------- User List -------");
            Console.WriteLine("-------------------------");
            foreach (var user in repository.GetAll())
            {
                string status = user.IsStatus ? " Active" : " Passive";
                Console.WriteLine("\tId: "+user.Id+
                               "\t\tName: " + user.Name+
                               "\t\tSurname: " + user.Surname+
                               "\tBalance: "+user.Balance +" TL"+
                               "\tStatus: "+status
                               );
                Console.WriteLine("\t-------------------------");

            }
            Console.ReadKey();
        }

        public void Menu()
        {
            bool status = true;
            while (status)
            {
                Console.Clear();
                Console.WriteLine("----- User Proccess -----");
                Console.WriteLine("-------------------------");
                Console.WriteLine("---- Select Proccess ----");
                Console.WriteLine("User Add    (1)");
                Console.WriteLine("User Detail (2)");
                Console.WriteLine("User Update (3)");
                Console.WriteLine("User Delete (4)");
                Console.WriteLine("User List   (5)");
                Console.WriteLine("Up Menu     (6)");
                Console.Write("Select: ");
                char select = Convert.ToChar(Console.ReadLine().Substring(0, 1));

                switch (select)
                {
                    case '1':
                        Add();
                        break;
                    case '2':
                        Get();
                        break;
                    case '3':
                        Update();
                        break;
                    case '4':
                        Delete();
                        break;
                    case '5':
                        GetAll();
                        break;
                    case '6':
                        Console.Clear();
                        status = false;
                        break;
                    default:
                        Console.WriteLine("Tanımsız Değer Girildi.\nTekrar Deneyiniz.");
                        break;
                }
            }


        }

        public void Update()
        {
            bool status = true;
            while (status)
            {
                Console.Clear();

                Console.WriteLine("-------------------------");
                Console.WriteLine("------ User Update ------");
                Console.WriteLine("-------------------------");
                Console.Write("User Id : ");
                int id = Convert.ToInt32(Console.ReadLine());

                var user=GetUser(id);
                if (user != null)
                {
                    
                    Console.WriteLine("----- Update Values -----");

                    User user1=new User();
                    user1.Id = id;
                    Console.Write("Name    : ");
                    user1.Name = Console.ReadLine();
                    Console.Write("Surname : ");
                    user1.Surname = Console.ReadLine();
                    Console.Write("Balance : ");
                    try
                    {
                        user1.Balance = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        user1.Balance = user.Balance;
                    }
                    Console.Write("Status - Active (A) Passive (P) : ");
                    char userSetStatus = Convert.ToChar(Console.ReadLine());

                    user1.IsStatus=userSetStatus=='A'?true: userSetStatus == 'P' ?false:user1.IsStatus;

                    repository.Update(user1);

                    Console.WriteLine("Düzenleme Başarılı.");
                }
                

                while (true)
                {
                    Console.WriteLine("Devam Etmek İstersen Evet(E) Hayır(H)");
                    string devam = Console.ReadLine();
                    devam = devam.ToUpper();
                    if (devam == "E")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (devam == "H")
                    {
                        Console.Clear();
                        status = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Tanımsız İşlem. Tekrar Deneyiniz");
                    }


                }
            }
        }
        public User GetUser(int id)
        {
            var user = repository.Get(id);
            if (user != null)
            {
                Console.WriteLine("Name   : " + user.Name);
                Console.WriteLine("Surname: " + user.Surname);
                Console.WriteLine("Balance: " + user.Balance + " TL");
                string userStatus = user.IsStatus ? "Active" : "Passive";
                Console.WriteLine("Status : " + userStatus);
            }
            else
            {
                Console.WriteLine("Not Found User");
            }
            return user;
        }
    }
}
