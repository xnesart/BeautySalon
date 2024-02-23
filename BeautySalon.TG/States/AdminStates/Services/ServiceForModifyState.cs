using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BeautySalon.TG.States.Services;

public class ServiceForModifyState:AbstractState
{
    public ServiceForModifyState(string password)
    {
        Password = password;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        servicesHandler.ShowServicesForModify(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Type == UpdateType.CallbackQuery && UpdateType.CallbackQuery != null)
        {
            if (update.CallbackQuery.Data.ToLower() == "визаж")
            {
                this.TypeId = 1;
                return new MakeUpForModifyState(TypeId, Password);
            }
            else if (update.CallbackQuery.Data.ToLower() == "стрижки")
            {
                this.TypeId = 2;
                return new HaircutForModifyState(TypeId, Password);
            }
            else if (update.CallbackQuery.Data.ToLower() == "окрашивание")
            {
                this.TypeId = 3;
                return new ColoringForModifyState(TypeId, Password);
            }
            else if (update.CallbackQuery.Data.ToLower() == "моделирование")
            {
                this.TypeId = 4;
                return new StylingForModifyState(TypeId, Password);
            }
            else if (update.CallbackQuery.Data.ToLower() == "маникюр")
            {
            }
            else if (update.CallbackQuery.Data.ToLower() == "педикюр")
            {
            }
            else if (update.CallbackQuery.Data.ToLower() == "эпиляция")
            {
            }
            else if (update.CallbackQuery.Data.ToLower() == "пилинг")
            {
            }
            else if (update.CallbackQuery.Data.ToLower() == "обертывание")
            {
            }
            else if (update.CallbackQuery.Data.ToLower() == "массаж")
            {
            }
        }
        return  new AdminControlPanelState(Password);
    }
}