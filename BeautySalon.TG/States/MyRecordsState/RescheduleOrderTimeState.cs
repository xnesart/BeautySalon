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
        public RescheduleOrderTimeState()
        {
            OrderId = this.OrderId; 
            ServiceId = this.ServiceId;
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
                ServiceId = int.Parse(update.CallbackQuery.Data);
                //Передаем в стейт интервалов выбранный айди смены.
                return new UpdateIntervalState(ShiftId,OrderId);
             }
             //    UserHandler userHandler = new UserHandler();
             //
             //    long chatId = update.CallbackQuery.From.Id;
             //    int? userId = userHandler.GetUserByChatId(chatId);
             //
             //    UpdateOrderClientByIdInput updateOrderClientByIdInput = new UpdateOrderClientByIdInput()
             //    {
             //        Id = (int)userId,
             //        ClientId = (int)userId,
             //        IntervalId = this.IntervalId,
             //        MasterId = (int)userId,
             //    };
             //    OrderHandler orderHandler = new OrderHandler();
             //    orderHandler.UpdateOrderTimeForClientById(updateOrderClientByIdInput);
             // }
             return new StartState();
        }
    }
}
  