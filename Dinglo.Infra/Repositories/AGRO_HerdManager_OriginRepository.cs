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
    public class AGRO_HerdManager_OriginRepository : IAGRO_HerdManager_OriginRepository
    {
        private readonly DingloContext _context;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AGRO_HerdManager_OriginRepository(DingloContext context,
                                 UserManager<UserIdentity> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public bool Create(AGRO_HerdManager_Origin entity)
        {
            _context.AGRO_HerdManager_Origins.Add(entity);
            _context.SaveChanges();

            return true;
        }

        public bool Update(AGRO_HerdManager_Origin entity)
        {
            var localEntity = _context.AGRO_HerdManager_Origins.FirstOrDefault(_ => _.Id == entity.Id);

            localEntity.Name = entity.Name;
            localEntity.Description = entity.Description;

            _context.Entry<AGRO_HerdManager_Origin>(localEntity).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.AGRO_HerdManager_Origins.FirstOrDefault(_ => _.Id == id);

            _context.AGRO_HerdManager_Origins.Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public List<AGRO_HerdManager_Origin> GetAll()
        {
            return _context.AGRO_HerdManager_Origins.ToList();
        }

        public List<AGRO_HerdManager_Origin> GetByCustAccount(Guid custAccountId)
        {
            return _context.AGRO_HerdManager_Origins.Where(_ => _.CustAccountId == custAccountId).ToList();
        }

        public AGRO_HerdManager_Origin GetById(int id)
        {
            return _context.AGRO_HerdManager_Origins.FirstOrDefault(_ => _.Id == id);
        }
    }
}