using FundingSouqExercise.Data.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Abstraction
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public IQueryable<User> GetUsers();
        public IQueryable<User> GetUser(int userId);
    }
}
