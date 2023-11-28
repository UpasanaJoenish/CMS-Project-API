using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IServicesLayer
{
    public interface ICouponServices<T> where T : class
    {
            IEnumerable<T> GetAll();
            T Get(long Id);
            void insert(T entity);
            void update(T entity);
            void delete(T entity);
            void savechanges();
        void InsertRange(IEnumerable<T> entities);

    }
    }
