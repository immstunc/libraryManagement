using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    internal class UserRepository : IRepository<User>
    {
        private static List<User> _userList = new List<User>();
        private static int idCount = 0;
        public bool Add(User entity)
        {
            bool result = false;
            if (entity != null)
            {
                idCount++;
                entity.Id= idCount;
                _userList.Add(entity);
                result = !result;
            }
            return result;
        }

        public bool Delete(int id)
        {
            var user = _userList.FirstOrDefault(x => x.Id == id);
            bool result = false;
            if (user != null)
            {
                user.IsDelete = true;
                result = !result;
            }
            return result;
        }

        public User Get(int id)
        {
           var user=_userList.FirstOrDefault(x=>x.Id==id && x.IsDelete==false);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public List<User> GetAll()
        {
            return _userList.Where(x=>x.IsDelete==false).ToList();
        }

        public void Update(User entity)
        {
            var user=_userList.FirstOrDefault(x=>x.Id==entity.Id);
            if (user != null)
            {
                user.Name= String.IsNullOrWhiteSpace(entity.Name)?user.Name:entity.Name;
                user.Surname= String.IsNullOrWhiteSpace(entity.Surname)?user.Surname:entity.Surname;
                user.Balance= entity.Balance>=0?entity.Balance:user.Balance;
                user.IsStatus = entity.IsStatus;
            }
        }
    }
}
