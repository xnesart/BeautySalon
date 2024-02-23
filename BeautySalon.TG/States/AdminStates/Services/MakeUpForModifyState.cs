using BeautySalon.BLL.Clients;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Models;
using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using BeuatySalon.TG.States.AdminStates.Services.AddServices;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States.Services;

public class MakeUpForModifyState : AbstractState
{
    public MakeUpForModifyState(int typeId, string password)
    {
        TypeId = typeId;
        Password = password;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        servicesHandler.ChoseMakeUpForModify(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            if (update.CallbackQuery.Data == "добавить услугу")
            {
                return new AddTitleState();
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