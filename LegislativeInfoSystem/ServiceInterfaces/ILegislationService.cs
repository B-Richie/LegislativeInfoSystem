using LegislativeInfoSystem.DTOs;
using LegislativeInfoSystem.Entities;

namespace LegislativeInfoSystem.ServiceInterfaces
{
    public interface ILegislationService
    {
        Task<List<Legislation>> GetAllAsync();
        Task AddAsync(LegislationDTO dto);
    }
}
