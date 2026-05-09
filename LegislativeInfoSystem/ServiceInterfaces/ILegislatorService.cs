using LegislativeInfoSystem.DTOs;
using LegislativeInfoSystem.Entities;

namespace LegislativeInfoSystem.ServiceInterfaces
{
    public interface ILegislatorService
    {
        Task<List<Legislator>> GetAllAsync();
        Task AddAsync(LegislatorDTO dto);
    }
}
