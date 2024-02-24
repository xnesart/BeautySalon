using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Services;

public class EditTitleCompleteState: AbstractState
{
    public EditTitleCompleteState(int typeId, int serviceId, string password, string title)
    {
        TypeId = typeId;
        ServiceId = serviceId;
        Password = password;
        Title = title;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        servicesHandler.ServiceUpdateTitle(SingletoneStorage.GetStorage().Client, update, ServiceId, Title);
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
        // if (update.CallbackQuery.Data == "вернуться к выбору услуги")
        // {
        //     return new ServiceForModifyState(Password);
        // }
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
        return new ServiceForModifyState(Password);
    }
}