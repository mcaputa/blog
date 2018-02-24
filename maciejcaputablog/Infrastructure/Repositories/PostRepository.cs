using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Models.StorageModels;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IApplicationDbContext _context;

        public PostRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<PostStorageModel> GetAllPosts()
        {
            var allPosts = _context.Posts.Select(post => new PostStorageModel()
            {
                Description = post.Description,
                Title = post.Title,
                CreatedOn = post.CreatedOn.ToShortDateString(),
                Id = post.Id
            }).OrderByDescending(post => post.CreatedOn).ToList();

            return allPosts;
        }

        public PostStorageModel GetPost(int postId)
        {
            var postDomainModel = _context.Posts
                .Where(post => post.Id == postId)
                .Select(post => new PostStorageModel()
                {
                    Id = post.Id,
                    Description = post.Description,
                    Title = post.Title,
                    CreatedOn = post.CreatedOn.ToShortDateString()
                }).Single();

            return postDomainModel;
        }

        public void CreatePost(PostStorageModel postDomainModel)
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
