using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class RegistrationState:AbstractState
{
    public int ServiceID { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    // public RegistrationState()
    // {
    //     ServiceID = serviceID;
    // }
    public async override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        await SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Пожалуйста укажите, как к Вам обращаться");
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        throw new NotImplementedException();
    }
}