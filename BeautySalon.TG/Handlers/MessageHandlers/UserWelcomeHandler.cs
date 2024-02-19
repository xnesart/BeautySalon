using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.MessageHandlers;

public class UserWelcomeHandler
{
    public async void WelcomeUser(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        //botClient.SendTextMessageAsync(update.Message.Chat.Id,$"Добро пожаловать к виртуальному помощнику сети салонов красоты \"Beautiful girl\", ${update.Message.Chat.Username}!\n\nДля новых клиентов у нас действует скидка 10% (обязательно ею воспользуйся!).");
        
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            // first row
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "Как добраться", callbackData: "как добраться"),
                InlineKeyboardButton.WithCallbackData(text: "Записаться", callbackData: "записаться"),
            },
            // second row
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "Мои записи", callbackData: "мои записи"),
                InlineKeyboardButton.WithCallbackData(text: "Оставить отзыв", callbackData: "22"),
            },
        });

        if (update.Message != null)
        {
            Message sendMessage = await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: $"Добро пожаловать к виртуальному помощнику сети салонов красоты \"Beautiful girl\", !\n\nДля новых клиентов у нас действует скидка 10% (обязательно ею воспользуйся!).",
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
        }
        else
        {
            Message sendMessage = await botClient.SendTextMessageAsync(
                chatId: update.CallbackQuery.From.Id,
                text: $"Добро пожаловать к виртуальному помощнику сети салонов красоты \"Beautiful girl\", !\n\nДля новых клиентов у нас действует скидка 10% (обязательно ею воспользуйся!).",
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
        }
    
    }
    public async void WelcomeUserFromButton(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            // first row
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "Как добраться", callbackData: "11"),
                InlineKeyboardButton.WithCallbackData(text: "Записаться", callbackData: "записаться"),
            },
            // second row
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "Мои записи", callbackData: "мои записи"),
                InlineKeyboardButton.WithCallbackData(text: "Оставить отзыв", callbackData: "22"),
            },
        });

        Message sentMessage = await botClient.SendTextMessageAsync(
            chatId: update.CallbackQuery.From.Id,
            text: $"$\"Добро пожаловать к виртуальному помощнику сети салонов красоты \\\"Beautiful girl\\\", !\\n\\nДля новых клиентов у нас действует скидка 10% (обязательно ею воспользуйся!).",
            replyMarkup: inlineKeyboard,
            cancellationToken: cancellationToken);
    }
}