using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webhooktestagain.Models;

namespace webhooktestagain.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Training> Trainings { get; set; }
    }
}
