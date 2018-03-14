using System.Collections.Generic;

namespace Core.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Post : EntityBase
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string Lead { get; set; }

        public string FriendlyUrlTitle { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<PostCategory> PostCategories { get; set; } = new HashSet<PostCategory>();

        public ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();
    }
}
