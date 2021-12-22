using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Dinglo.Domain.Entities;
using Dinglo.Infra.Context;
using Dinglo.Domain.Entities.Account;
using Dinglo.Domain.Repositories;
using Dinglo.Domain.Models.Results;
using Dinglo.Domain.Models;

namespace Dinglo.Infra.Repositories
{
    public class CustAccountRepository : ICustAccountRepository
    {
        private readonly DingloContext _context;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CustAccountRepository(DingloContext context,
                                 UserManager<UserIdentity> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public bool Create(CustAccount entity)
        {
            _context.CustAccounts.Add(entity);
            _context.SaveChanges();

            return true;
        }

        public bool Update(CustAccount entity)
        {
            var localEntity = _context.CustAccounts.FirstOrDefault(_ => _.Id == entity.Id);

            localEntity.Email = entity.Email;
            localEntity.IdentityDocumentNr = entity.IdentityDocumentNr;
            localEntity.Name = entity.Name;
            localEntity.PrefixKey = entity.PrefixKey;
            localEntity.WebSite = entity.WebSite;

            _context.Entry<CustAccount>(localEntity).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public bool Delete(Guid id)
        {
            var entity = _context.CustAccounts.FirstOrDefault(_ => _.Id == id);

            _context.CustAccounts.Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public List<CustAccountResult> GetAll()
        {
            return _context.CustAccounts
                            .Include(_ => _.CustAddress)
                            .Include(_ => _.CustContacts)
                            .Select(result => new CustAccountResult(result))
                            .ToList();
        }

        public CustAccountResult GetById(Guid id)
        {
            return _context.CustAccounts
                            .Include(_ => _.CustAddress)
                            .Include(_ => _.CustContacts)
                            .Where(_ => _.Id == id)
                            .Select(result => new CustAccountResult(result))
                            .FirstOrDefault();
        }

        public List<AddressModel> GetCustAddresses(Guid id)
        {
            return _context.CustAddresses
                                .Where(_ => _.CustAccountId == id)
                                .Select(result => new AddressModel(result))
                                .ToList();
        }

        public bool CreateAddress(CustAddress entity)
        {
            _context.CustAddresses.Add(entity);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateAddress(CustAddress entity)
        {
            var localEntity = _context.CustAddresses.FirstOrDefault(_ => _.Id == entity.Id);

            localEntity.City = entity.City;
            localEntity.Complement = entity.Complement;
            localEntity.Country = entity.Country;
            localEntity.District = entity.District;
            localEntity.IsPrincipal = entity.IsPrincipal;
            localEntity.Number = entity.Number;
            localEntity.State = entity.State;
            localEntity.Street = entity.Street;

            _context.Entry<CustAddress>(localEntity).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public bool DeleteAddress(int id)
        {
            var entity = _context.CustAddresses.FirstOrDefault(_ => _.Id == id);

            _context.CustAddresses.Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public List<ContactModel> GetCustContacts(Guid id)
        {
            return _context.CustContacts
                                .Where(_ => _.CustAccountId == id)
                                .Select(result => new ContactModel(result))
                                .ToList();
        }

        public bool CreateContact(CustContact entity)
        {
            _context.CustContacts.Add(entity);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateContact(CustContact entity)
        {
            var localEntity = _context.CustContacts.FirstOrDefault(_ => _.Id == entity.Id);

            localEntity.Fullname = entity.Fullname;
            localEntity.IsPrincipal = entity.IsPrincipal;
            localEntity.Type = entity.Type;
            localEntity.Value = entity.Value;

            _context.Entry<CustContact>(localEntity).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public bool DeleteContact(int id)
        {
            var entity = _context.CustContacts.FirstOrDefault(_ => _.Id == id);

            _context.CustContacts.Remove(entity);
            _context.SaveChanges();

            return true;
        }
    }
}