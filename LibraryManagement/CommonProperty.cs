using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    abstract class CommonProperty
    {
        public int Id { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }=false;
    }
}
