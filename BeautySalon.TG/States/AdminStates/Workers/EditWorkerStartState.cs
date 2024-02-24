using BeautySalon.TG;
using BeautySalon.TG.Handlers.MessageHandlers;
using BeautySalon.TG.States;
using BeautySalon.TG.States.Employees.AddWorkers;
using BeautySalon.TG.States.Services;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Employees;

public class EditWorkerStartState : AbstractState
{
    public EditWorkerStartState(string password)
    {
        Password = password;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        UserHandler userHandler = new UserHandler();
        userHandler.GetAllWorkersByRoleId(SingletoneStorage.GetStorage().Client, update, cancellationToken);
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