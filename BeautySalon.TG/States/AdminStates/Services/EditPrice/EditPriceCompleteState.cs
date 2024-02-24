using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Services;

public class EditPriceCompleteState: AbstractState
{
    public EditPriceCompleteState(int typeId, int serviceId, string password, decimal price)
    {
        TypeId = typeId;
        ServiceId = serviceId;
        Password = password;
        Price = price;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        servicesHandler.ServiceUpdatePrice(SingletoneStorage.GetStorage().Client, update, ServiceId, Price);
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