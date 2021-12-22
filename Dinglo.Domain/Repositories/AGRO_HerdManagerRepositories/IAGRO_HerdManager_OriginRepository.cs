using System;
using System.Collections.Generic;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Entities.Modules.AGRO_HerdManager;

namespace Dinglo.Domain.Repositories.AGRO_HerdManagerRepositories
{
    public interface IAGRO_HerdManager_OriginRepository
    {
        List<AGRO_HerdManager_Origin> GetAll();
        List<AGRO_HerdManager_Origin> GetByCustAccount(Guid custAccountId);
        AGRO_HerdManager_Origin GetById(int id);
        bool Create(AGRO_HerdManager_Origin entity);
        bool Update(AGRO_HerdManager_Origin entity);
        bool Delete(int id);
    }
}