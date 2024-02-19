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

namespace BeuatySalon.TG.States.MyRecordsState
{
    public class MyRecords : AbstractState
    {
        private List<OrdersForClientByIdOutputModel> orders {  get; set; }
        public override async void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            UserHandler userHandler = new UserHandler();
            OrderHandler orderHandler = new OrderHandler();

            int? userId = userHandler.GetUserByChatId(chatId);

            bool isUserRegistered = userId != null;

            if (isUserRegistered)
            {
                List<OrdersForClientByIdOutputModel> orders = orderHandler.GetOrdersByClientId((int)userId);

                this.orders = orders;

                bool isActiveOrders = orders.Count > 0;

                if(isActiveOrders)
                {
                    List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
                    orders.ForEach(order =>
                    {
                        buttons.Add([new InlineKeyboardButton(text: order.Service.Title)]);
                    });

                    InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);

                    await SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                       chatId: update.CallbackQuery.From.Id,
                       text: $"Ваши записи:",
                       replyMarkup: inlineKeyboard,
                       cancellationToken: cancellationToken
                    );
                }
                else
                {
                    await SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                       chatId: update.CallbackQuery.From.Id,
                       text: $"На данный момент у Вас нет активных записей. Могу предложить зарегистрироваться у нас ?",
                       replyMarkup: new InlineKeyboardMarkup(
                        [
                           [InlineKeyboardButton.WithCallbackData(text: "Записаться на услугу", callbackData: "Записаться на услугу")],
                            [InlineKeyboardButton.WithCallbackData(text: "Верунться в главное меню", callbackData: "Верунться в главное меню")],

                        ]
                    ),
                       cancellationToken: cancellationToken);
                }
            }
            else
            {
                await SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                    chatId: update.CallbackQuery.From.Id,
                    text: $"Вы не зарегистрированы в нашем салоне.",
                    replyMarkup: new InlineKeyboardMarkup(
                        [
                           [InlineKeyboardButton.WithCallbackData(text: "Зарегистрироваться", callbackData: "Зарегистрироваться")],
                            [InlineKeyboardButton.WithCallbackData(text: "Верунться в главное меню", callbackData: "Верунться в главное меню")],
                            
                        ]
                    ),
                    cancellationToken: cancellationToken
                );
            }
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.CallbackQuery.Data == "Зарегистрироваться")
            {
                return new RegistrationStateNameMyRecords();
            }
            if(update.CallbackQuery.Data == "Верунться в главное меню")
            {
                return new StartState();
            }
            if(update.CallbackQuery.Data == "Записаться на услугу")
            {
                return new ServiceState();
            }
        }
    }
}

