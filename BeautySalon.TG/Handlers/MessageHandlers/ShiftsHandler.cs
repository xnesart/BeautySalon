using BeautySalon.BLL;
using BeautySalon.BLL.Clents;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.Handlers.MessageHandlers;

public class ShiftsHandler
{
    public async void ChoseShift(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        ShiftsClient shiftsClient = new ShiftsClient(); 
        var shifts = shiftsClient.GetAllShiftsOnToday();

        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= rowsCount; i += rowsCount)
        {
            // Выбираем порцию услуг для текущего ряда
            var rowShifts = shifts.Skip(i).Take(rowsCount);

            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowShifts
                .Select(shift => InlineKeyboardButton.WithCallbackData(text: $"{shift.Title} {shift.StartTime}",
                    callbackData: shift.Title.ToLower()))
                .ToArray();

            // Добавляем массив кнопок в список
            buttons.Add(row);
        }

        //добавляем вернуться в главное меню
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