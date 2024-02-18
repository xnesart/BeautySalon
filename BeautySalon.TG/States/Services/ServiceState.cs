using BeautySalon.TG.MessageHandlers;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BeautySalon.TG.States;

public class ServiceState : AbstractState
{
    public int TypeId { get; set; }
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
                this.TypeId = 1;
                return new HaircutState(TypeId);
            }
            else if (update.CallbackQuery.Data.ToLower() == "покраска")
            {
                this.TypeId = 2;
                return new ColoringState(TypeId);
            }
            else if (update.CallbackQuery.Data.ToLower() == "укладка")
            {
                this.TypeId = 3;
                return new StylingState(TypeId);

            }
            else if (update.CallbackQuery.Data.ToLower() == "макияж")
            {
                this.TypeId = 4;
                return new MakeUpState(TypeId);
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
                return new StartState();
            }
        }
        return  new StartState();
    }
}