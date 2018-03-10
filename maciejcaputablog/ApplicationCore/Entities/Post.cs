using System.Collections.Generic;

namespace Core.Entities
{
    public sealed class Post : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<PostCategory> PostCategories { get; set; } = new HashSet<PostCategory>();

        public ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();
    }
}
