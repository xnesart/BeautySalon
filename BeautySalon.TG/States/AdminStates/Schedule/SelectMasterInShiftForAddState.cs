using BeautySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States.Schedule;

public class SelectMasterInShiftForAddState : AbstractState
{
    public SelectMasterInShiftForAddState(string password, string title)
    {
        Password = password;
        Title = title;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ShiftsHandler shiftsHandler = new ShiftsHandler();
        shiftsHandler.GetMastersAbsentedInSelectedShift(SingletoneStorage.GetStorage().Client, update,
            cancellationToken, Title);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            if (update.CallbackQuery.Data == "вернуться к выбору смены")
            {
                return new SelectShiftState(Password);
            }
            else
            {
                return new AddMasterToShiftState(Password);
            }
        }
        return new AdminControlPanelState(Password);
    }
}