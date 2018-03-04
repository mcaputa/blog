using Core.Models.StorageModels;

namespace Core.Models.DomainModels
{
    public class PostDomainModel
    {
        public PostDomainModel(PostStorageModel postStorageModel)
        {
            this.PostStorageModel = postStorageModel;
        }

        public PostStorageModel PostStorageModel { get; set; }
    }
}
