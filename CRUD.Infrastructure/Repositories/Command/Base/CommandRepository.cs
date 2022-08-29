using CRUD.Core.Repositories.Command.Base;
using CRUD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infrastructure.Repositories.Command.Base
{
    // Generic command repository class
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        protected readonly ModelContext _context;

        public CommandRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
