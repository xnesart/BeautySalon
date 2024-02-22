using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States.Services;

public class EditPriceState : AbstractState
{
    public EditPriceState(int typeId, int serviceId, string password)
    {
        TypeId = typeId;
        ServiceId = serviceId;
        Password = password;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        SingletoneStorage.GetStorage().Client
            .SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Введите цену услуги");
        ServicesHandler servicesHandler = new ServicesHandler();
        servicesHandler.ServiceUpdatePrice(SingletoneStorage.GetStorage().Client, update, cancellationToken, ServiceId,
            Price);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
    }
}