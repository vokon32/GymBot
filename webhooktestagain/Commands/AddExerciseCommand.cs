using Microsoft.AspNetCore.Components.Forms;
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
    public class AddExerciseCommand : BaseCommand
    {
        private readonly TelegramBotClient _botClient;
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly ITrainingService _trainingService;

        public AddExerciseCommand(TelegramBot telegramBot, ApplicationDbContext context, 
            IUserService userService, ITrainingService trainingService)
        {
            _botClient = telegramBot.GetBot().Result;
            _context = context;
            _userService = userService;
            _trainingService = trainingService;
        }
        public override string Name => CommandNames.AddExerciseCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var exerciseName = "";
            var numberofApproaches = 0;
            var numberofExercises = 0;
            var messageCorrection = update.Message.Text.Split(' ', ':');
            for (int i = 0; i < messageCorrection.Length - 1; i++)
            {
                Console.WriteLine(messageCorrection[i]);
                if (!int.TryParse(messageCorrection[i], out int number))
                {
                    exerciseName += messageCorrection[i] + " ";
                }
                else
                {
                    numberofApproaches = number;
                }
            }
            numberofExercises = Convert.ToInt32(messageCorrection[^1]);

            var user = await _userService.GetOrCreate(update);
            var training = await _trainingService.GetTrainingByUserId(user.chatId);
            var exercise = new Exercise()
            {
                Name = exerciseName,
                numberOfApproaches = numberofApproaches,
                numberOfIterations = numberofExercises,
                userId = user.chatId,
                CreatedAt = DateTime.Today,
                trainingId = training.Id
            };
            _context.Exercises.Add(exercise);
            _context.SaveChanges();


            const string message = "Вправа збережена";
            await _botClient.SendTextMessageAsync(user.chatId, message,
                ParseMode.Markdown);
        }
    }
}
