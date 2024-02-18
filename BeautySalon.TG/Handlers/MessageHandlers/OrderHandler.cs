using BeautySalon.BLL;
using BeautySalon.BLL.Clents;
using BeautySalon.BLL.Models.InputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.Handlers.MessageHandlers;

public class OrderHandler
{

    public void CreateNewOrder(NewOrderInputModel model)
    {
        OrderClient orderClient = new OrderClient();
        orderClient.CreateNewOrder(model);
    }
}