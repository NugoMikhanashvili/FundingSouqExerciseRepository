using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Domain.POCO
{
    public class ClientAccount : BaseEntity
    {
        public int ClientId { get; set; }
        public string AccoundName { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

    }
}
