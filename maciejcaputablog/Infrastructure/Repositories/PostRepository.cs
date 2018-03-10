using System;
using System.Collections.Generic;
using System.Linq;

using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models.StorageModels;

namespace Infrastructure.Repositories
{
    using Common.Consts;

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
                    post.Text, 
                    post.CreatedOn.ToString(Const.EntityDateTimeFormat)))
                .ToList();

            return postStorageModels;
        }

        public PostStorageModel GetPost(int postId)
        {
            var post = this.postRepository.ReadById(postId);
            var postStorageModel = new PostStorageModel(
                post.Id,
                post.Title,
                post.Text,
                post.CreatedOn.ToString(Const.EntityDateTimeFormat));

            return postStorageModel;
        }

        public void CreatePost(PostStorageModel postDomainModel)
        {
            var post = new Post()
            {
                Text = postDomainModel.Description,
                Title = postDomainModel.Title,
                CreatedOn = DateTime.Today,
                ModifiedOn = DateTime.Today,
                ApplicationUserId = postDomainModel.UserId
            };

            this.postRepository.Create(post);
        }
    }
}
