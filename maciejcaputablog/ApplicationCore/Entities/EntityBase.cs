using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
