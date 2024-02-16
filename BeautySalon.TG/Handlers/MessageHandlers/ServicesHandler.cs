using System.Runtime.InteropServices.JavaScript;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.MessageHandlers;

public class ServicesHandler
{
    public async void ShowServices(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            // first row
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Стрижка", callbackData: "стрижка"),
                InlineKeyboardButton.WithCallbackData(text: "Покраска", callbackData: "покраска"),
            },
            // second row
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Укладка", callbackData: "укладка"),
                InlineKeyboardButton.WithCallbackData(text: "Макияж", callbackData: "макияж"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Маникюр", callbackData: "маникюр"),
                InlineKeyboardButton.WithCallbackData(text: "Педикюр", callbackData: "педикюр"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Эпиляция", callbackData: "эпиляция"),
                InlineKeyboardButton.WithCallbackData(text: "Пилинг", callbackData: "пилинг"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Обертывание", callbackData: "обертывание"),
                InlineKeyboardButton.WithCallbackData(text: "Массаж", callbackData: "массаж"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                    callbackData: "вернуться в главное меню"),
            },
        });

        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите услугу",
            replyMarkup: inlineKeyboard);
    }

    public async void GetBackToMenu(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            // first row
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Как добраться", callbackData: "как добраться"),
                InlineKeyboardButton.WithCallbackData(text: "Записаться", callbackData: "записаться"),
            },
            // second row
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Мои записи", callbackData: "мои записи"),
                InlineKeyboardButton.WithCallbackData(text: "Оставить отзыв", callbackData: "оставить отзыв"),
            },
        });

        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Главное меню",
            replyMarkup: inlineKeyboard);
    }

    public async void ChoseHaircut(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        IServicesRepository servicesRepository = new ServicesRepository();
        var services = servicesRepository.GetAllServicesByIdFromCurrentType(1);

        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= rowsCount; i += rowsCount)
        {
            // Выбираем порцию услуг для текущего ряда
            var rowServices = services.Skip(i).Take(rowsCount);

            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(service => InlineKeyboardButton.WithCallbackData(text: $"{service.Title} {service.Price}",
                    callbackData: service.Title.ToLower()))
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