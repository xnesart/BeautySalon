using BeautySalon.TG;
using BeautySalon.TG.States;
using BeuatySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States;

public class LeaveFeedbackState: AbstractState
{
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        UserHandler userHandler = new UserHandler();
        userHandler.LeaveFeedback(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        return new StartState();
    }
}