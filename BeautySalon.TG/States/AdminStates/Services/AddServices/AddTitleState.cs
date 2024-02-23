using BeautySalon.TG;
using BeautySalon.TG.States;
using BeautySalon.TG.States.Services;
using BeautySalon.TG.States.Services.EditDuration;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.AdminStates.Services.AddServices;

public class AddTitleState: AbstractState
{
    public AddTitleState(int typeId)
    {
        TypeId = typeId;
    }
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Введите название услуги:");
    }
    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Message.Text != null)
        {
            string title = update.Message.Text;
            return new AddDurationState(title, TypeId);
        }
        return new StartState();
    }
}