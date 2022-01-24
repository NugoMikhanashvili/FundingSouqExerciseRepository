using FundingSouqExercise.Data.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Implementation
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        protected readonly DbContext _dbContext;
        public virtual int Count
        {
            get { return _dbContext.Set<TModel>().Count(); }
        }
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        protected T GetContext<T>() where T
            : class
        {
            return (T)Convert.ChangeType(_dbContext, Type.GetTypeCode(typeof(T)));
        }
        public virtual IQueryable<TModel> DbSet => _dbContext.Set<TModel>();
        public virtual TModel GetById(object id)
        {
            return _dbContext.Set<TModel>().Find(id);
        }
        public virtual IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null)
        {
            IQueryable<TModel> query = _dbContext.Set<TModel>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return orderBy != null ? orderBy(query).AsQueryable() : query.AsQueryable();
        }
        public virtual IQueryable<TModel> GetAll(Expression<Func<TModel, bool>> filter = null, 
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TModel> query = _dbContext.Set<TModel>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }
        public virtual IQueryable<TModel> Filter(Expression<Func<TModel, bool>> predicate)
        {
            return _dbContext.Set<TModel>().Where(predicate).AsQueryable();
        }
        public virtual IQueryable<TModel> Filter(Expression<Func<TModel, bool>> filter, out int total, int index = 0, int size = 50)
        {
            var skipCount = index * size;
            var resetSet = filter != null ? _dbContext.Set<TModel>().Where(filter).AsQueryable()
                : _dbContext.Set<TModel>().AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }
        public bool Contains(Expression<Func<TModel, bool>> predicate)
        {
            return _dbContext.Set<TModel>().Any(predicate);
        }
        public virtual TModel Find(Expression<Func<TModel, bool>> predicate)
        {
            return _dbContext.Set<TModel>().FirstOrDefault(predicate);
        }
        public virtual void Create(TModel entity)
        {
            _dbContext.Set<TModel>().Add(entity);
        }
        public virtual async Task CreateAsync(TModel entity)
        {
            await _dbContext.Set<TModel>().AddAsync(entity);
        }
        public virtual void Delete(object id)
        {
            var entityToDelete = GetById(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(TModel entity)
        {
            _dbContext.Set<TModel>().Remove(entity);
        }
        public virtual void Delete(Expression<Func<TModel, bool>> predicate)
        {
            var entitiesToDelete = Filter(predicate);
            foreach (var entity in entitiesToDelete)
            {
                _dbContext.Set<TModel>().Remove(entity);
            }
        }
        public virtual void Update(TModel entity)
        {
            _dbContext.Set<TModel>().Update(entity);
        }
        public void Attach(TModel entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
