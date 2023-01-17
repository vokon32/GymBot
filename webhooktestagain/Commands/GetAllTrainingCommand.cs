using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using webhooktestagain.Data;
using webhooktestagain.Interfaces;
using webhooktestagain.Models;

namespace webhooktestagain.Commands
{
    public class GetAllTrainingCommand : BaseCommand
    {
        private readonly TelegramBotClient _botClient;
        private readonly ITrainingService _trainingService;
        private readonly IUserService _userService;

        public GetAllTrainingCommand(TelegramBot telegramBot, ITrainingService trainingService, IUserService userService)
        {
            _botClient = telegramBot.GetBot().Result;
            _trainingService = trainingService;
            _userService = userService;
        }
        public override string Name => CommandNames.GetAllTrainings;

        public override async Task ExecuteAsync(Update update)
        {
            var user = await _userService.GetOrCreate(update);
            var trainings = await _trainingService.GetAllTrainingsByUserId(user.chatId);

            var message = new StringBuilder("Ваши тренування: \n");

            foreach (var training in trainings)
            {
                message.AppendLine($"Індекс: {training.Id} -  Дата: {training.DateOfTheTraining.ToShortDateString()}");
            }
            message.AppendLine($"Щоб переглянути вправи, введіть індекс тренування");

            await _botClient.SendTextMessageAsync(user.chatId, message.ToString(), ParseMode.Markdown);
        }
    }
}
