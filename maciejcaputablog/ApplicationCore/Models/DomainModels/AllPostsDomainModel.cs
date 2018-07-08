using System;
using System.Collections.Generic;
using System.Text;
using Core.Models.StorageModels;

namespace Core.Models.DomainModels
{
    public class AllPostsDomainModel
    {
        public List<PostPreviewStorageModel> PostPreviewStorageModels { get; set; }
    }
}
