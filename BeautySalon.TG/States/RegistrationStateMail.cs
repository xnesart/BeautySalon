using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class RegistrationStateMail:AbstractState
{
    public RegistrationStateMail(int shiftId, int intervalId, int serviceID, int typeId, string name, string phone)
    {
        ServiceId = serviceID;
        ShiftId = shiftId;
        IntervalId = intervalId;
        TypeId = typeId;
        Name = name;
        Phone = phone;
    }

    public async override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        await SingletoneStorage.GetStorage().Client
            .SendTextMessageAsync(chatId, "Пожалуйста укажите Ваш e-mail для рассылки спецпредложений (по желанию):");
        
    }

    public override  AbstractState ReceiveMessage(Update update)
    {
        Mail = update?.Message.Text;
         SingletoneStorage.GetStorage().Client
            .SendTextMessageAsync(update.Message.Chat.Id, "Будем рады видеть Вас в нашем салоне!\nНаш администратор свяжется с Вами накануне посещения для подтверждения Вашего визита. Хорошего дня!");

         return new StartStateFromButton();
    }
}