using System.Collections.Generic;

namespace Bootcamps.Avenade.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> List();
        T ReturnById(int id);        
        void Add(T entidade);        
        void Delete(int id);        
        void Update(int id, T entidade);
        int NextId();
    }
}