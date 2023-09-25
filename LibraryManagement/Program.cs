using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UserProccess userProccess=new UserProccess();
            BookProccess bookProccess=new BookProccess();
            BorrowProccess borrowProccess=new BorrowProccess();
            bool status = true;

            while(status)
            {
               
           
                Console.WriteLine("Select Proccess Menu");
                Console.WriteLine("--------------------");
                Console.WriteLine("User Proccess  (1)");
                Console.WriteLine("Book Proccess  (2)");
                Console.WriteLine("Lend Book      (3)");
                Console.WriteLine("Program Exit   (4)");
                string select=Console.ReadLine();
                switch (select)
                {
                    case "1":
                        userProccess.Menu();
                        break;
                    case "2":
                        bookProccess.Menu(); 
                        break; 
                    case "3":
                        borrowProccess.Menu();
                        break;
                    case "4":
                        Console.Write("Program Kapatılıyor");
                        int time = 4000;
                        for (int i = 0; i < 10; i++)
                        {
                            Console.Write(".");
                            Console.Beep();
                            time /= 2;
                            Thread.Sleep(time);
                        }
                        status= false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
