using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class StartState:AbstractState
{
    public override void SendMessage(long chatId)
    {
        throw new NotImplementedException();
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        throw new NotImplementedException();
    }
}