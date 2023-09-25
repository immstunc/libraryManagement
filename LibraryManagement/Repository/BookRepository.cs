using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    internal class BookRepository : IRepository<Book>
    {
        private static List<Book> _bookList = new List<Book>();
        private static int idCount = 0;
        public bool Add(Book entity)
        {
            bool result = false;
            if (entity != null)
            {
                idCount++;
                entity.Id = idCount;
                _bookList.Add(entity);
                result = !result;
            }
            return result;
        }

        public bool Delete(int id)
        {
            var book = _bookList.FirstOrDefault(x => x.Id == id);
            bool result = false;
            if (book != null)
            {
                book.IsDelete = true;
                result = !result;
            }
            return result;
        }

        public Book Get(int id)
        {
            var book = _bookList.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                return book;
            }
            else
            {
                return null;
            }
        }

        public List<Book> GetAll()
        {
            return _bookList.Where(x => x.IsDelete == false).ToList();
        }

        public void Update(Book entity)
        {
            var book = _bookList.FirstOrDefault(x => x.Id == entity.Id);
            if (book != null)
            {
                book.Name = String.IsNullOrWhiteSpace(entity.Name) ? book.Name : entity.Name;
                book.Author = String.IsNullOrWhiteSpace(entity.Author) ? book.Author : entity.Author;
                book.Description = entity.Description;
                book.Page = entity.Page >= 0 ? entity.Page : book.Page;
                book.IsStatus = entity.IsStatus;
            }
        }
    }
}
