using System.Threading.Tasks;
using Telegram.Bot.Types;
using webhooktestagain.Models;

namespace webhooktestagain.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> GetOrCreate(Update update);
    }
}
