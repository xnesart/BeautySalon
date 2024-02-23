using BeautySalon.TG.States;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.AdminStates.Services;

public class ReturnMenuState: AbstractState
{
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        throw new NotImplementedException();
    }
}