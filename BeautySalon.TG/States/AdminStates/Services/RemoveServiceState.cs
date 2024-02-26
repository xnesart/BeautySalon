using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using BeautySalon.TG.States.Services;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States.AdminStates.Services;

public class RemoveServiceState:AbstractState
{
    public RemoveServiceState(int serviceId, string password, int typeId)
    {
        ServiceId = serviceId;
        Password = password;
        TypeId = typeId;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        servicesHandler.ServiceRemove(SingletoneStorage.GetStorage().Client, update, ServiceId);
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
        else
        {
            if (update.CallbackQuery.Data == "вернуться к выбору услуги")
            {
                if (TypeId == 1)
                {
                    return new MakeUpForModifyState(TypeId, Password);
                }

                if (TypeId == 2)
                {
                    return new HaircutForModifyState(TypeId, Password);
                }

                if (TypeId == 3)
                {
                    return new ColoringForModifyState(TypeId, Password);
                }

                if (TypeId == 4)
                {
                    return new StylingForModifyState(TypeId, Password);
                }
            }
            if (update.CallbackQuery.Data == "вернуться к выбору типа услуг")
            {
                return new ServiceForModifyState(Password);
            }
            if (update.CallbackQuery.Data == "вернуться в меню админа")
            {
                return new AdminControlPanelState(Password);
            }
            if (update.CallbackQuery.Data == "перейти в меню клиента")
            {
                return new StartState();
            }
        }
        
        return new ServiceForModifyState(Password);
    }
}