using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BeuatySalon.TG.States.MasterState
{
    public class MasterState : AbstractState
    {
        public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            UserWelcomeHandler userWelcomeHandler = new UserWelcomeHandler();
            userWelcomeHandler.WelcomeMaster(SingletoneStorage.GetStorage().Client, update, cancellationToken);


        }
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery && UpdateType.CallbackQuery != null)
            {
                if (update.CallbackQuery.Data.ToLower() == "ввести пароль")
                {
                    return new MasterPasswordState();
                }
                if (update.CallbackQuery.Data.ToLower() == "вернуться в главное меню")
                {
                    return new StartState();
                }

            }

            return this;
        }

    }
}
