using BeautySalon.BLL;
using BeautySalon.BLL.IClient;
using BeautySalon.TG;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.States;

public class AdminPasswordState : AbstractState
{
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            // new[]
            // {
            //     InlineKeyboardButton.WithCallbackData(text: "Администратор",
            //         callbackData: "администратор"),
            // },
            // new[]
            // {
            //     InlineKeyboardButton.WithCallbackData(text: "Мастер",
            //         callbackData: "мастер"),
            // },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в меню клиента",
                    callbackData: "вернуться в меню клиента"),
            },
        });
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
            update.Message != null ? update.Message.Chat.Id : update.CallbackQuery.From.Id,
            "Введите пароль администратора либо вернитесь в меню клиента:",
            replyMarkup: inlineKeyboard);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.Message != null)
        {
            string password = update.Message.Text;
            UserClient userClient = new UserClient();
            string adminName = userClient.GetWorkerNameByPassword(password);
            if (adminName == null || adminName == "")
            {
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat.Id,
                    "Введённый пароль отсутствует в базе.");
                return this;
            }
            else
            {
                Password = update.Message.Text;
                userClient.ChangeChatIdAndUserNameByPassword(Password, (int)update.Message.Chat.Id,
                    update.Message.Chat.Username);
                return new AdminControlPanelState(Password);
            }
        }
        return new StartState();
    }
}