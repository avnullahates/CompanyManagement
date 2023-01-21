using CompanyManagement.ENTITIES.Entities;
using CompanyManagement.REPOSITORIES.Abstract;
using CompanyManagement.REPOSITORIES.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CompanyManagement.REPOSITORIES.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntitiy
    {

        private readonly CompanyManagerDBContext _context;

        public GenericRepository(CompanyManagerDBContext context)
        {
            _context = context;
        }




        public bool Add(T item)
        {
            try
            {
                _context.Set<T>().Add(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Add(List<T> item)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    _context.Set<T>().AddRange(item);
                    ts.Complete();
                    return Save() > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public bool Remove(int id)
        {
            try
            {
                _context.Remove(id);
                return Save() > 0;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(T item)
        {
            try
            {
                _context.Set<T>().Update(item);
                return Save() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
