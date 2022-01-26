using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Models
{
    public class UserUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        //[MinLength(8)]
        public string Username { get; set; }
        [Required]
        //[MinLength(8)]
        public string Password { get; set; }
        [Required]
        public int UserTypeId { get; set; }

    }
}
