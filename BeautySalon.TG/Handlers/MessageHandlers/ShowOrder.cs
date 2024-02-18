using BeautySalon.BLL;
using BeautySalon.BLL.Clents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.Handlers.MessageHandlers
{
    public class ShowOrder
    {
        public List<OrdersOrdersForClientByIdOutputModel> OrdersOrdersForClientById {  get; set; }

        public async void GetOrdersByClientId( int clientId)
        {

            OrderClient orderClient = new OrderClient();

            OrdersOrdersForClientByIdOutputModel model = new OrdersOrdersForClientByIdOutputModel
            {
                ClientId = clientId,
            };
            var orders = orderClient.GetOrdersForClientById(clientId);

            List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
            int rowsCount = 1;
            for (int i = 0; i <= rowsCount; i += rowsCount)
            {

                var rowServices = orders.Skip(i).Take(rowsCount);

                // Создаем массив кнопок для текущего ряда
                InlineKeyboardButton[] row = rowServices
                    .Select(orders => InlineKeyboardButton.WithCallbackData(text: $"{orders.Order.Id} {orders.Service.Title} {orders.Service.Price} ",
                        callbackData: orders.Order.Id.ToString()))
                    .ToArray();
                buttons.Add(row);

            }
        }

    }
}
