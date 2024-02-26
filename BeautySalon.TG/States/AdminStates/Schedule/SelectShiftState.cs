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
        int number = -1;
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            string title = "";
            if (update.CallbackQuery.Data == "УТРО (10:00 - 13:45)")
            {
                title = update.CallbackQuery.Data;
                Title = title;
                number = 1;
                return new SelectMasterInShiftState(Password, title, number);
            }
            if (update.CallbackQuery.Data == "ДЕНЬ (14:00 - 17:45)")
            {
                title = update.CallbackQuery.Data;
                Title = title;
                number = 2;
                return new SelectMasterInShiftState(Password, title, number);
            }
            if (update.CallbackQuery.Data == "ВЕЧЕР (18:00 - 21:45)")
            {
                title = update.CallbackQuery.Data;
                Title = title;
                number = 3;
                return new SelectMasterInShiftState(Password,title, number);
            }
        }
        return new AdminControlPanelState(Password);
    }
}