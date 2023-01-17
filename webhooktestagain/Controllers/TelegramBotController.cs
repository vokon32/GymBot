using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using webhooktestagain.Interfaces;


namespace webhooktestagain.Controllers
{
    [ApiController]
    [Route("api/message/update")]
    public class TelegramBotController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;

        public TelegramBotController(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] object update)
        {
            // /start => register user

            var upd = JsonConvert.DeserializeObject<Update>(update.ToString());

            if (upd?.Message?.Chat == null && upd?.CallbackQuery == null)
            {
                return Ok();
            }

            try
            {
                await _commandExecutor.ExecuteAsync(upd);
                return Ok();
            }
            catch 
            {
                return Ok();
            }

        }
    }
}
