using BeautySalon.BLL.Client;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.Models.InputModels;
using BeautySalon.TG;
using BeautySalon.TG.States;
using BeautySalon.TG.Handlers.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using BeautySalon.BLL;

namespace BeuatySalon.TG.States.MyRecordsState
{
    public class RescheduleOrderTimeState : AbstractState
    {
        public RescheduleOrderTimeState(int orderId)
        {
            OrderId = orderId ; 
          
        }
        public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            ShiftsHandler shiftsHandler = new ShiftsHandler();
            shiftsHandler.ChoseShift(SingletoneStorage.GetStorage().Client, update, cancellationToken);

        }

        public override AbstractState ReceiveMessage(Update update)
        {   
             if(update.CallbackQuery.Data == "Вернуться в главное меню")
             {
                return new StartState();
             }
             else
             {
                int newShiftId = int.Parse(update.CallbackQuery.Data);

                return new UpdateIntervalState(newShiftId,this.OrderId);
             }
        }
    }
}
  