using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    internal interface IProccessRepository
    {
        void Menu();
        void Add();
        void Delete();
        void Update();
        void Get();
        void GetAll();
    }
}
