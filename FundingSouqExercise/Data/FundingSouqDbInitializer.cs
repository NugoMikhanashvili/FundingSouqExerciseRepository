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
            var userRoles = new List<UserType>
            {
                new UserType
                {
                    Type = "Admin"
                },

                new UserType
                {
                    Type = "Guest"
                }
            };

            context.Database.EnsureCreated();
            if (!context.UserTypes.Any(x=>x.Type == "Admin") || !context.UserTypes.Any(x => x.Type == "Guest"))
            {
                foreach (var role in userRoles)
                {
                    context.UserTypes.AddRange(userRoles);
                }
            }
            context.SaveChanges();
        }
    }
}