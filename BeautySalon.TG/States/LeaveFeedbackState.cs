using BeautySalon.TG;
using BeautySalon.TG.Handlers.MessageHandlers;
using BeautySalon.TG.States;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

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