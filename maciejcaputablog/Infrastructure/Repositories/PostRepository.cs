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

        private readonly IApplicationDbContext context;

        public PostRepository(IRepository<Post> postRepository, IApplicationDbContext context)
        {
            this.postRepository = postRepository;
            this.context = context;
        }

        public List<PostStorageModel> GetAllPosts()
        {
            var posts = this.postRepository.GetList().OrderByDescending(post => post.CreatedOn);

            var postStorageModels = posts.Select(
                post => new PostStorageModel(
                    post.Id, 
                    post.Title, 
                    post.Text, 
                    post.CreatedOn.ToString(Const.EntityDateTimeFormat), 
                    post.FriendlyUrlTitle))
                .ToList();

            return postStorageModels;
        }

        public PostStorageModel GetPost(string friendlyTitle)
        {
            var currentPost = this.context.Posts.Single(post => post.FriendlyUrlTitle == friendlyTitle);
            var postStorageModel = new PostStorageModel(
                currentPost.Id,
                currentPost.Title,
                currentPost.Text,
                currentPost.CreatedOn.ToString(Const.EntityDateTimeFormat),
                currentPost.FriendlyUrlTitle);

            return postStorageModel;
        }

        public void CreatePost(PostStorageModel postStorageModel)
        {
            var post = new Post()
            {
                Text = postStorageModel.Description,
                Title = postStorageModel.Title,
                CreatedOn = DateTime.Today,
                ModifiedOn = DateTime.Today,
                ApplicationUserId = postStorageModel.UserId, 
                FriendlyUrlTitle = postStorageModel.FriendlyTitleUrl
            };

            this.postRepository.Create(post);
        }
    }
}
