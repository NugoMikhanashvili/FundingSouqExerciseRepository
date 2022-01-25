using FundingSouqExercise.Data.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data
{
    public class FundingSouqDbInitializer
    {
        public static void SeedUserRoles(FoundingSouqExerciseDbContext context)
        {
            var userRoles = new List<Role>
            {
                new Role
                {
                    RoleType = "Admin"
                },

                new Role
                {
                    RoleType = "Guest"
                }
            };

            context.Database.EnsureCreated();
            if (!context.Roles.Any(x=>x.RoleType == "Admin") || !context.Roles.Any(x => x.RoleType == "Guest"))
            {
                foreach (var role in userRoles)
                {
                    context.Roles.AddRange(userRoles);
                }
            }
            context.SaveChanges();
        }
    }
}