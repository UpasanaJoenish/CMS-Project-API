using DomainLayer.Model;
using RepositoryLayer.ICouponRepository;
using ServiceLayer.ICouponService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CouponService
{
    public class CouponService : ICouponService<createCoupon>
    {
            private readonly ICouponRepo<createCoupon> _CouponRepo;
            public CouponService(ICouponRepo<createCoupon> CouponRepo)
            {
            _CouponRepo = CouponRepo;
            }
            public ICouponRepo<createCoupon>? CouponRepo
        {
                get; private set;
            }

            public void delete(createCoupon entity)
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

            public createCoupon? Get(long id)
            {
                try
                {
                    var obj = _CouponRepo.Get(id);
                    if (obj != null)
                    {
                        return (createCoupon)obj;
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

            public IEnumerable<createCoupon>? GetAll()
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

            public void insert(createCoupon entity)
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

            public void update(createCoupon entity)
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
        }
    }

