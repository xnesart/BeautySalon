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
            string title = "";
            if (update.CallbackQuery.Data == "УТРО (10:00 - 13:45)")
            {
                title = update.CallbackQuery.Data;
                return new SelectMasterInShiftState(Password, title);
            }
            if (update.CallbackQuery.Data == "ДЕНЬ (14:00 - 17:45)")
            {
                title = update.CallbackQuery.Data;
                return new SelectMasterInShiftState(Password, title);
            }
            if (update.CallbackQuery.Data == "ВЕЧЕР (18:00 - 21:45)")
            {
                title = update.CallbackQuery.Data;
                return new SelectMasterInShiftState(Password,title);
            }
        }
        return new AdminControlPanelState(Password);
    }
}