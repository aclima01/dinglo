using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Entities.Account;

namespace Dinglo.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string FullName { get; set; }
        public string IdentityDocumentNr { get; set; }
        public string RoleDefault { get; set; }

        public string AspNetUserIdentityId {get;set;}

        [ForeignKey("AspNetUserIdentityId")]
        public UserIdentity AspNetUserIdentity {get;set;}
       
    }
}