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

namespace BeuatySalon.TG.States.MyRecordsState
{
    public class RescheduleOrCancelationState : AbstractState
    {
        public RescheduleOrCancelationState(int orderIdToRescheduleOrCancel)
        {
            this.OrderId = orderIdToRescheduleOrCancel;
        }

        public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                      chatId: update.CallbackQuery.From.Id,
                      text: $"Здесь вы можете отменить или перенсти запись",
                      replyMarkup: new InlineKeyboardMarkup(
                       [
                           [InlineKeyboardButton.WithCallbackData(text: "Отменить запись", callbackData: "Отменить запись")],
                           [InlineKeyboardButton.WithCallbackData(text: "Перенести запись", callbackData: "Перенести запись")],
                           [InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню", callbackData: "Вернуться в главное меню")]

                       ]
                   ),
                      cancellationToken: cancellationToken);
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.CallbackQuery.Data == "Вернуться в главное меню")
            {
                return new StartState();
            }
            else
            {
                if (update.CallbackQuery.Data == "Отменить запись")
                {
                    RemoveOrderForClientIdInput removeOrderForClientIdInput = new RemoveOrderForClientIdInput()
                    {
                        OrderId = this.OrderId
                    };
                    OrderHandler orderHandler = new OrderHandler();
                    orderHandler.RemoveOrderForClientByOrderId(removeOrderForClientIdInput);

                }
                if(update.CallbackQuery.Data == "Перенести запись")
                {
                    
                    return new RescheduleOrderTimeState(this.OrderId);
                }

                return new StartState();
            }
        }


    }
}
