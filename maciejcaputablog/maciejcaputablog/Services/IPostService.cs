using maciejcaputablog.DomainModels;
using maciejcaputablog.ViewModels;

namespace maciejcaputablog.Services
{
    public interface IPostService
    {
        PostViewModel GetAllPosts();
        PostDomainModel GetPost(int postId);
        void CreatePost(PostDomainModel postDomainModel);
    }
}
