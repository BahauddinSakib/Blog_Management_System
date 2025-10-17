using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PostRepo : Repo, IRepo<Post, int, bool>
    {
        public bool Create(Post post)
        {
            Db.Posts.Add(post);
            return Db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exPost = Db.Posts.Find(id);
            if (exPost == null) return false;

            Db.Posts.Remove(exPost);
            return Db.SaveChanges() > 0;
        }

        public List<Post> Read()
        {
            return Db.Posts.ToList();
        }

        public Post Read(int id)
        {
            return Db.Posts.Find(id);
        }

        public bool Update(Post post)
        {
            var exPost = Db.Posts.Find(post.Id);
            if (exPost == null) return false;

            Db.Entry(exPost).CurrentValues.SetValues(post);
            return Db.SaveChanges() > 0;
        }
    }

}
