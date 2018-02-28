using ApplicationCore.Models.DomainModels;

namespace ApplicationCore.Interfaces.Services
{
    public interface IPostService
    {
        AllPostsDomainModel GetAllPosts();

        PostDomainModel GetPost(int postId);

        void CreatePost(PostDomainModel postDomainModel);
    }
}
