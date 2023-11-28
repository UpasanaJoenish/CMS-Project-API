using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ICouponService
{
    public interface ICouponService<T> where T : class
    {
            IEnumerable<T> GetAll();
            T Get(long Id);
            void insert(T entity);
            void update(T entity);
            void delete(T entity);

            void savechanges();
        }
    }
