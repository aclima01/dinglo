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
    public class AGRO_HerdManager_BreedRepository : IAGRO_HerdManager_BreedRespository
    {
        private readonly DingloContext _context;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AGRO_HerdManager_BreedRepository(DingloContext context,
                                 UserManager<UserIdentity> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public bool Create(AGRO_HerdManager_Breed breed)
        {
            _context.AGRO_HerdManager_Breeds.Add(breed);
            _context.SaveChanges();

            return true;
        }

        public bool Update(AGRO_HerdManager_Breed breed)
        {
            var entity = _context.AGRO_HerdManager_Breeds.FirstOrDefault(_ => _.Id == breed.Id);

            entity.Name = breed.Name;
            entity.Description = breed.Description;

            _context.Entry<AGRO_HerdManager_Breed>(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.AGRO_HerdManager_Breeds.FirstOrDefault(_ => _.Id == id);

            _context.AGRO_HerdManager_Breeds.Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public List<AGRO_HerdManager_Breed> GetAll()
        {
            return _context.AGRO_HerdManager_Breeds.ToList();
        }

        public List<AGRO_HerdManager_Breed> GetByCustAccount(Guid custAccountId)
        {
            return _context.AGRO_HerdManager_Breeds.Where(_ => _.CustAccountId == custAccountId).ToList();
        }

        public AGRO_HerdManager_Breed GetById(int id)
        {
            return _context.AGRO_HerdManager_Breeds.FirstOrDefault(_ => _.Id == id);
        }
    }
}