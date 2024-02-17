using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class RegistrationState : AbstractState
{
    public RegistrationState(int shiftId, int intervalId, int serviceID)
    {
        ServiceId = serviceID;
        ShiftId = shiftId;
        IntervalId = intervalId;
    }

    public async override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        await SingletoneStorage.GetStorage().Client
            .SendTextMessageAsync(chatId, "Пожалуйста укажите, как к Вам обращаться");
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        throw new NotImplementedException();
    }
}