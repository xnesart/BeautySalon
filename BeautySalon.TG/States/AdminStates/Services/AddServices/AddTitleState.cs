using BeautySalon.TG;
using BeautySalon.TG.States;
using BeuatySalon.TG.States.Services;
using BeuatySalon.TG.States.Services.EditDuration;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States.AdminStates.Services.AddServices;

public class AddTitleState: AbstractState
{    

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Введите название услуги:");
    }
    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Message.Text != null)
        {
            string title = update.Message.Text;
            return new AddTypeState(title);
        }
        return new StartState();
    }
}