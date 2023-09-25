using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class Book:CommonProperty
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Page { get; set; }
    }
}
