using BusinessCardManager.Domain.Entities;
using BusinessCardManager.Domain.Enums;

namespace BusinessCardManager.Domain.Interfaces;
public interface IBusinessCardRepository
{
    Task<BusinessCard> GetByIdAsync(int id);
    Task<IEnumerable<BusinessCard>> GetAllAsync();
    Task AddAsync(BusinessCard businessCard);
    Task UpdateAsync(BusinessCard businessCard);
    Task DeleteAsync(int id);
}
