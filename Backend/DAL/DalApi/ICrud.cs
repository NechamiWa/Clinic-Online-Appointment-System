using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface ICrud<T>
    {
        void Create(T item);
        Task<List<T>> Read();
        void Update(T item);
        void Delete(T item);
    }
}
