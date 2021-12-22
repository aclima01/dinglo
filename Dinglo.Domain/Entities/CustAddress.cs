using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinglo.Domain.Entities
{
    public class CustAddress : Address
    {
        [Key]
        public int Id { get; set; }
        
        public Guid CustAccountId { get; set; }

        [ForeignKey("CustAccountId")]
        public virtual CustAccount CustAccount { get; set; }
    }
}