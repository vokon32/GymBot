using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using webhooktestagain.Commands;
using webhooktestagain.Data;
using webhooktestagain.Interfaces;

namespace webhooktestagain.Services
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly List<BaseCommand> _commands;
        private BaseCommand _lastCommand;
        public CommandExecutor(IServiceProvider serviceProvider)
        {
            _commands = serviceProvider.GetServices<BaseCommand>().ToList();
        }
        public async Task ExecuteAsync(Update update)
        {
            if (update.Message != null && update.Message.Text.Contains(CommandNames.StartCommand))
            {
                await ExecuteCommand(CommandNames.StartCommand, update);
                return;
            }

            if (update.Message != null && update.Message.Text.Contains(CommandNames.GetAllTrainings))
            {
                await ExecuteCommand(CommandNames.GetAllTrainings, update);
                return;
            }

            if (update.Message != null && update.Message.Text.Contains(CommandNames.AddTrainingCommand))
            {
                await ExecuteCommand(CommandNames.AddTrainingCommand, update);
                return;
            }

            switch (_lastCommand?.Name)
            {
                case CommandNames.AddTrainingCommand:
                    {
                        await ExecuteCommand(CommandNames.AddExerciseCommand, update);
                        break;
                    }
                case CommandNames.AddExerciseCommand:
                    {
                        await ExecuteCommand(CommandNames.AddExerciseCommand, update);
                        break;
                    }
                case CommandNames.GetAllTrainings:
                    {
                        await ExecuteCommand(CommandNames.GetExercies, update);
                        break;
                    }
            }
        }

        private async Task ExecuteCommand(string commandName, Update update)
        {
            _lastCommand = _commands.First(c => c.Name == commandName);
            await _lastCommand.ExecuteAsync(update);
        }
    }
}
