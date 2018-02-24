using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Faq : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
