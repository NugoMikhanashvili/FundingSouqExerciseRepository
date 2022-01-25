using FundingSouqExercise.Data.Domain.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Domain.POCO
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int UserTypeId { get; set; }

        [ForeignKey("UserTypeId")]
        public UserType UserType { get; set; }

    }
}
