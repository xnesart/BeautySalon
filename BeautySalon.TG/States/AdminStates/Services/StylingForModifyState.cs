using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using BeautySalon.TG.States.AdminStates.Services.AddServices;
using BeautySalon.TG.States.Services;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

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
        servicesHandler.ChoseStylingForModify(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            if (update.CallbackQuery.Data == "добавить услугу")
            {
                return new AddTitleState(TypeId);
            }
            else
            {
                ServiceId = int.Parse(update.CallbackQuery.Data);
                Console.WriteLine(update.CallbackQuery.Data);
                return new EditServiceState(TypeId, ServiceId, Password);
            }
        }
        return new AdminControlPanelState(Password);
    }
}