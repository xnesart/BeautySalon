using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using BeautySalon.TG.States;
using Telegram.Bot.Types.ReplyMarkups;
using BeuatySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot;
using BeautySalon.BLL.Models.Output_Models;
using System.Threading;
using BeuatySalon.TG.States.MyRecordsState;

namespace BeuatySalon.TG.States.MasterState
{
    public class MasterMenuState :AbstractState
    {
        List<GetAllOrdersOnTodayForMasterOutputModel> onTodayForMasterOutputModels {  get; set; }
        public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            UserWelcomeHandler userWelcomeHandler = new UserWelcomeHandler();
            userWelcomeHandler.MasterMenu(SingletoneStorage.GetStorage().Client, update, cancellationToken);
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.CallbackQuery.Data == "Текущие записи")
            {
                return new MastersNotesState();
            }
            else if(update.CallbackQuery.Data == "В главное меню")
            {
                return new MasterPasswordState();
            }
            else
            {
                return new MasterPasswordState();
            }
        }
    }
}




