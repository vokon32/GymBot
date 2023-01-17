using Microsoft.EntityFrameworkCore;
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
using webhooktestagain.Models;

namespace webhooktestagain.Commands
{
    public class AddTrainingCommand : BaseCommand
    {
        private readonly TelegramBotClient _botClient;
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly ITrainingService _trainingService;

        public AddTrainingCommand(TelegramBot telegramBot, ApplicationDbContext context,
            IUserService userService, ITrainingService trainingService)
        {
            _botClient = telegramBot.GetBot().Result;
            _context = context;
            _userService = userService;
            _trainingService = trainingService;
        }
        public override string Name => CommandNames.AddTrainingCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var user = await _userService.GetOrCreate(update);
            var testTraining = await _trainingService.GetTrainingByUserId(user.chatId);
            if (testTraining == null)
            {
                var training = new Training()
                {
                    DateOfTheTraining = DateTime.UtcNow.Date,
                    userId = user.chatId
                };
                _context.Trainings.Add(training);
                _context.SaveChanges();
            }


            const string message = "Для додавання вправи напишіть назву вправи, кількість підходів та повторень в форматі: \n" +
                                   "Жим лежачи  4:10 \n" +
                                   "Присідання  3:45";
            await _botClient.SendTextMessageAsync(user.chatId, message,
                ParseMode.Markdown);
        }
    }
}
