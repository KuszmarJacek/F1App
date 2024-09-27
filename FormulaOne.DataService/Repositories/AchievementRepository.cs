using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories
{
    public class AchievementRepository : GenericRepository<Achievement>, IAchievementsRepository
    {
        public AchievementRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
        {

            try
            {
                return await _dbSet.FirstOrDefaultAsync(d => d.DriverId == driverId); 

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetDriverAchievementAsync function error", typeof(AchievementRepository));
                throw;
            }
        }
        public override async Task<IEnumerable<Achievement>> All()
        {
            try
            {
                return await _dbSet.Where(driver => driver.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(driver => driver.AddedDate)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(AchievementRepository));
                throw;
            }
        }
        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(d => d.Id == id);
                if (result == null)
                {
                    return false;
                }
                result.Status = 0;
                result.UpdatedDate = DateTime.UtcNow;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task<bool> Update(Achievement achievement)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(a => a.Id == achievement.Id);
                if (result == null)
                {
                    return false;
                }
                result.UpdatedDate = DateTime.UtcNow;
                result.FastestLap = achievement.FastestLap;
                result.PolePosition = achievement.PolePosition;
                result.RaceWins = achievement.RaceWins;
                result.WorldChampionship = achievement.WorldChampionship;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(AchievementRepository));
                throw;
            }
        }
    }
}
