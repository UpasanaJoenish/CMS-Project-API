using DomainLayer.Data;
using DomainLayer.Model;
using RepositoryLayer.ICouponRepository;
using ServicesLayer.IServicesLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesLayer.ServicesLayer
{
    public class CouponServices : ICouponServices<Coupon>
    {
        private readonly ICouponRepo<Coupon> _CouponRepo;
        private readonly AppDbContext _dbContext; 

        public CouponServices(ICouponRepo<Coupon> CouponRepo, AppDbContext dbContext)
        {
            _CouponRepo = CouponRepo;
            _dbContext = dbContext;
        }

        public ICouponRepo<Coupon>? CouponRepo
        {
            get; private set;
        }

        public void delete(Coupon entity)
        {
            try
            {
                if (entity != null)
                {
                    _CouponRepo.delete(entity);
                    _CouponRepo.savechanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Coupon? Get(long id)
        {
            try
            {
                var obj = _CouponRepo.Get(id);
                if (obj != null)
                {
                    return (Coupon)obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Coupon>? GetAll()
        {
            try
            {
                var obj = _CouponRepo.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void insert(Coupon entity)
        {
            try
            {
                if (entity != null)
                {
                    _CouponRepo.insert(entity);
                    _CouponRepo.savechanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void savechanges()
        {
            throw new NotImplementedException();
        }

        public void update(Coupon entity)
        {
            try
            {
                if (entity != null)
                {
                    _CouponRepo.update(entity);
                    _CouponRepo.savechanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertRange(IEnumerable<Coupon> entities)
        {
            _dbContext.Coupons.AddRange(entities);
            _dbContext.SaveChanges();
        }
    }
}
