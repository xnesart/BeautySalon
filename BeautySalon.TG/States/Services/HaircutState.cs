using BeautySalon.TG.MessageHandlers;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class HaircutState:AbstractState
{
    public HaircutState(int typeId)
    {
        TypeId = typeId;
    }
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        servicesHandler.ChoseHaircut(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        throw new NotImplementedException();
    }
}