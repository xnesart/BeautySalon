using BeautySalon.BLL.Models.Output_Models;
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


namespace BeuatySalon.TG.States.MasterState
{
    public class MastersNotesState : AbstractState
    {
        List<GetAllOrdersOnTodayForMasterOutputModel> onTodayForMasterOutputModels { get; set; }


        public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            OrderHandler orderHandler = new OrderHandler();

            List<GetAllOrdersOnTodayForMasterOutputModel> model = orderHandler.GetAllOrdersOnTodayForMasters();

            this.onTodayForMasterOutputModels = model;

            List<InlineKeyboardButton[]> buttonsRows = new List<InlineKeyboardButton[]>();

            foreach (GetAllOrdersOnTodayForMasterOutputModel order in model)
            {
                InlineKeyboardButton button = InlineKeyboardButton.WithCallbackData(text: $"{order.Date}, {order.Client}, {order.Services} руб", callbackData: order.Date.ToString());
                InlineKeyboardButton[] row = [button];

                buttonsRows.Add(row);
            }

            InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttonsRows);
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                chatId: update.CallbackQuery.From.Id,
                text: $"Ваши записи:",
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken
            );
        }
        public override AbstractState ReceiveMessage(Update update)
        {
            throw new NotImplementedException();
        }
    }
    
}
       

