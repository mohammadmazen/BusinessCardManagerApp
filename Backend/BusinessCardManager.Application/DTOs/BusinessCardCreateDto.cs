using BusinessCardManager.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BusinessCardManager.Application.DTOs;
public class BusinessCardCreateDto
{
    [Required]
    public Guid? Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Phone { get; set; }
    public string PhotoBase64 { get; set; }

    [Required]
    public string Address { get; set; }
}
