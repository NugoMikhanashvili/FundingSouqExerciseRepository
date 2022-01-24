using FundingSouqExercise.Data.Abstraction;
using FundingSouqExercise.Data.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DbContext dbContext;

        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<User> GetUser(int userId)
        {
            return dbContext.Set<User>().Where(u => u.Id == userId).Include(u => u.Role);
        }
        public IQueryable<User> GetUsers()
        {
            return GetAll();
        }
    }
}
