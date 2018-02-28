using System.Collections.Generic;
using ApplicationCore.Models.StorageModels;

namespace Core.Interfaces.Repositories
{
    public interface IPostRepository
    {
        List<PostStorageModel> GetAllPosts();

        PostStorageModel GetPost(int postId);

        void CreatePost(PostStorageModel postDomainModel);
    }
}
