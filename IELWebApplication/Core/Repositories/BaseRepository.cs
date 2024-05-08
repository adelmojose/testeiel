using IELCadastroEstudante.Core.Data;
using IELCadastroEstudante.Core.Data.Entity;
using IELCadastroEstudante.Core.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace IELCadastroEstudante.Core.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DataBaseContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            try
            {
                _dbContext?.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> List()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return _dbSet.ToList();
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            SaveChanges();
            return entity;
        }
        private int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
