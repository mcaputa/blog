using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class PostSeo : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
