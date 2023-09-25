using LibraryManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class BookProccess : IProccessRepository
    {
        BookRepository repository;
        public BookProccess()
        {
            repository = new BookRepository();
        }

        public void Add()
        {
            bool status = true;
            while (status)
            {
                Console.Clear();
                Book book = new Book();
                Console.WriteLine("-------------------------");
                Console.WriteLine("------- Book Add --------");
                Console.WriteLine("-------------------------");
                Console.Write("Name : ");
                book.Name = Console.ReadLine();
                Console.Write("Description : ");
                book.Description = Console.ReadLine();
                Console.Write("Author : ");
                book.Author = Console.ReadLine();
                Console.Write("Page : ");
                book.Page = Convert.ToInt32(Console.ReadLine());

                if (repository.Add(book))
                {
                    Console.WriteLine("Book Added Successful.");
                }
                else
                {
                    Console.WriteLine("Book Added Failed");
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
                Console.WriteLine("------ Book Delete ------");
                Console.WriteLine("-------------------------");
                Console.Write("Book Id : ");
                int id = Convert.ToInt32(Console.ReadLine());

                if (GetBook(id) != null)
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
                Console.WriteLine("------ Book Detail ------");
                Console.WriteLine("-------------------------");
                Console.Write("Book Id : ");
                int id = Convert.ToInt32(Console.ReadLine());

                GetBook(id);

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
            Console.WriteLine("------- Book List -------");
            Console.WriteLine("-------------------------");
            foreach (var book in repository.GetAll())
            {
                string status = book.IsStatus ? " Uygun" : " Uygun Değil";
                Console.WriteLine("\tId: " + book.Id +
                               "\tName: " + book.Name +
                               "\tDescription: " + book.Description +
                               "\tAuthor: " + book.Author +
                               "\tPage: " + book.Page+
                               "\tStatus: " + status
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
                Console.WriteLine("----- Book Proccess -----");
                Console.WriteLine("-------------------------");
                Console.WriteLine("---- Select Proccess ----");
                Console.WriteLine("Book Add    (1)");
                Console.WriteLine("Book Detail (2)");
                Console.WriteLine("Book Update (3)");
                Console.WriteLine("Book Delete (4)");
                Console.WriteLine("Book List   (5)");
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
                Console.WriteLine("------ Book Update ------");
                Console.WriteLine("-------------------------");
                Console.Write("Book Id : ");
                int id = Convert.ToInt32(Console.ReadLine());

                var book = GetBook(id);
                if (book != null)
                {

                    Console.WriteLine("----- Update Values -----");

                    Book book1 = new Book();
                    book1.Id = id;
                    Console.Write("Name    : ");
                    book1.Name = Console.ReadLine();
                    Console.Write("Description : ");
                    book1.Description = Console.ReadLine();
                    Console.Write("Author : ");
                    book1.Author = Console.ReadLine();
                    Console.Write("Page : ");
                    try
                    {
                        book1.Page = Convert.ToInt32(Console.ReadLine());

                    }
                    catch
                    {
                        book1.Page = book.Page;
                    }


                    Console.Write("Status - Uygun (U) Uygun Değil (D) : ");
                    char BookSetStatus = Convert.ToChar(Console.ReadLine());

                    book1.IsStatus = BookSetStatus == 'U' ? true : BookSetStatus == 'D' ? false : book1.IsStatus;

                    repository.Update(book1);

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
        public Book GetBook(int id)
        {
            var book = repository.Get(id);
            if (book != null)
            {
                Console.WriteLine("Name      : " + book.Name);
                Console.WriteLine("Description: " + book.Description);
                Console.WriteLine("Author     : " + book.Author );
                Console.WriteLine("Page       : " + book.Page );
                string BookStatus = book.IsStatus ? "Uygun" : "Uygun Değil";
                Console.WriteLine("Status : " + BookStatus);
            }
            else
            {
                Console.WriteLine("Not Found Book");
            }
            return book;
        }
    }
}
