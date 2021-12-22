using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Models.Results;

namespace Dinglo.Domain.Repositories
{
    public interface IUserRepository
    {
        List<AppUser> GetAll();
        void Create(AppUser model);
        void Update(AppUser model);
        bool Delete(int id);
        Task<AppUser> GetById(int id);
        Task<AppUser> GetByIdentityId(string id);
        AppUser GetUsuarioById(int id);
        AppUser GetUsuarioByIdentity(string userIdentityId);
        AppUser GetByDocument(string document);
        Task<List<AppUser>> GetByCustomer(string roleDefault);
        UserModelResult Me(string userId); 
    }
}

