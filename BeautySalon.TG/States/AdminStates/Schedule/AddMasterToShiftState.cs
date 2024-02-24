using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Schedule;

public class AddMasterToShiftState: AbstractState
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