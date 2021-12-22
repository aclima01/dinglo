using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dinglo.Domain.Entities.Modules.AGRO_HerdManager;

namespace Dinglo.Domain.Entities
{
    public class CustAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string IdentityDocumentNr { get; set; }
        public string WebSite { get; set; }
        public string PrefixKey { get; set; }

        public virtual List<CustAddress> CustAddress { get; set; }
        public virtual List<CustContact> CustContacts { get; set; }

        public virtual List<AGRO_HerdManager> AGRO_HerdManagers { get; set; }
        public virtual List<AGRO_HerdManager_Origin> AGRO_HerdManager_Origins { get; set; }
        public virtual List<AGRO_HerdManager_Breed> AGRO_HerdManager_Breeds { get; set; }
        public virtual List<AGRO_HerdManager_Type> AGRO_HerdManager_Types { get; set; }
        public virtual List<AGRO_HerdManager_Status> AGRO_HerdManager_Status { get; set; }
        public virtual List<AGRO_HerdManager_DeathCause> AGRO_HerdManager_DeathCauses { get; set; }
        public virtual List<AGRO_HerdManager_Pasture> AGRO_HerdManager_Pastures { get; set; }
        public virtual List<AGRO_HerdManager_HealthRating> AGRO_HerdManager_HealthRatings { get; set; }
        public virtual List<AGRO_HerdManager_Drug> AGRO_HerdManager_Drugs { get; set; }
    }
}