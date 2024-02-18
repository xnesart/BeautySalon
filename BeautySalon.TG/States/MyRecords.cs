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

          UserHandler userHandler = new UserHandler();
          int Id =userHandler.GetUsersByChatId((int)update.CallbackQuery.From.Id);

            ShowOrder showOrder = new ShowOrder();
            showOrder.GetOrdersByClientId(Id);


        }

        public override AbstractState ReceiveMessage(Update update)
        {
            throw new NotImplementedException();
        }
    }

}

