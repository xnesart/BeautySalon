using BeautySalon.TG;
using BeautySalon.TG.States;
using BeuatySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States.Employees.AddWorkers;

public class AddWorkersState:AbstractState
{
    public AddWorkersState(string password)
    {
        Password = password;
    }
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        UserHandler userHandler = new UserHandler();
        userHandler.AddWorkersStateGetButtons(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            if (update.CallbackQuery.Data == "администратор")
            {
                return new AddWorkersStateName(Password, 1);
            }
            else
            {
                return new AddWorkersStateName(Password, 2);
            }
        }

        return this;
    }
}