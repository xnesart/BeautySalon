using BeautySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.States.Schedule;

public class AddMasterToShiftCompleteState: AbstractState
{
    public AddMasterToShiftCompleteState(string password, int number, int workerId)
    {
        Password = password;
        Number = number;
        WorkerId = workerId;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ShiftsHandler shiftsHandler = new ShiftsHandler();
        shiftsHandler.AddMasterToShiftWithCreatedNewIntervals(SingletoneStorage.GetStorage().Client, update, cancellationToken, Number, WorkerId);
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выбранный сотрудник назначен на выбранную смену.");
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                    callbackData: "вернуться в главное меню"),
            },
        });
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat.Id,
            "Выбранный сотрудник назначен на выбранную смену.",
            replyMarkup: inlineKeyboard);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        return new AdminControlPanelState(Password);
    }
}