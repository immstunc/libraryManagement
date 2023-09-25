using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    internal class BorrowingBookRepository : IRepository<BorrowingBook>
    {
        private static List<BorrowingBook> _borrowBookList = new List<BorrowingBook>();
        private static int idCount = 0;
        public bool Add(BorrowingBook entity)
        {
            bool result = false;
            if (entity != null)
            {
                idCount++;
                entity.Id = idCount;
                _borrowBookList.Add(entity);
                result = !result;
            }
            return result;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BorrowingBook Get(int id)
        {
            var book = _borrowBookList.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                return book;
            }
            else
            {
                return null;
            }
        }


        public List<BorrowingBook> GetAll()
        {
            return _borrowBookList.Where(x => x.IsDelete == false).ToList();
        }

        public void Update(BorrowingBook entity)
        {
            var book = _borrowBookList.FirstOrDefault(x => x.Id == entity.Id);
            if (book != null)
            {
         
                book.IsStatus = entity.IsStatus;
            }
        }

        internal bool Add(Book book)
        {
            throw new NotImplementedException();
        }

        internal void Update(Book book1)
        {
            throw new NotImplementedException();
        }
    }
}
