using CompanyManagement.BUSINESS.Abstract;
using CompanyManagement.ENTITIES.Entities;
using CompanyManagement.REPOSITORIES.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BUSINESS.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : BaseEntitiy
    {
        private readonly IGenericRepository<T> _repository;

        public GenericManager(IGenericRepository<T> repository) 
        {
            _repository = repository;
        }

        public bool Add(T item)
        {
            return _repository.Add(item);
        }

        public bool Add(List<T> item)
        {
            return _repository.Add(item);
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetByID(int id)
        {
            return _repository.GetByID(id);
        }

        public bool Remove(int id)
        {
            if (id <= 0)
                return false;
            else
                return _repository.Remove(id);
        }

        public bool Update(T item)
        {
            if (item == null)
                return false;
            else
                return _repository.Update(item);
        }
    }
}
