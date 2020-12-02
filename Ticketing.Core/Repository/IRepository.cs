using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Core.Repository
{
    public interface IRepository<T> where T: class
    {
        //  - tutti gli oggetti T
        //repository.Get()

        // - tutti gli oggetti T con proprietà Name = 'Roberto'
        //repository.Get(t => t.Name == 'Roberto') 

        IEnumerable<T> Get(Func<T, bool> filter = null);
        T GetByID(int id);
        bool Add(T item);
        bool Update(T item);
        bool DeleteById(int id);
    }
}
