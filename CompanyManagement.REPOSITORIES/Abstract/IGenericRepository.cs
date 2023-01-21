using CompanyManagement.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.REPOSITORIES.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntitiy
    {

        bool Add(T item);

        bool Add(List<T> item);

        bool Update(T item);    

        bool Remove(int id);     

        T GetByID(int id);        

        List<T> GetAll();  

        int Save();


    }
}
