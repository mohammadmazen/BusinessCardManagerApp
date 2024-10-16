using BusinessCardManager.Application.DTOs;

namespace BusinessCardManager.Application.Interfaces;
public interface IBusinessCardService
{
    Task<BusinessCardReadDto> GetBusinessCardByIdAsync(Guid id);
    Task<IEnumerable<BusinessCardReadDto>> GetAllBusinessCardsAsync();
    Task<Guid> AddBusinessCardAsync(BusinessCardCreateDto businessCardDto);
    Task DeleteBusinessCardAsync(Guid id);
}
