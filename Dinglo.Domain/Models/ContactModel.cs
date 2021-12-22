using System;
using Dinglo.Domain.Entities;

namespace Dinglo.Domain.Models
{
    public class ContactModel : Contact
    {
        public int Id { get; set; }
        public Guid CustAccountId { get; set; }

        public ContactModel()
        {
            
        }
        
        public ContactModel(CustContact custContact)
        {
            this.Id = custContact.Id;
            this.CustAccountId = custContact.CustAccountId;
            this.Fullname = custContact.Fullname;
            this.IsPrincipal = custContact.IsPrincipal;
            this.Type = custContact.Type;
            this.Value = custContact.Value;
        }
    }
}