using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class RegistrationStatePhone : AbstractState
{
    public RegistrationStatePhone(int shiftId, int intervalId, int serviceID, int typeId, string name)
    {
        ServiceId = serviceID;
        ShiftId = shiftId;
        IntervalId = intervalId;
        TypeId = typeId;
        Name = name;
    }

    public async override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        await SingletoneStorage.GetStorage().Client
            .SendTextMessageAsync(chatId, "Пожалуйста, введите Ваш актуальный номер телефона для связи");
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        Phone = update?.Message.Text;
        return new RegistrationStateMail(ServiceId,ShiftId, IntervalId,  TypeId, Name, Phone);
    }
}