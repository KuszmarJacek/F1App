using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public readonly AppDbContext _context;
        public IDriverRepository DriverRepository { get; }
        public IAchievementsRepository AchievementRepository { get; }
        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger = loggerFactory.CreateLogger("logs");
            DriverRepository = new DriverRepository(_context, logger);
            AchievementRepository = new AchievementRepository(_context, logger);
        }
        public async Task<bool> CompleteAsync()
        {
            var result = await _context.SaveChangesAsync();
            // if more than 0 success, else fail
            return result > 0;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
