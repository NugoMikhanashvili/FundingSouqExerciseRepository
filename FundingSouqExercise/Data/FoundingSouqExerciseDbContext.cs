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
        public DbSet<Role> Roles { get; set; }
        public DbSet<SearchedParameter> SearchedParameters { get; set; }

    }
}
