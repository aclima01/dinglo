using System;
using System.Collections.Generic;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Models;
using Dinglo.Domain.Models.Results;

namespace Dinglo.Domain.Repositories
{
    public interface ICustAccountRepository
    {
        bool Create(CustAccount entity);
        List<CustAccountResult> GetAll();
        CustAccountResult GetById(Guid id);

        bool Update(CustAccount entity);
        bool Delete(Guid id);

        List<AddressModel> GetCustAddresses(Guid id);
        bool CreateAddress(CustAddress entity);
        bool UpdateAddress(CustAddress entity);
        bool DeleteAddress(int id);

        List<ContactModel> GetCustContacts(Guid id);
        bool CreateContact(CustContact entity);
        bool UpdateContact(CustContact entity);
        bool DeleteContact(int id);
    }
}