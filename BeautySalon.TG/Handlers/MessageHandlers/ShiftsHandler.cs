using BeautySalon.BLL;
using BeautySalon.BLL.Clients;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.Handlers.MessageHandlers;

public class ShiftsHandler
{
    public async void ChoseShift(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        ShiftsClient shiftsClient = new ShiftsClient(); 
        var shifts = shiftsClient.GetAllShiftsWithFreeIntervalsOnToday();
        //оставляем в списке смен только 3
        if (shifts.Count > 3)
        {
            shifts.RemoveRange(3,shifts.Count-3);
        }

        if (shifts.Count == 0)
        {
            
        }
        
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= rowsCount; i += rowsCount)
        {
            var rowShifts = shifts.Skip(i).Take(rowsCount);

            InlineKeyboardButton[] row = rowShifts
                .Select(shift => InlineKeyboardButton.WithCallbackData(text: $"{shift.Title}",
                    callbackData: shift.Id.ToString()))
                .ToArray();

            buttons.Add(row);
        }

        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                callbackData: "вернуться в главное меню")
        });

        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);

        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите удобную смену",
            replyMarkup: inlineKeyboard);
    }
}