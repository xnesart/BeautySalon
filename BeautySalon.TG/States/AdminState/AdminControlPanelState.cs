using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States;

public class AdminControlPanelState: AbstractState
{
    public AdminControlPanelState(string password)
    {
        Password = password;
    }
    
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        UserWelcomeHandler userWelcomeHandler = new UserWelcomeHandler();
        userWelcomeHandler.WelcomeAdminControl(SingletoneStorage.GetStorage().Client, update, cancellationToken, Password);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            // ShiftId = int.Parse(update.CallbackQuery.Data);
            // Console.WriteLine(ShiftId);
            // //Передаем в стейт интервалов выбранный айди смены.
            // return new IntervalsState(ShiftId, TypeId, ServiceId);
        }
        return new StartState();
    }
}