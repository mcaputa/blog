using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Models.StorageModels;

namespace ApplicationCore.Models.DomainModels
{
    public class AllPostsDomainModel
    {
        public List<PostStorageModel> PostStorageModels { get; set; }
    }
}
