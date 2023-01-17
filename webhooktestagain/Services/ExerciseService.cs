using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webhooktestagain.Data;
using webhooktestagain.Interfaces;
using webhooktestagain.Models;

namespace webhooktestagain.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext _context;

        public ExerciseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Exercise>> GetExerciseByTrainingId(int trainingId)
        {
            return await _context.Exercises.Where(e => e.trainingId == trainingId).ToListAsync();
        }


    }
}
