using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using webhooktestagain.Data;
using webhooktestagain.Interfaces;

namespace webhooktestagain.Commands
{
    public class StartCommand : BaseCommand
    {
        private readonly IUserService _userService;
        private readonly TelegramBotClient _botClient;
        public StartCommand(IUserService userService, TelegramBot telegramBot)
        {
            _userService = userService;
            _botClient = telegramBot.GetBot().Result;
        }
        public override string Name => CommandNames.StartCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var user = await _userService.GetOrCreate(update);
            var inlineKeyboard = new ReplyKeyboardMarkup(new[]
            {
                new[]
                {
                    new KeyboardButton("/add-training")
                    {
                        Text = "Записати тренування"
                    },
                    new KeyboardButton("/show-trainings")
                    {
                        Text = "Передивитись усі тренування"

                    }
                }
            });


            await _botClient.SendTextMessageAsync(user.chatId, "Привіт, це бот, який дозволить вести журнал твоїх тренувань!",
                ParseMode.Markdown, replyMarkup: inlineKeyboard);
        }
    }
}
