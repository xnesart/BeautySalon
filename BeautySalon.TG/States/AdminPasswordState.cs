using BeautySalon.TG;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeuatySalon.TG.States;

public class AdminPasswordState: AbstractState
{
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
            chatId: update.CallbackQuery.From.Id,
            text: "Введите Ваш пароль:"
        );
    }

    public override AbstractState ReceiveMessage(Update update)
    {

    }
}