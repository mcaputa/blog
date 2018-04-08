using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.StorageModels
{
    public class PostSeoStorageModel
    {
        public PostSeoStorageModel()
        {
            
        }

        public PostSeoStorageModel(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
