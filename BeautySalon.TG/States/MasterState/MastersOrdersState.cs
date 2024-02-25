using BeautySalon.BLL.Models.Output_Models;
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


namespace BeuatySalon.TG.States.MasterState
{
    public class MastersOrdersState : AbstractState
    {
        List<GetOrdersByMasterIdOutputModel> onTodayForMasterOutputModels { get; set; }

        public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            OrderHandler orderHandler = new OrderHandler();
            UserHandler userHandler = new UserHandler();
            int? userId = userHandler.GetUserByChatId(chatId);

            List<GetOrdersByMasterIdOutputModel> model = orderHandler.GetOrdersByMasterId((int)userId);

            this.onTodayForMasterOutputModels = model;

            string text = "Ваши записи:\n";

            foreach (GetOrdersByMasterIdOutputModel order in model)
            {
                text += $"{order.Client.UserName},{order.Client.Name} ,{order.IntervalTitle},{order.Services.Title},{order.Services.Price},{order.Services.Duration}.\n";
            }
            
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                chatId: update.CallbackQuery.From.Id,
                text: text,
                cancellationToken: cancellationToken
            );

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                chatId: update.CallbackQuery.From.Id,
                text:$"Вернуться в главное меню",
                replyMarkup: new InlineKeyboardMarkup(
                        [
                            [InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню", callbackData: "Вернуться в главное меню")],
                        ]
                    ),
                    cancellationToken: cancellationToken
            );
        }
        
        public override AbstractState ReceiveMessage(Update update)
        {
            if(update.CallbackQuery.Data == "Вернуться в главное меню")
            {
                return new MasterState();
            }
            return new MasterState();
        }
    }
}
       

