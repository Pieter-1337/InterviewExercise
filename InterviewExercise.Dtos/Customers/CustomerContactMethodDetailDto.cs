using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InterviewExercise.Dtos.Customers
{
    public class CustomerContactMethodDetailDto: CustomerContactMethodDto
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public override string TypeAsString { get; }
    }
}
