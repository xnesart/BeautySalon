using BeautySalon.TG.Handlers.MessageHandlers;
using BeautySalon.TG.States.Employees;
using BeautySalon.TG.States.Employees.AddWorkers;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Schedule;

public class SelectShiftState: AbstractState
{
    public SelectShiftState(string password)
    {
        Password = password;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ShiftsHandler shiftsHandler = new ShiftsHandler();
        shiftsHandler.ChoseShift(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            if (update.CallbackQuery.Data == "добавить сотрудника")
            {
                return new AddWorkersState(Password);
            }
            else
            {
                WorkerId = int.Parse(update.CallbackQuery.Data);
                return new RemoveWorkersState(Password, WorkerId);
            }
        }
        return new AdminControlPanelState(Password);
    }
}