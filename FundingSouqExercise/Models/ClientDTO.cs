using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Models
{
    public class ClientDTO
    {
        [Required]
        [MaxLength(60)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(60)]
        public string Lastname { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public int PersonalId { get; set; }
        [Required]
        public string ProfilePhoto { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public int MobileNumber { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int ZipCode { get; set; }
    }
}
