using BeautySalon.TG;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.AdminStates.Services.AddServices;

public class AddPriceState : AbstractState
{
    public AddPriceState(string title, int typeId, string duration)
    {
        Title = title;
        TypeId = typeId;
        Duration = duration;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Назначьте цену услуги:");
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Message.Text != null)
        {
            decimal price = decimal.Parse(update.Message.Text);
            return new AddFinalState(Title, TypeId, Duration, price);
        }

        return new StartState();
    }
}