using BusinessCardManager.Application.DTOs;
using BusinessCardManager.Application.Interfaces;
using BusinessCardManager.Domain.Entities;
using BusinessCardManager.Domain.Interfaces;
using CsvHelper;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Serialization;

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
    // Export methods
    public async Task<byte[]> ExportBusinessCardsToCsvAsync()
    {
        var selector = BusinessCardToReadDtoSelector();
        var businessCardDtos = await _repository.GetAllAsync(selector);

        // Use CSVHelper to write data to a MemoryStream
        using var memoryStream = new MemoryStream();
        using var streamWriter = new StreamWriter(memoryStream);
        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        await csvWriter.WriteRecordsAsync(businessCardDtos);

        await streamWriter.FlushAsync();

        memoryStream.Position = 0;

        return memoryStream.ToArray();
    }

    public async Task<byte[]> ExportBusinessCardsToXmlAsync()
    {
        var selector = BusinessCardToReadDtoSelector();
        var businessCardDtos = await _repository.GetAllAsync(selector);

        var xmlData = SerializeToXml(businessCardDtos);

        return Encoding.UTF8.GetBytes(xmlData);
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
    private Expression<Func<BusinessCard, BusinessCardReadDto>> BusinessCardToReadDtoSelector()
    {
        return bc => new BusinessCardReadDto
        {
            Id = bc.Id,
            Name = bc.Name,
            Gender = bc.Gender,
            DateOfBirth = bc.DateOfBirth,
            Email = bc.Email,
            Phone = bc.Phone,
            Address = bc.Address
        };
    }
    private static string SerializeToXml(List<BusinessCardReadDto> businessCards)
    {
        var serializer = new XmlSerializer(typeof(List<BusinessCardReadDto>));
        using var stringWriter = new StringWriter();
        serializer.Serialize(stringWriter, businessCards);
        return stringWriter.ToString();
    }
}
