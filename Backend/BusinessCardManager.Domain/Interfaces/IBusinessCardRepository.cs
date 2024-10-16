using BusinessCardManager.Domain.Entities;
using System.Linq.Expressions;

namespace BusinessCardManager.Domain.Interfaces;
public interface IBusinessCardRepository
{
    Task<BusinessCard> GetByIdAsync(Guid id);
    Task<IEnumerable<BusinessCard>> GetAllAsync();
    Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<BusinessCard, TResult>> selector);
    Task AddAsync(BusinessCard businessCard);
    Task DeleteAsync(Guid id);
}
