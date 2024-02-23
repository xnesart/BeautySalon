using BeautySalon.BLL.Models;
using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using BeuatySalon.TG.States.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States.AdminStates.Services.AddServices;

public class AddFinalState : AbstractState
{
    public AddFinalState(string title, int typeId, string duration, decimal price)
    {
        Title = title;
        TypeId = typeId;
        Duration = duration;
        Price = price;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        ServiceByIdInputModel model = new ServiceByIdInputModel
        {
            Title = Title,
            Type = TypeId,
            Duration = Duration,
            Price = Price,
        };
        servicesHandler.AddNewService(SingletoneStorage.GetStorage().Client, update, model);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Message != null)
        {
            if (update.Message.Text != null)
            {
                string price = update.Message.Text;
                return new StartState();
            }
            
        }

        return new StartState();
    }
}