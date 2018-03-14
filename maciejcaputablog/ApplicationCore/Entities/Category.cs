using System.Collections.Generic;

namespace Core.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        public ICollection<PostCategory> PostCategories { get; set; } = new HashSet<PostCategory>();
    }
}
