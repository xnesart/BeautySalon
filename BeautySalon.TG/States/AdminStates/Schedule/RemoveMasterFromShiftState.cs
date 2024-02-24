using BeautySalon.TG.Handlers.MessageHandlers;
using BeautySalon.TG.States.Employees;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Schedule;

public class RemoveMasterFromShiftState: AbstractState
{
    public RemoveMasterFromShiftState(string password, int masterId, string title)
    {
        Password = password;
        MasterId = masterId;
        Title = title;
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
            return new RemoveMasterFromShiftCompleteState(Password, MasterId, Title);
        }
        return new AdminControlPanelState(Password);
    }
}