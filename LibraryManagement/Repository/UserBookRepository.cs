using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    internal class UserBookRepository : IRepository<UserBook>
    {
        private static List<UserBook> _userBookList = new List<UserBook>();
        public bool Add(UserBook entity)
        {
            bool result = false;
            if (entity != null)
            {
                entity.IsStatus = true;
                _userBookList.Add(entity);
                result = !result;
            }
            return result;
        }

        public bool Delete(int id)//veriler gerekli olduğundan silme işlemi yapılmayacak
        {
            throw new NotImplementedException();
        }

        public UserBook Get(int id)
        {
            var userBook = _userBookList.FirstOrDefault(x => x.Id == id);
            if (userBook != null)
            {
                return userBook;
            }
            return null;
        }

        public List<UserBook> GetAll()
        {
            return _userBookList;
        }
        public List<UserBook> GetAll(bool status)
        {
            return _userBookList.Where(x => x.IsStatus == status).ToList();
        }
        public void Update(UserBook entity)
        {
            var userBook= _userBookList.FirstOrDefault(y => y.Id == entity.Id);
            if(userBook != null)
            {//Daha sonra gün farkı alınıp bakiyeden para düşülecek
                userBook.DeliveryDate= DateTime.Now;
                userBook.IsStatus=false;
            }
        }
    }
}
