using System.Collections.Generic;
using ApplicationCore.Models.StorageModels;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IPostRepository
    {
        List<PostStorageModel> GetAllPosts();
        PostStorageModel GetPost(int postId);
        void CreatePost(PostStorageModel postDomainModel);
    }
}
