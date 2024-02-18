using BeautySalon.BLL.Models;
using BeautySalon.TG.States;
using BeuatySalon.TG.Handlers.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States
{
    public class MyRecords : AbstractState
    {

        public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            AddUserByChatIdInputModel model = new AddUserByChatIdInputModel
            {
                ChatId = (int)update.CallbackQuery.From.Id
            };
           
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            throw new NotImplementedException();
        }
    }

}

