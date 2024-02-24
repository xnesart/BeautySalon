using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Services;

public class EditTitleState: AbstractState
{
    public EditTitleState(int typeId, int serviceId, string password)
    {
        TypeId = typeId;
        ServiceId = serviceId;
        Password = password;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        SingletoneStorage.GetStorage().Client
            .SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Задайте новое название услуги:");
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Message.Text != null)
        {
            string title = update.Message.Text;
            return new EditTitleCompleteState(TypeId, ServiceId, Password, title);
        }
        return new StartState();
    }
}