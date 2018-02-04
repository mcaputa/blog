using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maciejcaputablog.DomainModels;
using maciejcaputablog.Entity;
using maciejcaputablog.Models;

namespace maciejcaputablog.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IApplicationDbContext _context;

        public PostRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<PostDomainModel> GetAllPosts()
        {
            var allPosts = _context.Posts.Select(post => new PostDomainModel()
            {
                Description = post.Description,
                Title = post.Title,
                CreatedOn = post.CreatedOn.ToShortDateString(),
                Id = post.Id
            }).ToList();

            return allPosts;
        }

        public PostDomainModel GetPost(int postId)
        {
            var postDomainModel = _context.Posts
                .Where(post => post.Id == postId)
                .Select(post => new PostDomainModel()
                {
                    Description = post.Description,
                    Title = post.Title,
                    CreatedOn = post.CreatedOn.ToShortDateString()
                }).Single();

            return postDomainModel;
        }

        public void CreatePost(PostDomainModel postDomainModel)
        {
            var post = new Post()
            {
                Description = postDomainModel.Description,
                Title = postDomainModel.Title,
                CreatedOn = DateTime.Today,
                ModifiedOn = DateTime.Today
            };

            _context.Posts.Add(post);
            _context.SaveChanges();
        }
    }
}
