using System;
using System.Collections.Generic;
using System.Linq;

using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models.StorageModels;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IRepository<Post> postRepository;

        public PostRepository(IRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public List<PostStorageModel> GetAllPosts()
        {
            var posts = this.postRepository.GetList().OrderByDescending(post => post.CreatedOn);

            var postStorageModels = posts.Select(
                post => new PostStorageModel(
                    post.Id, 
                    post.Title, 
                    post.Description, 
                    post.CreatedOn.ToShortDateString()))
                .ToList();

            return postStorageModels;
        }

        public PostStorageModel GetPost(int postId)
        {
            var post = this.postRepository.ReadById(postId);
            var postStorageModel = new PostStorageModel(
                post.Id,
                post.Title,
                post.Description,
                post.CreatedOn.ToShortDateString());

            return postStorageModel;
        }

        public void CreatePost(PostStorageModel postDomainModel)
        {
            var post = new Post()
            {
                Description = postDomainModel.Description,
                Title = postDomainModel.Title,
                CreatedOn = DateTime.Today,
                ModifiedOn = DateTime.Today,
                ApplicationUserId = postDomainModel.UserId
            };

            this.postRepository.Create(post);
        }
    }
}
