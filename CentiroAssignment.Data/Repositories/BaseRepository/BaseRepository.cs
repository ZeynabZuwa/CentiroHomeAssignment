using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentiroAssignment.Data.Repositories.BaseRepository
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        /// <summary>
        /// Db functions that are general for all classes
        /// </summary>
        protected readonly CentiroAssignmentDbContext _centiroAssignmentDbContext;

        public BaseRepository(CentiroAssignmentDbContext centiroAssignmentDbContext)
        {
            _centiroAssignmentDbContext = centiroAssignmentDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> Id for the entity </param>
        /// <returns> One obbject with the same Id </returns>
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _centiroAssignmentDbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Returns list of all the objects of one type
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _centiroAssignmentDbContext.Set<T>().ToListAsync();
        }



        public async Task<T> AddAsync(T entity)
        {
            await _centiroAssignmentDbContext.Set<T>().AddAsync(entity);
            await _centiroAssignmentDbContext.SaveChangesAsync();

            return entity;
        }

        public T Add(T entity)
        {
            _centiroAssignmentDbContext.Set<T>().Add(entity);
            _centiroAssignmentDbContext.SaveChanges();

            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _centiroAssignmentDbContext.Set<T>().AddRangeAsync(entities);
            await _centiroAssignmentDbContext.SaveChangesAsync();

            return entities;
        }

        public async Task UpdateAsync(T entity)
        {
            _centiroAssignmentDbContext.Update(entity).State = EntityState.Modified;
            await _centiroAssignmentDbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _centiroAssignmentDbContext.UpdateRange(entities);
            await _centiroAssignmentDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _centiroAssignmentDbContext.Set<T>().Remove(entity);
            await _centiroAssignmentDbContext.SaveChangesAsync();
        }
    }
}
