using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Dinglo.Domain.Repositories;
using Dinglo.Domain.Entities;
using Dinglo.Infra.Context;
using Dinglo.Domain.Entities.Account;
using Dinglo.Domain.Models.Results;

namespace Dinglo.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DingloContext _context;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(DingloContext context,
                                 UserManager<UserIdentity> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Create(AppUser model)
        {
            _context.AppUsers.Add(model);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
             var user = _context.AppUsers.FirstOrDefault(_ => _.Id == id);

            _context.AppUsers.Remove(user);
            _context.SaveChanges();

            return true;
        }

        public List<AppUser> GetAll()
        {
            return _context.AppUsers.ToList();
        }

        public AppUser GetByDocument(string document)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetById(int id)
        {
            return _context.AppUsers.FirstOrDefaultAsync(_ => _.Id == id);
        }

        public Task<AppUser> GetByIdentityId(string id)
        {
            return _context.AppUsers
                            .Include(_ => _.AspNetUserIdentity)
                            .FirstOrDefaultAsync(_ => _.AspNetUserIdentity.Id == id);
        }

        public Task<List<AppUser>> GetByCustomer(string roleDefault)
        {
            var role = $"cust_{roleDefault}";

            return _context.AppUsers
                            .Include(_ => _.AspNetUserIdentity)
                            .Where(_ => _.RoleDefault == role)
                            .ToListAsync();
        }

        public AppUser GetUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        public AppUser GetUsuarioByIdentity(string userIdentityId)
        {
            return _context.AppUsers.FirstOrDefault(_ => _.AspNetUserIdentityId == userIdentityId);
        }

        public void Update(AppUser model)
        {
            var nUser = _context.AppUsers.FirstOrDefault(_ => _.Id == model.Id);

            nUser.FullName = model.FullName;
            nUser.IdentityDocumentNr = model.IdentityDocumentNr;

            _context.AppUsers.Update(nUser);
            _context.SaveChanges();
        }

        public UserModelResult Me(string userId)
        {
            var appUser = _context.AppUsers
                                    .Include(_ => _.AspNetUserIdentity)
                                    .FirstOrDefault(_ => _.AspNetUserIdentityId == userId);

            UserModelResult user = new UserModelResult();
            user.Id     = appUser.AspNetUserIdentityId;
            user.Name   = appUser.FullName;
            user.Email  = appUser.AspNetUserIdentity.Email;
            user.Avatar = "";
            user.Status = "Online";

            return user;
        }
    }
}
