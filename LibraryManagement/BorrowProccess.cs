using LibraryManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManagement
{
    internal class BorrowProccess : IProccessRepository

    {
        BorrowingBookRepository repository;
        public BorrowProccess()
        {
            repository = new BorrowingBookRepository();
        }
        public void Add()
        {
            bool status = true;
            while (status)
            {
                Console.Clear();
                Book book = new Book();
                Console.WriteLine("-------------------------");
                Console.WriteLine("------- Book Lend --------");
                Console.WriteLine("-------------------------");
                Console.Write("Book ID : ");
                book.Id = Convert.ToInt32(Console.ReadLine());
                

                if (repository.Add(book))
                {
                    Console.WriteLine("Book Lended Successful.");
                }
                else
                {
                    Console.WriteLine("Book Lended Failed");
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
            throw new NotImplementedException();
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            Console.Clear();

            Console.WriteLine("-------------------------");
            Console.WriteLine("------- Borrow List -------");
            Console.WriteLine("-------------------------");
            foreach (var book in repository.GetAll())
            {
                string status = book.IsStatus ? " Uygun" : " Uygun Değil";
                Console.WriteLine("\tId: " + book.Id);
                             
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
                Console.WriteLine("-----Lend Proccess -----");
                Console.WriteLine("-------------------------");
                Console.WriteLine("---- Select Proccess ----");
                Console.WriteLine("Book Borrow    (1)");
                
                Console.WriteLine("User-Book List (2)");
                Console.WriteLine("Up Menu     (3)");
                Console.Write("Select: ");
                char select = Convert.ToChar(Console.ReadLine().Substring(0, 1));

                switch (select)
                {
                    case '1':
                        Add();
                        break;
                  
                    case '2':
                        GetAll();
                        break;
                    case '3':
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
            throw new NotImplementedException();
        }
    }
}
