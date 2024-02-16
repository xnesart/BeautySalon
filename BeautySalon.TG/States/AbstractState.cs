using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public abstract class AbstractState
{
    public abstract void SendMessage(long chatId);
    public abstract AbstractState ReceiveMessage(Update update);
}