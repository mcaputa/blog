using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.DomainModels;

namespace DomainServices.Services
{
    using System;

    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;

        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public AllPostsDomainModel GetAllPosts()
        {
            var allPostsDomainModels = this.postRepository.GetAllPosts();

            var postsViewModel = new AllPostsDomainModel()
            {
                PostStorageModels = allPostsDomainModels
            };
            return postsViewModel;
        }

        public PostDomainModel GetPost(int postId)
        {
            if (postId < 0) throw new ArgumentOutOfRangeException(nameof(postId));

            var post = this.postRepository.GetPost(postId);

            var postDomainModel = new PostDomainModel(post);

            var pdm = new PostDomainModel(post);
            
            return postDomainModel;
        }

        public void CreatePost(PostDomainModel postDomainModel)
        {
            this.postRepository.CreatePost(postDomainModel.PostStorageModel);
        }
    }
}
