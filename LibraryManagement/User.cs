using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class User:CommonProperty
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Balance { get; set; } = 0;

    }
}
