using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PostService
    {
        //Get data
        public static List<PostDTO> Get()
        {
            var data = DataAccessFactory.PostData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Post, PostDTO>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PostDTO>>(data);
            return mapped;

        }
        //Get10 data
        public List<PostDTO>Get10()
        {
            var data = DataAccessFactory.PostData().Read().Take(10).ToList();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PostDTO>>(data);
            return mapped;
        }
        public static PostDTO Get(int id)
        {
            var data = DataAccessFactory.PostData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Post, PostDTO>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PostDTO>(data);
            return mapped;

        }
        //Create
        public bool Create(PostDTO post)
        {
            var cfg = new MapperConfiguration(c => c.CreateMap<PostDTO, Post>());
            var mapper = new Mapper(cfg);
            var postEntity = mapper.Map<Post>(post);

            return DataAccessFactory.PostData().Create(postEntity); 
        }
        //Update
        public bool Update(PostDTO post)
        {
            var cfg = new MapperConfiguration(c => c.CreateMap<PostDTO, Post>());
            var mapper = new Mapper(cfg);
            var postEntity = mapper.Map<Post>(post);

            return DataAccessFactory.PostData().Update(postEntity); 
        }
        //Delete
        public bool Delete(int id)
        {
            return DataAccessFactory.PostData().Delete(id); 
        }

        public static PostCommentDTO GetWithComments(int id)
        {
            var data = DataAccessFactory.PostData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Post,PostCommentDTO>();
                c.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PostCommentDTO>(data);
            return mapped;
        }

        //comment count by 
        public static int GetCommentCountByUser(string commentedBy)
        {
            var posts = DataAccessFactory.PostData().Read();
            return posts
                .SelectMany(p => p.Comments)       
                .Count(c => c.CommentedBy == commentedBy);
        }
    }
}
