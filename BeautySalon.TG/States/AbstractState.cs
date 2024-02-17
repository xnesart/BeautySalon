using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public abstract class AbstractState
{
    public abstract void SendMessage(long chatId, Update update, CancellationToken cancellationToken);
    public abstract AbstractState ReceiveMessage(Update update);
}