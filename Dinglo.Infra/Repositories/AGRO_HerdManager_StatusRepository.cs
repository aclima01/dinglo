using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Dinglo.Domain.Repositories.AGRO_HerdManagerRepositories;
using Dinglo.Domain.Entities;
using Dinglo.Infra.Context;
using Dinglo.Domain.Entities.Account;
using Dinglo.Domain.Entities.Modules.AGRO_HerdManager;

namespace Dinglo.Infra.Repositories
{
    public class AGRO_HerdManager_StatusRepository : IAGRO_HerdManager_StatusRepository
    {
        private readonly DingloContext _context;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AGRO_HerdManager_StatusRepository(DingloContext context,
                                 UserManager<UserIdentity> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public bool Create(AGRO_HerdManager_Status entity)
        {
            _context.AGRO_HerdManager_Status.Add(entity);
            _context.SaveChanges();

            return true;
        }

        public bool Update(AGRO_HerdManager_Status entity)
        {
            var localEntity = _context.AGRO_HerdManager_Status.FirstOrDefault(_ => _.Id == entity.Id);

            localEntity.Name = entity.Name;
            localEntity.Description = entity.Description;

            _context.Entry<AGRO_HerdManager_Status>(localEntity).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.AGRO_HerdManager_Status.FirstOrDefault(_ => _.Id == id);

            _context.AGRO_HerdManager_Status.Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public List<AGRO_HerdManager_Status> GetAll()
        {
            return _context.AGRO_HerdManager_Status.ToList();
        }

        public List<AGRO_HerdManager_Status> GetByCustAccount(Guid custAccountId)
        {
            return _context.AGRO_HerdManager_Status.Where(_ => _.CustAccountId == custAccountId).ToList();
        }

        public AGRO_HerdManager_Status GetById(int id)
        {
            return _context.AGRO_HerdManager_Status.FirstOrDefault(_ => _.Id == id);
        }
    }
}