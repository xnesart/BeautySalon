using BeautySalon.BLL;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.Handlers.MessageHandlers;

public class OrderHandler
{
    public async void GetRegister(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        ShiftsClient shiftsClient = new ShiftsClient(); 
        var shifts = shiftsClient.GetAllShiftsOnToday();

        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= rowsCount; i += rowsCount)
        {
            var rowShifts = shifts.Skip(i).Take(rowsCount);

            InlineKeyboardButton[] row = rowShifts
                .Select(shift => InlineKeyboardButton.WithCallbackData(text: $"{shift.Title} {shift.StartTime}",
                    callbackData: shift.Title.ToLower()))
                .ToArray();

            buttons.Add(row);
        }

        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                callbackData: "вернуться в главное меню")
        });

        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);

        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Список стрижек",
            replyMarkup: inlineKeyboard);
    }
}