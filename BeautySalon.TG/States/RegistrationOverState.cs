using BeautySalon.TG;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.States;

public class RegistrationOverState: AbstractState
{
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        //добавляем вернуться в главное меню
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                callbackData: "вернуться в главное меню")
        });
        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat.Id, "Будем рады видеть Вас в нашем салоне!\nНаш администратор свяжется с Вами накануне посещения для подтверждения Вашего визита. Хорошего дня!",
            replyMarkup: inlineKeyboard);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data == "вернуться в главное меню")
        {
            return new StartState();
        }
        return this;
    }
}