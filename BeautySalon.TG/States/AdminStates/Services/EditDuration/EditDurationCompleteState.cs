using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Services.EditDuration;

public class EditDurationCompleteState: AbstractState
{
    public EditDurationCompleteState(int typeId, int serviceId, string password, string duration)
    {
        TypeId = typeId;
        ServiceId = serviceId;
        Password = password;
        Duration = duration;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        servicesHandler.ServiceUpdateDuration(SingletoneStorage.GetStorage().Client, update, ServiceId, Duration);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Message != null)
        {
            if (update.Message.Text != null)
            {
                return new ServiceForModifyState(Password);
            }
        }
        if (update.CallbackQuery.Data == "вернуться в главное меню")
        {
            return new ServiceForModifyState(Password);
        }
        return new ServiceForModifyState(Password);
    }
}