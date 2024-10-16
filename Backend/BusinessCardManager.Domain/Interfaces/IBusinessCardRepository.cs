using BusinessCardManager.Domain.Entities;

namespace BusinessCardManager.Domain.Interfaces;
public interface IBusinessCardRepository
{
    Task<BusinessCard> GetByIdAsync(Guid id);
    Task<IEnumerable<BusinessCard>> GetAllAsync();
    Task AddAsync(BusinessCard businessCard);
    Task DeleteAsync(Guid id);
}
