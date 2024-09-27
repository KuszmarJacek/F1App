using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IDriverRepository DriverRepository { get; }
        IAchievementsRepository AchievementRepository { get; }
        Task<bool> CompleteAsync();
    }
}
