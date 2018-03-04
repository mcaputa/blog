using Core.Models.DomainModels;

namespace Core.Interfaces.Services
{
    public interface IPostService
    {
        AllPostsDomainModel GetAllPosts();

        PostDomainModel GetPost(int postId);

        void CreatePost(PostDomainModel postDomainModel);
    }
}
