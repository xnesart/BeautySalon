using BeautySalon.BLL.Clients;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Models;
using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
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
        // if (update.CallbackQuery.Data == "добавить услугу")
        // {
        //     ServiceByIdInputModel model = new ServiceByIdInputModel
        //     {
        //         Title = title,
        //         Type = Type,
        //         Duration = duration,
        //         Price = Price
        //     };
        //     IServiceClient serviceClient = new ServiceClient();
        //     serviceClient.AddServiceById();
        // }

        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            ServiceId = int.Parse(update.CallbackQuery.Data);
            Console.WriteLine(update.CallbackQuery.Data);
            return new EditServiceState(TypeId, ServiceId, Password);
        }

        return new AdminControlPanelState(Password);
    }
}