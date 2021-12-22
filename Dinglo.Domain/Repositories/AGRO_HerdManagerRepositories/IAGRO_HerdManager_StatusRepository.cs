using System;
using System.Collections.Generic;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Entities.Modules.AGRO_HerdManager;

namespace Dinglo.Domain.Repositories.AGRO_HerdManagerRepositories
{
    public interface IAGRO_HerdManager_StatusRepository
    {
        List<AGRO_HerdManager_Status> GetAll();
        List<AGRO_HerdManager_Status> GetByCustAccount(Guid custAccountId);
        AGRO_HerdManager_Status GetById(int id);
        bool Create(AGRO_HerdManager_Status entity);
        bool Update(AGRO_HerdManager_Status entity);
        bool Delete(int id);
    }
}