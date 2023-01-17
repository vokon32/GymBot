using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webhooktestagain.Models
{
    public class Exercise : BaseEntity
    {
        public string Name { get; set; }
        public int numberOfApproaches { get; set; }
        public int numberOfIterations { get; set; }

        [ForeignKey("Training")]
        public long trainingId { get; set; }
        public Training Training { get; set; }
        public long? userId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
