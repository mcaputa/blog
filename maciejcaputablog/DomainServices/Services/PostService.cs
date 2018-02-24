using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.DomainModels;
using Core.Interfaces.Repositories;

namespace DomainServices.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public AllPostsDomainModel GetAllPosts()
        {
            var allPostsDomainModels = _postRepository.GetAllPosts();

            var postsViewModel = new AllPostsDomainModel()
            {
                PostStorageModels = allPostsDomainModels
            };
            return postsViewModel;
        }

        public PostDomainModel GetPost(int postId)
        {
            var post = this._postRepository.GetPost(postId);

            var postDomainModel = new PostDomainModel()
            {
                PostStorageModel = post
            }; 

            return postDomainModel;
        }

        public void CreatePost(PostDomainModel postDomainModel)
        {
            _postRepository.CreatePost(postDomainModel.PostStorageModel);
        }
    }
}
