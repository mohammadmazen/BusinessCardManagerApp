using BusinessCardManager.Application.DTOs;
using BusinessCardManager.Application.Interfaces;
using BusinessCardManager.Domain.Entities;
using BusinessCardManager.Domain.Interfaces;

namespace BusinessCardManager.Application.Services;
public class BusinessCardService : IBusinessCardService
{
    private readonly IBusinessCardRepository _repository;

    public BusinessCardService(IBusinessCardRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> AddBusinessCardAsync(BusinessCardCreateDto businessCardDto)
    {
        var businessCard = MapDtoToEntity(businessCardDto);
        await _repository.AddAsync(businessCard);
        return businessCard.Id;
    }

    public async Task DeleteBusinessCardAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<BusinessCardReadDto>> GetAllBusinessCardsAsync()
    {
        var businessCards = await _repository.GetAllAsync();
        return businessCards.Select(MapEntityToReadDto);
    }

    public async Task<BusinessCardReadDto> GetBusinessCardByIdAsync(Guid id)
    {
        var businessCard = await _repository.GetByIdAsync(id);
        if (businessCard == null)
        {
            throw new KeyNotFoundException($"Business card with ID {id} was not found.");
        }
        return MapEntityToReadDto(businessCard);
    }

    // Mapping methods
    private BusinessCardReadDto MapEntityToReadDto(BusinessCard entity)
    {
        return new BusinessCardReadDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Gender = entity.Gender,
            DateOfBirth = entity.DateOfBirth,
            Email = entity.Email,
            Phone = entity.Phone,
            PhotoBase64 = entity.PhotoBase64,
            Address = entity.Address
        };
    }

    private BusinessCard MapDtoToEntity(BusinessCardCreateDto dto)
    {
        return new BusinessCard
        {
            Name = dto.Name,
            Gender = dto.Gender,
            DateOfBirth = dto.DateOfBirth,
            Email = dto.Email,
            Phone = dto.Phone,
            PhotoBase64 = dto.PhotoBase64,
            Address = dto.Address
        };
    }
}
