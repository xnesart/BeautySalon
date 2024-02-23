using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using BeuatySalon.TG.States.Employees;
using BeuatySalon.TG.States.Services;
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
        return this;
    }
}