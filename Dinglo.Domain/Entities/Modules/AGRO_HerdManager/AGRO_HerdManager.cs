using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinglo.Domain.Entities.Modules.AGRO_HerdManager
{
    public class AGRO_HerdManager : ComplexEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string RecCustId { get; set; }

        public string EarringNumber { get; set; }
        public string BatchNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime? WeaningDate { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? EntryDate { get; set; }
        public string EarringNumberFather { get; set; }
        public string EarringNumberMom { get; set; }

        public string Description { get; set; }
        public string Observations { get; set; }

        public Guid CustAccountId { get; set; }

        [ForeignKey("CustAccountId")]
        public virtual CustAccount CustoAccount { get; set; }

        public int AGRO_HerdManager_BreedId { get; set; }

        [ForeignKey("AGRO_HerdManager_BreedId")]
        public virtual AGRO_HerdManager_Breed AGRO_HerdManager_Breed { get; set; }

        public int AGRO_HerdManager_DeathCauseId { get; set; }

        [ForeignKey("AGRO_HerdManager_DeathCauseId")]
        public virtual AGRO_HerdManager_DeathCause AGRO_HerdManager_DeathCause { get; set; }

        public int AGRO_HerdManager_DrugId { get; set; }

        [ForeignKey("AGRO_HerdManager_DrugId")]
        public virtual AGRO_HerdManager_Drug AGRO_HerdManager_Drug { get; set; }

        public int AGRO_HerdManager_ExpenseId { get; set; }

        [ForeignKey("AGRO_HerdManager_ExpenseId")]
        public virtual AGRO_HerdManager_Expense AGRO_HerdManager_Expense { get; set; }

        public int AGRO_HerdManager_HealthRatingId { get; set; }

        [ForeignKey("AGRO_HerdManager_HealthRatingId")]
        public virtual AGRO_HerdManager_HealthRating AGRO_HerdManager_HealthRating { get; set; }

        public int AGRO_HerdManager_OriginId { get; set; }

        [ForeignKey("AGRO_HerdManager_OriginId")]
        public virtual AGRO_HerdManager_Origin AGRO_HerdManager_Origin { get; set; }

        public int AGRO_HerdManager_PastureId { get; set; }

        [ForeignKey("AGRO_HerdManager_PastureId")]
        public virtual AGRO_HerdManager_Pasture AGRO_HerdManager_Pasture { get; set; }

        public int AGRO_HerdManager_StatusId { get; set; }

        [ForeignKey("AGRO_HerdManager_StatusId")]
        public virtual AGRO_HerdManager_Status AGRO_HerdManager_Status { get; set; }

        public int AGRO_HerdManager_TypeId { get; set; }

        [ForeignKey("AGRO_HerdManager_TypeId")]
        public virtual AGRO_HerdManager_Type AGRO_HerdManager_Type { get; set; }
    }
}