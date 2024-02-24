using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using BeautySalon.TG.States.Employees;
using BeautySalon.TG.States.Services;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

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
        if (update.Message != null && update.Message.Text == "/start")
        {
            return new StartState();
        }
        if (update.CallbackQuery.Data == "редактировать услугу")
        {
            return new ServiceForModifyState(Password);
        }
        if (update.CallbackQuery.Data == "редактировать сотрудника")
        {
            return new EditWorkerStartState(Password);
        }
        if (update.CallbackQuery.Data == "редактировать расписание")
        {
            return new ServiceForModifyState(Password);
        }
        if (update.CallbackQuery.Data == "показать активные записи")
        {
            return new EditWorkerStartState(Password);
        }
        if (update.CallbackQuery.Data == "перейти в меню клиента")
        {
            return new StartState();
        }
        return this;
    }
}