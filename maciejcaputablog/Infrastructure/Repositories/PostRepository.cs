using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Models.StorageModels;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class PostRepository :  IPostRepository
    {
        private readonly IRepository<Post> _postRepository;

        public PostRepository(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public List<PostStorageModel> GetAllPosts()
        {
            var allPosts = _postRepository.GetList().Select(post => new PostStorageModel()
            {
                Description = post.Description,
                Title = post.Title,
                CreatedOn = post.CreatedOn.ToShortDateString(),
                Id = post.Id
            })
            .OrderByDescending(post => post.CreatedOn)
            .ToList();

            return allPosts;
        }

        public PostStorageModel GetPost(int postId)
        {
            var post = _postRepository.ReadById(postId);
            var postStorageModel = new PostStorageModel()
            {
                Id = post.Id,
                Description = post.Description,
                Title = post.Title,
                CreatedOn = post.CreatedOn.ToShortDateString()
            };

            return postStorageModel;
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

            _postRepository.Create(post);
        }
    }
}
