using FundingSouqExercise.Data.Domain.POCO;
using FundingSouqExercise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data
{
    public class FoundingSouqExerciseDbContext : DbContext
    {
        public FoundingSouqExerciseDbContext()
        {

        }

        public FoundingSouqExerciseDbContext(string connectionString)
        {
            
        }
        public FoundingSouqExerciseDbContext(DbContextOptions<FoundingSouqExerciseDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<SearchedParameter> SearchedParameters { get; set; }
        public DbSet<ClientAccount> ClientAccounts { get; set; }

    }
}
