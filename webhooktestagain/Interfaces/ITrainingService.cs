using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using webhooktestagain.Models;

namespace webhooktestagain.Interfaces
{
    public interface ITrainingService
    {
        Task<Training> GetTrainingByUserId(long userId);
        Task<List<Training>> GetAllTrainingsByUserId(long userId);
    }
}
