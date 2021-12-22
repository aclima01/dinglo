using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinglo.Domain.Entities.Modules.AGRO_HerdManager
{
    public class AGRO_HerdManager_Expense : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public Guid CustAccountId { get; set; }

        [ForeignKey("CustAccountId")]
        public virtual CustAccount CustoAccount { get; set; }
    }
}