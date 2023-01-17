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
    public class TrainingService : ITrainingService
    {
        private readonly ApplicationDbContext _context;

        public TrainingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Training> GetTrainingByUserId(long userId)
        {
            return await _context.Trainings.Where(t => t.userId == userId && t.DateOfTheTraining == DateTime.Today).FirstOrDefaultAsync();
        }
        public async Task<List<Training>> GetAllTrainingsByUserId(long userId)
        {
            return await _context.Trainings.Where(t => t.userId == userId).ToListAsync();
        }
    }
}
