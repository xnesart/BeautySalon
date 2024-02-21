using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using BeuatySalon.TG.States.MyRecordsState;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BeuatySalon.TG.States;

public class AdminState : AbstractState
{
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        UserWelcomeHandler userWelcomeHandler = new UserWelcomeHandler();
        userWelcomeHandler.WelcomeAdmin(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Message != null)
        {
            if (update.Message.Text == "/admin")
            {
                return new AdminState();
            }
        }

        if (update.Type == UpdateType.CallbackQuery && UpdateType.CallbackQuery != null)
        {
            if (update.CallbackQuery.Data.ToLower() == "ввести пароль")
            {
                return new AdminPasswordState();
            }
            else if (update.CallbackQuery.Data.ToLower() == "вернуться в главное меню") //"как добраться"
            {
                return new StartState();
            }
        }

        return this;
    }
}