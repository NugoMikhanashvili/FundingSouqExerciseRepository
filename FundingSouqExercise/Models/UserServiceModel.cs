using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Models
{
    public class UserServiceModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int UserRoleId { get; set; }
        public string UserRoleType { get; set; }

    }
}
