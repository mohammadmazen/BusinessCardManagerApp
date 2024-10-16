using BusinessCardManager.Domain.Enums;

namespace BusinessCardManager.Application.DTOs;
public class BusinessCardReadDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }
}
