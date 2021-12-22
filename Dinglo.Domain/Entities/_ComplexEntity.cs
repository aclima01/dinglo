using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinglo.Domain.Entities
{
    public class ComplexEntity
    {
        public DateTime? CreatedAt { get; set; }

        public int CreatedByAppUserId { get; set; }

        [ForeignKey("CreatedById")]
        public virtual AppUser CreatedByAppUser { get; set; }
    }
}