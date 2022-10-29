using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Data;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BudgetFaztContext _repository;

        protected BaseRepository(BudgetFaztContext repository)
        {
            _repository = repository;
        }

        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            try
            {
                await _repository.Set<TEntity>().AddAsync(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteAsync(int guid)
        {
            try
            {
                var data = await GetAsync(guid);
                _repository.Set<TEntity>().Remove(data);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(_repository.Set<TEntity>());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity> GetAsync(int guid)
        {
            try
            {
                var data = await _repository.Set<TEntity>()
                    .FindAsync(guid);

                if (data is null)
                {
                    throw new Exception("Couldn't found that register in the db");
                }

                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _repository.Entry(entity).State = EntityState.Modified;
                _repository.Set<TEntity>().Update(entity);
                await _repository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> where)
        {
            List<TEntity> entities = new List<TEntity>();
            Func<TEntity, bool> comparator = where.Compile();

            foreach (var item in (await Task.FromResult(_repository.Set<TEntity>())))
            {
                if (comparator(item))
                {
                    entities.Add(item);
                }
            }
            return entities;
        }
    }
}