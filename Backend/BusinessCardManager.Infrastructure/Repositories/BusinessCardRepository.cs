using BusinessCardManager.Domain.Entities;
using BusinessCardManager.Domain.Interfaces;
using BusinessCardManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
    public async Task DeleteAsync(Guid id)
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
        return await _context.BusinessCards
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<BusinessCard> GetByIdAsync(Guid id)
    {
        var entity = await _context.BusinessCards.FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Business card with ID {id} was not found.");
        }
        return entity;
    }
    public async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<BusinessCard, TResult>> selector)
    {
        return await _context.BusinessCards
            .AsNoTracking()
            .Select(selector)
            .ToListAsync();
    }
}
