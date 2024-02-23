using BeautySalon.TG.States;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States.AdminStates.Services;

public class ReturnServiceState: AbstractState
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