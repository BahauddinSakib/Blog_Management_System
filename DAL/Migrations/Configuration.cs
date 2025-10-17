namespace DAL.Migrations
{
    using DAL.Model;

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Model.PostContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Model.PostContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
           /* for (int i = 0; i <=9; i++)
            {
                context.Users.AddOrUpdate(new Model.User
                {
                    Name = Guid.NewGuid().ToString().Substring(0, 15),
                    Uname = "User-" + i,
                    Password = Guid.NewGuid().ToString().Substring(0, 8),
                    Type = "General"
                });
            }
            Random random = new Random();
            for(int i = 1; i <= 20; i++)
            {
                context.Posts.AddOrUpdate(new Model.Post
                {
                    Id = i,
                    Title = Guid.NewGuid().ToString().Substring(0,5),
                    Description = Guid.NewGuid().ToString(),
                    Date = DateTime.Now,
                    PostedBy = "User-"+random.Next(1,10)
                });
            }
            for(int i=1;i<=100;i++)
            {
                context.Comments.AddOrUpdate(new Model.Comment
                {
                    Id = i,
                    CommentText = Guid.NewGuid().ToString().Substring(0, 5),
                    PostId = random.Next(1,21),
                    Time = DateTime.Now,
                    CommentedBy = "User-" + random.Next(1, 10)
                });
            } */
            
        }
    }
}
