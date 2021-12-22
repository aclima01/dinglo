using System;
using System.Collections.Generic;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Entities.Modules.AGRO_HerdManager;

namespace Dinglo.Domain.Repositories.AGRO_HerdManagerRepositories
{
    public interface IAGRO_HerdManager_DrugRepository
    {
        List<AGRO_HerdManager_Drug> GetAll();
        List<AGRO_HerdManager_Drug> GetByCustAccount(Guid custAccountId);
        AGRO_HerdManager_Drug GetById(int id);
        bool Create(AGRO_HerdManager_Drug entity);
        bool Update(AGRO_HerdManager_Drug entity);
        bool Delete(int id);
    }
}