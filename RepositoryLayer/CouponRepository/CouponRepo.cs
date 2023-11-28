using DomainLayer.Data;
using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.ICouponRepository;

namespace RepositoryLayer.CouponRepository
{
    public class CouponRepo<T> : ICouponRepo<T> where T : Coupon
    {
        private readonly AppDbContext _appDbContext;
        private DbSet<T> entities;

        public CouponRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            entities = _appDbContext.Set<T>();
        }

        public T Get(long id)
        {
            return entities.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public void delete(long id)
        {
            var entity = entities.Find(id);
            if (entity != null)
            {
                entities.Remove(entity);
                _appDbContext.SaveChanges();
            }
        }


        public void savechanges()
        {
            _appDbContext.SaveChanges();
        }

        public void update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Update(entity);
            _appDbContext.SaveChanges();
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            _appDbContext.Set<T>().AddRange(entities);
            _appDbContext.SaveChanges();
        }
    }


}




