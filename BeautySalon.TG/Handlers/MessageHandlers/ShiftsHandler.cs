using BeautySalon.BLL;
using BeautySalon.BLL.Clients;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.Handlers.MessageHandlers;

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
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите удобную смену: ",
            replyMarkup: inlineKeyboard);
    }
    
    public async void ChoseShiftByTitle(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        ShiftsClient shiftsClient = new ShiftsClient(); 
        var shifts = shiftsClient.GetAllShiftsWithFreeIntervalsOnToday();
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
                    callbackData: shift.Title.ToString()))
                .ToArray();
            buttons.Add(row);
        }
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                callbackData: "вернуться в главное меню")
        });
        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите смену для редактирования:",
            replyMarkup: inlineKeyboard);
    }
    
    public void GetMastersFromShiftForSchedule(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        IUserClient userClient = new UserClient();
        var workers = userClient.GetAllWorkersByRoleId();
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= workers.Count; i += rowsCount)
        {
            // Выбираем мастеров для текущего ряда
            var rowServices = workers.Skip(i).Take(rowsCount);
            // Создаем массив кнопок мастеров для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(worker => InlineKeyboardButton.WithCallbackData(text: $"{worker.Name} {worker.RoleId}",
                    callbackData: worker.Id.ToString()))
                .ToArray();
            // Добавляем массив кнопок мастеров в список
            buttons.Add(row);
        }
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Добавить мастера",
                callbackData: "добавить мастера")
        });
        //добавляем вернуться в главное меню
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                callbackData: "вернуться в главное меню")
        });
        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
        botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "Выберите мастера, которого хотите удалить из cмены, или другое действие:",
            replyMarkup: inlineKeyboard);
    }
    
    public async void RemoveMasterFromShiftForSchedule(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Удалить мастера из выбранной смены",
                    callbackData: "удалить мастера из выбранной смены"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                    callbackData: "вернуться в главное меню"),
            },
        });
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите действие:",
            replyMarkup: inlineKeyboard);
    }
    
    public async void RemoveMasterFromShift(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken,
        int masterId, int shiftId)
    {
        IUserClient userClient = new UserClient();
        UserIdInputModel model = new UserIdInputModel
        {
            Id = masterId
        };
        userClient.RemoveMasterFromShift(masterId, shiftId);
    }
}