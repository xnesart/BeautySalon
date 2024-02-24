using BeautySalon.TG.Handlers.MessageHandlers;
using BeautySalon.TG.States.Employees;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Schedule;

public class RemoveMasterFromShiftState: AbstractState
{
    public RemoveMasterFromShiftState(string password, int workerId)
    {
        Password = password;
        WorkerId = workerId;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ShiftsHandler shiftsHandler = new ShiftsHandler();
        shiftsHandler.RemoveMasterFromShiftForSchedule(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            // return new RemoveMasterFromShiftCompleteState(Password, WorkerId);
        }
        return new AdminControlPanelState(Password);
    }
}