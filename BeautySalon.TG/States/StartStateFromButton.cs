using BeautySalon.TG.MessageHandlers;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BeautySalon.TG.States;

public class StartStateFromButton : AbstractState
{
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        UserWelcomeHandler userWelcomeHandler = new UserWelcomeHandler();
        userWelcomeHandler.WelcomeUserFromButton(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        //проверяем, что пришедшее сообщение является нажатием на кнопку и не равно null
        if (update.Type == UpdateType.CallbackQuery && UpdateType.CallbackQuery != null)
        {
            if (update.CallbackQuery.Data.ToLower() == "записаться")
            {
                return new ServiceState();
            }
            else if (update.CallbackQuery.Data.ToLower() == "как добраться")
            {
            }
            else if (update.CallbackQuery.Data.ToLower() == "мои записи")
            {
            }
            else if (update.CallbackQuery.Data.ToLower() == "оставить отзыв")
            {
            }
        }

        return null;
    }
}