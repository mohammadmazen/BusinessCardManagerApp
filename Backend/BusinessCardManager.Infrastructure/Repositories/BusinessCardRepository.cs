using BusinessCardManager.Domain.Entities;
using BusinessCardManager.Domain.Enums;
using BusinessCardManager.Domain.Interfaces;
using BusinessCardManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BusinessCardManager.Infrastructure.Repositories;
public class BusinessCardRepository : IBusinessCardRepository
{
    private readonly ApplicationDbContext _context;

    public BusinessCardRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(BusinessCard businessCard)
    {
        await _context.BusinessCards.AddAsync(businessCard);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var businessCard = await _context.BusinessCards.FindAsync(id);
        if (businessCard != null)
        {
            _context.BusinessCards.Remove(businessCard);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<BusinessCard>> GetAllAsync()
    {
        return await _context.BusinessCards.ToListAsync();
    }
    public async Task<BusinessCard> GetByIdAsync(int id)
    {
        var entity = await _context.BusinessCards.FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Business card with ID {id} was not found.");
        }
        return entity;
    }
    public async Task UpdateAsync(BusinessCard businessCard)
    {
        _context.BusinessCards.Update(businessCard);
        await _context.SaveChangesAsync();
    }
}
