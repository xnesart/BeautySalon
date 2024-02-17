using BeautySalon.TG.MessageHandlers;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BeautySalon.TG.States;

public class ServiceState : AbstractState
{
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ServicesHandler servicesHandler = new ServicesHandler();
        servicesHandler.ShowServices(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Type == UpdateType.CallbackQuery && UpdateType.CallbackQuery != null)
        {
            if (update.CallbackQuery.Data.ToLower() == "стрижка")
            {
                return new HaircutState();
            }
            else if (update.CallbackQuery.Data.ToLower() == "покраска")
            {
                return new ColoringState();
            }
            else if (update.CallbackQuery.Data.ToLower() == "укладка")
            {
                return new StylingState();

            }
            else if (update.CallbackQuery.Data.ToLower() == "макияж")
            {
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
            else if (update.CallbackQuery.Data.ToLower() == "вернуться в главное меню")
            {
                return new StartStateFromButton();
            }
        }

        return null;
    }
}