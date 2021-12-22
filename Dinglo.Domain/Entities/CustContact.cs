using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinglo.Domain.Entities
{
    public class CustContact : Contact
    {
        [Key]
        public int Id { get; set; }

        public Guid CustAccountId { get; set; }

        [ForeignKey("CustAccountId")]
        public virtual CustAccount CustAccount { get; set; }
    }
}