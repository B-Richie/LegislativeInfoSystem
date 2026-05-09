using LegislativeInfoSystem.Database;
using LegislativeInfoSystem.DTOs;
using LegislativeInfoSystem.Entities;
using LegislativeInfoSystem.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace LegislativeInfoSystem.Services
{
    public class LegislatorService(IDbContextFactory<AppDbContext> dbFactory) : ILegislatorService
    {
        public async Task<List<Legislator>> GetAllAsync()
        {            
            using var db = dbFactory.CreateDbContext();
            return await db.Legislators.ToListAsync();
        }

        public async Task AddAsync(LegislatorDTO dto)
        {
            using var db = dbFactory.CreateDbContext();
            db.Legislators.Add(new Legislator
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Hometown = dto.Hometown
            });
            await db.SaveChangesAsync();
        }
    }
}
