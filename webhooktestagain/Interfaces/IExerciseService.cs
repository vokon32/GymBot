using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webhooktestagain.Models;

namespace webhooktestagain.Interfaces
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetExerciseByTrainingId(int trainingId);
    }
}
