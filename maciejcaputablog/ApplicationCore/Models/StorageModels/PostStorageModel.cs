namespace Core.Models.StorageModels
{
    public class PostStorageModel
    {
        public PostStorageModel()
        {
        }

        public PostStorageModel(int id, string title, string description, string createdOn)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.CreatedOn = createdOn;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatedOn { get; set; }

        public string UserId { get; set; }
    }
}
