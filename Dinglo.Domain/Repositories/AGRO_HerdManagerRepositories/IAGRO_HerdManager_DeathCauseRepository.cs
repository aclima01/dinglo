using System;
using System.Collections.Generic;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Entities.Modules.AGRO_HerdManager;

namespace Dinglo.Domain.Repositories.AGRO_HerdManagerRepositories
{
    public interface IAGRO_HerdManager_DeathCauseRepository
    {
        List<AGRO_HerdManager_DeathCause> GetAll();
        List<AGRO_HerdManager_DeathCause> GetByCustAccount(Guid custAccountId);
        AGRO_HerdManager_DeathCause GetById(int id);
        bool Create(AGRO_HerdManager_DeathCause entity);
        bool Update(AGRO_HerdManager_DeathCause entity);
        bool Delete(int id);
    }
}