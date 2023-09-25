using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    internal interface IRepository<T>
    {
        T Get(int id);
        bool Add(T entity);
        void Update(T entity);
        bool Delete(int id);
        List<T> GetAll();
    }
}
