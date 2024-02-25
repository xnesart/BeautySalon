using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class RegistrationStateName : AbstractState
{
    public RegistrationStateName(int serviceID,int shiftId, int intervalId,  int typeId)
    {
        ServiceId = serviceID;
        ShiftId = shiftId;
        IntervalId = intervalId;
        TypeId = typeId;
    }

    public async override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        await SingletoneStorage.GetStorage().Client
            .SendTextMessageAsync(chatId, "Пожалуйста, напишите Ваше имя, чтобы мы знали, как к Вам обращаться:");
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        Name = update?.Message.Text;
        return new RegistrationStatePhone(ServiceId, ShiftId, IntervalId, TypeId, Name);
    }
}