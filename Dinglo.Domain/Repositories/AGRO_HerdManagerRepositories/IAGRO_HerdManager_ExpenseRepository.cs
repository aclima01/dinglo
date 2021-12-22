using System;
using System.Collections.Generic;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Entities.Modules.AGRO_HerdManager;

namespace Dinglo.Domain.Repositories.AGRO_HerdManagerRepositories
{
    public interface IAGRO_HerdManager_ExpenseRepository
    {
        List<AGRO_HerdManager_Expense> GetAll();
        List<AGRO_HerdManager_Expense> GetByCustAccount(Guid custAccountId);
        AGRO_HerdManager_Expense GetById(int id);
        bool Create(AGRO_HerdManager_Expense entity);
        bool Update(AGRO_HerdManager_Expense entity);
        bool Delete(int id);
    }
}