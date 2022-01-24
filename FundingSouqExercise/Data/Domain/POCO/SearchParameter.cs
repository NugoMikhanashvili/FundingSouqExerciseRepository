using FundingSouqExercise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Domain.POCO
{
    public class SearchParameter : BaseEntity
    {
        public string Parameter { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }


        ICollection<User> Users { get; set; }
    }
}
