using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maciejcaputablog.DomainModels;
using maciejcaputablog.Repositories;
using maciejcaputablog.ViewModels;

namespace maciejcaputablog.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public PostViewModel GetAllPosts()
        {
            var allPostsDomainModels = _postRepository.GetAllPosts();

            var postsViewModel = new PostViewModel()
            {
                PostDomainModels = allPostsDomainModels
            };
            return postsViewModel;
        }

        public PostDomainModel GetPost(int postId)
        {
            PostDomainModel postDomainModel = this._postRepository.GetPost(postId);

            return postDomainModel;
        }

        public void CreatePost(PostDomainModel postDomainModel)
        {
            _postRepository.CreatePost(postDomainModel);
        }
    }
}
