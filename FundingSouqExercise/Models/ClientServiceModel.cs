using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Models
{
    public class ClientServiceModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public int PersonalId { get; set; }
        public string ProfilePhoto { get; set; }
        public string Email { get; set; }
        public int MobileNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }

    }
}
