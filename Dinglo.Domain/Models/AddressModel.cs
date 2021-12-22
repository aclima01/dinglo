using System;
using Dinglo.Domain.Entities;

namespace Dinglo.Domain.Models
{
    public class AddressModel : Address
    {
        public int Id { get; set; }
        public Guid CustAccountId { get; set; }

        public AddressModel()
        {
            
        }

        public AddressModel(CustAddress address)
        {
            this.Id = address.Id;
            this.City = address.City;
            this.Complement = address.Complement;
            this.Country = address.Country;
            this.CustAccountId = address.CustAccountId;
            this.District = address.District;
            this.IsPrincipal = address.IsPrincipal;
            this.Number = address.Number;
            this.State = address.State;
            this.Street = address.Street;
        }
    }
}