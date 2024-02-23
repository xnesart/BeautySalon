using BeautySalon.TG;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Services.EditDuration;

public class EditDurationState : AbstractState
{
    public EditDurationState(int typeId, int serviceId, string password)
    {
        TypeId = typeId;
        ServiceId = serviceId;
        Password = password;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        SingletoneStorage.GetStorage().Client
            .SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Введите длительность услуги услуги");
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Message.Text != null)
        {
            string duration = update.Message.Text;
            return new EditDurationCompleteState(TypeId, ServiceId, Password, duration);
        }

        return new StartState();
    }
}