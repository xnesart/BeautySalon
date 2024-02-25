using BeautySalon.TG;
using BeautySalon.TG.Handlers.MessageHandlers;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.States.Employees;

public class RemoveWorkerCompleteState : AbstractState
{
    public RemoveWorkerCompleteState(string password, int workerId)
    {
        Password = password;
        WorkerId = workerId;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        UserHandler userHandler = new UserHandler();
        userHandler.RemoveWorkerById(SingletoneStorage.GetStorage().Client, update, cancellationToken,WorkerId);
        //SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выбранный сотрудник удален из базы.");
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
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в меню выбора сотрудников",
                    callbackData: "вернуться в меню выбора сотрудников"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "вернуться в главное меню",
                    callbackData: "вернуться в главное меню"),
            },
        });
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.CallbackQuery.From.Id, "Выбранный сотрудник удален из базы.",
            replyMarkup: inlineKeyboard);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery != null)
        {
            if (update.CallbackQuery.Data == "вернуться в главное меню")
            {
                return new AdminControlPanelState(Password);
            }
        }
        return new EditWorkerStartState(Password);
    }
}