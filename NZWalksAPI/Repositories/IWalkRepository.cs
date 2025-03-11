using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetWalkByIdAsync(Guid id);
        Task<Walk> CreateWalkAsync(Walk walk);
        Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);
        Task<Walk?> DeleteWalkAsync(Guid id);
    }
}
