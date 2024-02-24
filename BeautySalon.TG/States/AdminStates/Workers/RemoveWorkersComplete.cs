using BeautySalon.TG;
using BeautySalon.TG.Handlers.MessageHandlers;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.States.Employees;

public class RemoveWorkersComplete : AbstractState
{
    public RemoveWorkersComplete(string password, int workerId)
    {
        Password = password;
        WorkerId = workerId;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        UserHandler userHandler = new UserHandler();
        userHandler.RemoveWorkerById(SingletoneStorage.GetStorage().Client, update, cancellationToken,WorkerId);
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выбранный сотрудник удален.");
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в меню администратора",
                    callbackData: "вернуться в главное меню"),
            },
        });
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "Выберите действие:",
            replyMarkup: inlineKeyboard);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
   
        return new AdminControlPanelState(Password);
    }
}