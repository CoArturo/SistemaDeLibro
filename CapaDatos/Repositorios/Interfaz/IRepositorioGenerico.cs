using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios.Interfaz
{
    public interface IRepositorioGenerico<T> where T : class
    {
        T Get(int id);
        List<T> GetAll();
        List<T> GetByCondition(Expression<Func<T, bool>> condition);
        T Create(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
