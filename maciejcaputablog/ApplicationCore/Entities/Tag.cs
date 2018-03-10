using System.Collections.Generic;

namespace Core.Entities
{
    public sealed class Tag : EntityBase
    {
        public string Name { get; set; }

        public ICollection<PostTag> Posts { get; set; } = new HashSet<PostTag>();
    }
}
