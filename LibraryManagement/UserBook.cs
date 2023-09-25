using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class UserBook:CommonProperty
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime LeaseDate { get; set; }= DateTime.Now;
        public DateTime? DeliveryDate { get; set; }
        public int LeaseDay { get; set; }   

    }
}
