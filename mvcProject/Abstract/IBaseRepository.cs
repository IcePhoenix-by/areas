using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Areas.mvcProject.Abstract
{
   public interface IBaseRepository<T> where T:class
    {
        void add(T item);
        void remove(int id);
        IEnumerable<T> getAll();
        T get(int id);
         void savechange();
        void Update(T item);
    }
}
