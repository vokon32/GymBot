using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace webhooktestagain.Interfaces
{
    public interface ICommandExecutor
    {
        Task ExecuteAsync(Update update);
    }
}
