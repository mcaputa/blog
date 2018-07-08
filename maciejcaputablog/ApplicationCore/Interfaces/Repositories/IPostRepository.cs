using System.Collections.Generic;
using Core.Models.StorageModels;

namespace Core.Interfaces.Repositories
{
    public interface IPostRepository
    {
        List<PostPreviewStorageModel> GetAllPosts();

        PostStorageModel GetPost(string friendlyTitle);

        void CreatePost(PostStorageModel postStorageModel);
    }
}
