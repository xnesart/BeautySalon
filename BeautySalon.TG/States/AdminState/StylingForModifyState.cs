using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using BeuatySalon.TG.States.Services;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States;

public class StylingForModifyState: AbstractState
{
    public StylingForModifyState(int typeId, string password)
    {
        TypeId = typeId;
        Password = password;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        servicesHandler.ChoseColoring(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            ServiceId = int.Parse(update.CallbackQuery.Data);
            Console.WriteLine(update.CallbackQuery.Data);
            return new EditServiceState(TypeId, ServiceId, Password);
        }
        return new AdminControlPanelState(Password);
    }
}