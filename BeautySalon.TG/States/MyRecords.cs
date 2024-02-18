using BeautySalon.BLL.Models;
using BeautySalon.BLL.OrdersForClientById;
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

namespace BeuatySalon.TG.States
{
    public class MyRecords : AbstractState
    {
        public override async void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            UserHandler userHandler = new UserHandler();
            OrderHandler orderHandler = new OrderHandler();

            int? userId = userHandler.GetUserByChatId(chatId);

            if (userId != null)
            {
                List<OrdersForClientByIdOutputModel> orders = orderHandler.GetOrdersByClientId((int)userId);
                List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
                orders.ForEach(order =>
                {
                    buttons.Add([new InlineKeyboardButton(text: order.Service.Title)]);
                });

                InlineKeyboardMarkup inlineKeyboard = new(buttons);

                await SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                   chatId: update.Message.From.Id,
                   text: $"Добро пожаловать к виртуальному помощнику сети салонов красоты \"Beautiful girl\", !\n\nДля новых клиентов у нас действует скидка 10% (обязательно ею воспользуйся!).",
                   replyMarkup: inlineKeyboard,
                   cancellationToken: cancellationToken);
            }
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            return  new MyRecords();
        }
    }
}

