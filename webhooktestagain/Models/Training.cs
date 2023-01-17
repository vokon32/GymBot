using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webhooktestagain.Models
{
    public class Training : BaseEntity
    {
        public DateTime DateOfTheTraining { get; set; } = DateTime.UtcNow.Date;

        public List<Exercise>? Exercises { get; set; }
        public long? userId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
