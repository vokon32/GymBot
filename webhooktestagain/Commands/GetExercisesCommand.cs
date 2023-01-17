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
    public class GetExercisesCommand : BaseCommand
    {
        private readonly TelegramBotClient _botClient;
        private readonly IExerciseService _exerciseService;
        private readonly IUserService _userService;

        public GetExercisesCommand(TelegramBot telegramBot, IExerciseService exerciseService, IUserService userService)
        {
            _botClient = telegramBot.GetBot().Result;
            _exerciseService = exerciseService;
            _userService = userService;
        }
        public override string Name => CommandNames.GetExercies;

        public override async Task ExecuteAsync(Update update)
        {
            var user = await _userService.GetOrCreate(update);
            try
            {

                var exercises = await _exerciseService.GetExerciseByTrainingId(Convert.ToInt32(update.Message.Text));

                var message = new StringBuilder("Ваші вправи: \n");

                foreach (var exercise in exercises)
                {
                    message.AppendLine($"Назва: {exercise.Name} -  кількість підходів: {exercise.numberOfApproaches} - кількість повторювань - {exercise.numberOfIterations}");
                }
                await _botClient.SendTextMessageAsync(user.chatId, message.ToString(), ParseMode.Markdown);
            }
            catch
            {
                var message = "Нічого не знайдено. Спробуйте ввести індекс ще раз";
                await _botClient.SendTextMessageAsync(user.chatId, message.ToString(), ParseMode.Markdown);
            }
        }
    }
}
