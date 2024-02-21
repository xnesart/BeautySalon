using BeautySalon.BLL.Client;
using BeautySalon.BLL.Models;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.Handlers.MessageHandlers;

public class IntervalsHanlder
{
    public List<IntervalsIdTitleStartTimeOutputModel> ListOfFreeIntervals { get; set; }
    public async void GetFreeIntervalsOnCurrentShift(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken,int shiftId)
    {
        IntervalsClient intervalsClient = new IntervalsClient();
        
        ShiftIdInputModel model = new ShiftIdInputModel
        {
            Id = shiftId
        };
        
        var intervals = intervalsClient.GetAllFreeIntervalsByShiftId(model);
        ListOfFreeIntervals = intervals;
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 4;
        for (int i = 0; i <= rowsCount; i += rowsCount)
        {
            // Выбираем порцию инервалов для текущего ряда
            var rowServices = intervals.Skip(i).Take(rowsCount);

            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(interval => InlineKeyboardButton.WithCallbackData(text: $"{interval.Title} ",
                    callbackData: interval.Title.ToLower()))
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

        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите подходящий интервал",
            replyMarkup: inlineKeyboard);
    }
}