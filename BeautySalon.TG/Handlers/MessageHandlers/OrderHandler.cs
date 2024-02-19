using BeautySalon.BLL.Clents;
using BeautySalon.BLL.Models.InputModels;
using BeautySalon.BLL.OrdersForClientById;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.Handlers.MessageHandlers
{
    public class OrderHandler
    {
        public void CreateNewOrder(NewOrderInputModel model)
        {
            OrderClient orderClient = new OrderClient();
            orderClient.CreateNewOrder(model);
        }

        public List<OrdersForClientByIdOutputModel> GetOrdersByClientId(int clientId)
        {
            OrderClient orderClient = new OrderClient();
            List<OrdersForClientByIdOutputModel> result =  orderClient.GetOrdersForClientById(clientId);

            return result;
        }
    }
}

