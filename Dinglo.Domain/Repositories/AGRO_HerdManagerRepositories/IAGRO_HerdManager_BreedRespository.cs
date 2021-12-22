using System;
using System.Collections.Generic;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Entities.Modules.AGRO_HerdManager;

namespace Dinglo.Domain.Repositories.AGRO_HerdManagerRepositories
{
    public interface IAGRO_HerdManager_BreedRespository
    {
        List<AGRO_HerdManager_Breed> GetAll();
        List<AGRO_HerdManager_Breed> GetByCustAccount(Guid custAccountId);
        AGRO_HerdManager_Breed GetById(int id);
        bool Create(AGRO_HerdManager_Breed entity);
        bool Update(AGRO_HerdManager_Breed entity);
        bool Delete(int id);
    }
}