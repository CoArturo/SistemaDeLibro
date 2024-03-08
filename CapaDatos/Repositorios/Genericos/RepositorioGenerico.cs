using CapaDatos.Contexto;
using CapaDatos.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios.Genericos
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly SistemaLibrosContext _contexto;
        private readonly DbSet<T> _DbSet;
        private List<T> data = new List<T>();

        public RepositorioGenerico(SistemaLibrosContext contexto)
        {
            _contexto = contexto;
            _DbSet = _contexto.Set<T>();
        }

        public T Create(T entity)
        {
            _DbSet.Add(entity);
            _contexto.SaveChanges();
            return entity;
        }

        public virtual void Delete(int id)
        {
            var entity = _DbSet.Find(id);
            if (entity != null)
            {
                _DbSet.Remove(entity);
            }
            _contexto.SaveChanges();
        }

        public T Get(int id)
        {
            var entity = _DbSet.Find(id);
            _contexto.SaveChanges();
            return entity;
        }

        public List<T> GetAll() => _DbSet.ToList();

        public List<T> GetByCondition(Expression<Func<T, bool>> condition)
        {
            return _DbSet.Where(condition).ToList();
        }

        public T Update(T entity)
        {
            _contexto.Entry(entity).State = EntityState.Modified;
            _contexto.SaveChanges();
            return entity;
        }
    }
}
