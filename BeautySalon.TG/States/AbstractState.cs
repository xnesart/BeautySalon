using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public abstract class AbstractState
{
    public abstract void SendMessage(long chatId);
    public abstract void ReceiveMessage(Update update);
}