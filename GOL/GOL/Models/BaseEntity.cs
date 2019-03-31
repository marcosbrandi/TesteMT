using System;
using System.ComponentModel.DataAnnotations;

namespace GOL.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual Guid Id { get; set; }
    }
}
