using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace webhooktestagain.Commands
{
    public abstract class BaseCommand
    {
        public abstract string Name { get; }
        public abstract Task ExecuteAsync(Update update);
    }
}
