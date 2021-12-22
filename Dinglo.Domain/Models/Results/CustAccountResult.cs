using System;
using System.Collections.Generic;
using System.Linq;
using Dinglo.Domain.Entities;

namespace Dinglo.Domain.Models.Results
{
    public class CustAccountResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string IdentityDocumentNr { get; set; }
        public string WebSite { get; set; }
        public string PrefixKey { get; set; }
        public virtual List<AddressModel> CustAddress { get; set; }
        public virtual List<ContactModel> CustContacts { get; set; }

        public CustAccountResult()
        {
            
        }

        public CustAccountResult(CustAccount custAccount)
        {
            this.Id = custAccount.Id;
            this.Name = custAccount.Name;
            this.Email = custAccount.Email;
            this.IdentityDocumentNr = custAccount.IdentityDocumentNr;
            this.WebSite = custAccount.WebSite;
            this.PrefixKey = custAccount.PrefixKey;
            this.CustAddress = custAccount.CustAddress.Select(address => new AddressModel(address)).ToList();
            this.CustContacts = custAccount.CustContacts.Select(contact => new ContactModel(contact)).ToList();
        }
    }
}