using System;
using System.Collections.Generic;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Entities.Modules.AGRO_HerdManager;

namespace Dinglo.Domain.Repositories.AGRO_HerdManagerRepositories
{
    public interface IAGRO_HerdManager_PastureRepository
    {
        List<AGRO_HerdManager_Pasture> GetAll();
        List<AGRO_HerdManager_Pasture> GetByCustAccount(Guid custAccountId);
        AGRO_HerdManager_Pasture GetById(int id);
        bool Create(AGRO_HerdManager_Pasture entity);
        bool Update(AGRO_HerdManager_Pasture entity);
        bool Delete(int id);
    }
}