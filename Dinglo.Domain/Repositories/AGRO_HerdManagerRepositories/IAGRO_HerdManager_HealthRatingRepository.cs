using System;
using System.Collections.Generic;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Entities.Modules.AGRO_HerdManager;

namespace Dinglo.Domain.Repositories.AGRO_HerdManagerRepositories
{
    public interface IAGRO_HerdManager_HealthRatingRepository
    {
        List<AGRO_HerdManager_HealthRating> GetAll();
        List<AGRO_HerdManager_HealthRating> GetByCustAccount(Guid custAccountId);
        AGRO_HerdManager_HealthRating GetById(int id);
        bool Create(AGRO_HerdManager_HealthRating entity);
        bool Update(AGRO_HerdManager_HealthRating entity);
        bool Delete(int id);
    }
}