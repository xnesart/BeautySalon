using BeautySalon.TG;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States.AdminStates.Services.AddServices;

public class AddDurationState: AbstractState
{
    public AddDurationState(string title, int typeId)
    {
        Title = title;
        TypeId = typeId;
    }
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Укажите продолжительность услуги:");
    }
    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Message.Text != null)
        {
            string duration = update.Message.Text;
            return new AddPriceState(Title, TypeId, duration);
        }
        return new StartState();
    }
}