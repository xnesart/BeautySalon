using BeautySalon.TG.Handlers.MessageHandlers;
using BeautySalon.TG.States.Employees;
using BeautySalon.TG.States.Employees.AddWorkers;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Schedule;

public class SelectMasterInShiftState: AbstractState
{
    public SelectMasterInShiftState(string password)
    {
        Password = password;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ShiftsHandler shiftsHandler = new ShiftsHandler();
        shiftsHandler.GetMastersFromShiftForSchedule(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            if (update.CallbackQuery.Data == "добавить мастера в выбранную смену")
            {
                return new AddWorkersState(Password);
            }
            else
            {
                WorkerId = int.Parse(update.CallbackQuery.Data);
                return new RemoveMasterFromShiftState(Password, MasterId);
            }
        }
        return new AdminControlPanelState(Password);
    }
}