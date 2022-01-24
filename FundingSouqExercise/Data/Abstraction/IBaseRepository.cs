using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Abstraction
{
    public interface IBaseRepository <TModel> where TModel : class
    {
        int Count { get; }
        IQueryable<TModel> DbSet { get; }
        TModel GetById(object id);
        IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>,
            IOrderedQueryable<TModel>> orderBy = null);
        IQueryable<TModel> GetAll(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>,
            IOrderedQueryable<TModel>> orderBy = null, string includeProperties = "");
        IQueryable<TModel> Filter(Expression<Func<TModel, bool>> predicate);
        IQueryable<TModel> Filter(Expression<Func<TModel, bool>> filter, out int total, int index = 0, int size = 50);
        bool Contains(Expression<Func<TModel, bool>> predicate);
        TModel Find(Expression<Func<TModel, bool>> predicate);
        void Create(TModel entity);
        Task CreateAsync(TModel entity);
        void Delete(object id);
        void Delete(TModel entity);
        void Delete(Expression<Func<TModel, bool>> predicate);
        void Update(TModel entity);
        void Attach(TModel entity);
        void Save();

    }
}