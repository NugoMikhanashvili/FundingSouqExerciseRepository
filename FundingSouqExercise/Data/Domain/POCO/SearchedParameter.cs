using FundingSouqExercise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Domain.POCO
{
    public class SearchedParameter : BaseEntity
    {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
