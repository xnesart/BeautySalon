using BeautySalon.BLL.Client;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.Models.InputModels;
using BeautySalon.TG;
using BeautySalon.TG.States;
using BeuatySalon.TG.Handlers.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.States.MyRecordsState
{
    public class RescheduleOrderTimeState : AbstractState
    {
       
        public RescheduleOrderTimeState()
        {
            

        }
        public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
        

        }
        public override AbstractState ReceiveMessage(Update update)
        {   
             if(update.CallbackQuery.Data == "Вернуться в главное меню")
             {
                return new StartState();
             }
             else
             {
                UserHandler userHandler = new UserHandler();

                long chatId = update.CallbackQuery.From.Id;
                int? userId = userHandler.GetUserByChatId(chatId);

                UpdateOrderClientByIdInput updateOrderClientByIdInput = new UpdateOrderClientByIdInput()
                {
                    Id = (int)userId,
                    ClientId = (int)userId,
                    IntervalId = this.IntervalId,
                    MasterId = (int)userId,
                };
                OrderHandler orderHandler = new OrderHandler();
                orderHandler.UpdateOrderTimeForClientById(updateOrderClientByIdInput);

             }
             return new StartState();
            

        }

    }

}
