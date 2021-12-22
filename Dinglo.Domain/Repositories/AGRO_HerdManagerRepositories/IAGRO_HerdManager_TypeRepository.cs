using System;
using System.Collections.Generic;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Entities.Modules.AGRO_HerdManager;

namespace Dinglo.Domain.Repositories.AGRO_HerdManagerRepositories
{
    public interface IAGRO_HerdManager_TypeRepository
    {
        List<AGRO_HerdManager_Type> GetAll();
        List<AGRO_HerdManager_Type> GetByCustAccount(Guid custAccountId);
        AGRO_HerdManager_Type GetById(int id);
        bool Create(AGRO_HerdManager_Type entity);
        bool Update(AGRO_HerdManager_Type entity);
        bool Delete(int id);
    }
}