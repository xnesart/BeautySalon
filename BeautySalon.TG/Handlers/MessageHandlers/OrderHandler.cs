using BeautySalon.BLL;
using BeautySalon.BLL.Clents;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.Handlers.MessageHandlers;

public class OrderHandler
{

    public void CreateNewOrder()
    {
        OrderClient orderClient = new OrderClient();
        // orderClient.CreateNewOrder();
        // OrderClient.CreateNewOrder();
    }
}