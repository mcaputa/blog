using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    using System;

    using Common.Consts;

    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = Const.EntityDateTimeFormat)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = Const.EntityDateTimeFormat)]
        public DateTime ModifiedOn { get; set; }
    }
}
