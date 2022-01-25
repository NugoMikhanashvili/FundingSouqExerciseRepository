using FundingSouqExercise.Data.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Domain.POCO
{
    public class UserType : BaseEntity
    {
        public string Type { get; set; }
    }
}
