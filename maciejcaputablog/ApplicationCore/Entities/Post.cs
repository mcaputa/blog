using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Post : EntityBase
    {
        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string Description { get; set; }
    }
}
