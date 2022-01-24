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
            //if (Roles.Count() == 0)
            //{
            //    List<Role> userRoles = new List<Role>()
            //    {
            //        new Role
            //        {
            //            RoleType = "Admin"
            //        },
            //        new Role
            //        {
            //            RoleType = "Guest"
            //        }
            //    };

            //    Roles.AddRange(userRoles);
            //    SaveChanges();
            //}
        }

        DbSet<User> Users { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<SearchParameter> SearchedParameters { get; set; }

    }
}
