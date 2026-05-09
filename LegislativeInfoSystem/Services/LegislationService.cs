using LegislativeInfoSystem.Database;
using LegislativeInfoSystem.DTOs;
using LegislativeInfoSystem.Entities;
using LegislativeInfoSystem.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace LegislativeInfoSystem.Services
{
    public class LegislationService(IDbContextFactory<AppDbContext> dbFactory) : ILegislationService
    {
        public async Task<List<Legislation>> GetAllAsync()
        {
            using var db = dbFactory.CreateDbContext();
            return await db.Legislation
                .Include(l => l.Sponsors)
                .ToListAsync();
        }

        public async Task AddAsync(LegislationDTO dto)
        {
            using var db = dbFactory.CreateDbContext();

            var sponsors = await db.Legislators
                .Where(l => dto.SponsorIds.Contains(l.Id))
                .ToListAsync();

            db.Legislation.Add(new Legislation
            {
                Title = dto.Title,
                LegislationText = dto.LegislationText,
                Sponsors = sponsors
            });

            await db.SaveChangesAsync();
        }
    }
}
