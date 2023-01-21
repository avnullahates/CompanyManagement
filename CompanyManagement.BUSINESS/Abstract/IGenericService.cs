using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BUSINESS.Abstract
{
    public interface IGenericService<T>
    {
        bool Add(T item);

        bool Add(List<T> item);

        bool Update(T item);

        bool Remove(int id);

        T GetByID(int id);

        List<T> GetAll();
        
    }
}
