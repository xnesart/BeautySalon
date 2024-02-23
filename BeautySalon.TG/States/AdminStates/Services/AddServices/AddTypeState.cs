using BeautySalon.TG;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.AdminStates.Services.AddServices;

public class AddTypeState: AbstractState
{
    public AddTypeState(string title)
    {
        Title = title;
    }
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите тип услуги:");
    }
    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Message.Text != null)
        {
            int typeId = int.Parse(update.Message.Text);
            return new AddDurationState(Title, typeId);
        }
        return new StartState();
    }
}