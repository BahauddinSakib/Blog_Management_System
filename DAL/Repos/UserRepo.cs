using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, string, User>, IAuth<bool>
    {
        public User Create(User obj)
        {
            Db.Users.Add(obj);
            if (Db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            Db.Users.Remove(ex);
            return Db.SaveChanges() > 0;
        }

        public List<User> Read()
        {
            return Db.Users.ToList();
        }

        public User Read(string id)
        {
            return Db.Users.Find(id);
        }
        public List<User> GetAll()
        {
            return Read();
        }


        public User Update(User obj)
        {
            var ex = Read(obj.Uname);
            Db.Entry(ex).CurrentValues.SetValues(obj);
            if (Db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Authenticate(string username, string password)
        {
            var data = Db.Users.FirstOrDefault(u => u.Uname.Equals(username) && u.Password.Equals(password));
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
