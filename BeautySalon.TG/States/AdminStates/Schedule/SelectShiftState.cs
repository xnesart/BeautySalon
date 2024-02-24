using BeautySalon.TG.Handlers.MessageHandlers;
using BeautySalon.TG.States.Employees;
using BeautySalon.TG.States.Employees.AddWorkers;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Schedule;

public class SelectShiftState : AbstractState
{
    public SelectShiftState(string password)
    {
        Password = password;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ShiftsHandler shiftsHandler = new ShiftsHandler();
        shiftsHandler.ChoseShiftByTitle(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            if (update.CallbackQuery.Data == "УТРО (10:00 - 13:45)")
            {
                return new SelectMasterInShiftState(Password);
            }
            if (update.CallbackQuery.Data == "ДЕНЬ (14:00 - 17:45)")
            {
                return new SelectMasterInShiftState(Password);
            }
            if (update.CallbackQuery.Data == "ВЕЧЕР (18:00 - 21:45)")
            {
                return new SelectMasterInShiftState(Password);
            }
        }
        return new AdminControlPanelState(Password);
    }
}