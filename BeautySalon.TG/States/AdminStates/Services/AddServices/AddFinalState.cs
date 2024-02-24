using BeautySalon.BLL.Models;
using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using BeautySalon.TG.States.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.AdminStates.Services.AddServices;

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
        }
        return new StartState();
    }
}