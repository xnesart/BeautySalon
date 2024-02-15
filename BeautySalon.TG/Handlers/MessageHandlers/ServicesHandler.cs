using System.Runtime.InteropServices.JavaScript;
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

        // Message sentMessage = await botClient.SendTextMessageAsync(
        //     chatId: update.Message.Chat.Id,
        //     text: "Пожалуйста, выберите услугу",
        //     replyMarkup: inlineKeyboard,
        //     cancellationToken: cancellationToken);
        
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите услугу",
        replyMarkup: inlineKeyboard);
    }
}