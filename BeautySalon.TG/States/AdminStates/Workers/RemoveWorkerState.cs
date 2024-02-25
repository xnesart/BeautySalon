using BeautySalon.TG;
using BeautySalon.TG.Handlers.MessageHandlers;
using BeautySalon.TG.States;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Employees;

public class RemoveWorkerState:AbstractState
{
    public RemoveWorkerState(string password, int workerId)
    {
        Password = password;
        WorkerId = workerId;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        UserHandler userHandler = new UserHandler();
        userHandler.RemoveWorkerGetButtons(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            return new RemoveWorkerCompleteState(Password, WorkerId);
        }
        return new AdminControlPanelState(Password);
    }
}