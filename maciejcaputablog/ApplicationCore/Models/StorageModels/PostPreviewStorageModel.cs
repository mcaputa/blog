using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.StorageModels
{
    public class PostPreviewStorageModel
    {
        public int Id { get; set; }

        public string FriendlyTitleUrl { get; set; }

        public string Title { get; set; }

        public string Preview { get; set; }

        public string CreatedOn { get; set; }
    }
}
