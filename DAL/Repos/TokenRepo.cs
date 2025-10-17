using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        public Token Create(Token obj)
        {
            Db.Tokens.Add(obj);
            if(Db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;    
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Read()
        {
            throw new NotImplementedException();
        }

        public Token Read(string id)
        {
            return Db.Tokens.FirstOrDefault(t => t.TKey.Equals(id));
        }

        public Token Update(Token obj)
        {
            var token = Read(obj.TKey);
            Db.Entry(token).CurrentValues.SetValues(obj);
            if(Db.SaveChanges() > 0)
            {
                return token;
            }
            return null;
        }
    }
}
