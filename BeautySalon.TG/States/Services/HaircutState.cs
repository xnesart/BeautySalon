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
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            Console.WriteLine(update.CallbackQuery.Data);
            return new ShiftState(TypeId);
        }

        return new StartState();
    }
}