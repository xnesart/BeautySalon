using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using BeuatySalon.TG.States.Services.EditDuration;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States.Services;

public class EditServiceState:AbstractState
{
    public EditServiceState(int typeId,int serviceId, string password)
    {
        TypeId = typeId;
        ServiceId = serviceId;
        Password = password;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        servicesHandler.ServiceEdit(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        if (update.CallbackQuery.Data != "вернуться к выбору типа услуг")
        {
            if (update.CallbackQuery.Data == "удалить")
            {
                servicesHandler.ServiceRemove(SingletoneStorage.GetStorage().Client, update, ServiceId);
            }
            if (update.CallbackQuery.Data == "изменить цену")
            {
                return new EditPriceState(TypeId, ServiceId, Password);
            }

            if (update.CallbackQuery.Data == "изменить длительность")
            {
                return new EditDurationState(TypeId, ServiceId, Password);
            }
        }
        return new ServiceForModifyState(Password);
    }
}