using BusinessCardManager.Application.DTOs;
using BusinessCardManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCardManager.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusinessCardsController : ControllerBase
{
    private readonly IBusinessCardService _businessCardService;

    public BusinessCardsController(IBusinessCardService businessCardService)
    {
        _businessCardService = businessCardService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BusinessCardReadDto>>> GetBusinessCards()
    {
        var businessCards = await _businessCardService.GetAllBusinessCardsAsync();
        return Ok(businessCards);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BusinessCardReadDto>> GetBusinessCard(Guid id)
    {
        try
        {
            var businessCard = await _businessCardService.GetBusinessCardByIdAsync(id);
            return Ok(businessCard);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBusinessCard([FromBody] BusinessCardCreateDto businessCardDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newId = await _businessCardService.AddBusinessCardAsync(businessCardDto);
        return CreatedAtAction(nameof(GetBusinessCard), new { id = newId }, newId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBusinessCard(Guid id)
    {
        try
        {
            await _businessCardService.DeleteBusinessCardAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
