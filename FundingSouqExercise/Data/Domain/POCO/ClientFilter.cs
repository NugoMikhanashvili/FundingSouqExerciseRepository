using FundingSouqExercise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Domain.POCO
{
    public class ClientFilter : BaseEntity
    {
        public int UserId { get; set; }
        public int? ClientId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public string PersonalId { get; set; }
        public string ProfilePhoto { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
