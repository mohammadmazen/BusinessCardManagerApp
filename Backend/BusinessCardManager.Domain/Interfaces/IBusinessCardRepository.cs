using BusinessCardManager.Domain.Entities;

namespace BusinessCardManager.Domain.Interfaces;
public interface IBusinessCardRepository
{
    Task<IEnumerable<BusinessCard>> GetBusinessCardsAsync();
    Task<BusinessCard> GetBusinessCardByIdAsync(Guid id);
    Task<BusinessCard> AddBusinessCardAsync(BusinessCard businessCard);
    Task<BusinessCard> UpdateBusinessCardAsync(BusinessCard businessCard);
    Task<BusinessCard> DeleteBusinessCardAsync(Guid id);
}
