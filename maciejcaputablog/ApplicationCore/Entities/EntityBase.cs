using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    using System;

    using Common.Consts;

    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        public DateTime ModifiedOn { get; set; }
    }
}
