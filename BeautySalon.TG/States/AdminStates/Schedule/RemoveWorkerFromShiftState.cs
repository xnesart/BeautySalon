using BeautySalon.TG.Handlers.MessageHandlers;
using BeautySalon.TG.States.Employees;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Schedule;

public class RemoveWorkerFromShiftState: AbstractState
{
    public RemoveWorkerFromShiftState(string password, int workerId)
    {
        Password = password;
        WorkerId = workerId;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        UserHandler userHandler = new UserHandler();
        userHandler.RemoveWorkerGetButtonsForSchedule(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            return new RemoveWorkerFromShiftCompleteState(Password, WorkerId);
        }
        return new AdminControlPanelState(Password);
    }
}