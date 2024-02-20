using BeautySalon.BLL;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.MessageHandlers;

public class UserWelcomeHandler
{
    public async void WelcomeUser(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        UserClient userClient = new UserClient();
        string name = "";
        if (update.Message != null)
        {
            var userChatId = userClient.GetUserByChatId((int)update.Message.Chat.Id);
            foreach (var item in userChatId)
            {
                name = item.Name;
            }
        }
        else if (update.CallbackQuery != null)
        {
            var userChatId = userClient.GetUserByChatId((int)update.CallbackQuery.From.Id);
            foreach (var item in userChatId)
            {
                name = item.Name;
            }
        }

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
                InlineKeyboardButton.WithCallbackData(text: "Оставить отзыв", callbackData: "22"),
            },
        });

        if (update.Message != null)
        {
            if (name != null && name != "")
            {
                Message sendMessage = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text:
                    $"Рады снова видеть Вас в виртуальной сети салона \"Beautiful girl\", {name}!",
                    replyMarkup: inlineKeyboard,
                    cancellationToken: cancellationToken);
            }
            else
            {
                Message sendMessage = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text:
                    $"Добро пожаловать к виртуальному помощнику сети салонов красоты \"Beautiful girl\", {update.Message.Chat.Username}!\n\nДля новых клиентов у нас действует скидка 10% (обязательно ею воспользуйся!).",
                    replyMarkup: inlineKeyboard,
                    cancellationToken: cancellationToken);
            }
        }
        else
        {
            if (name != null && name != "")
            {
                Message sendMessage = await botClient.SendTextMessageAsync(
                    chatId: update.CallbackQuery.From.Id,
                    text:
                    $"Рады снова видеть Вас в виртуальной сети салона \"Beautiful girl\", {name}!",
                    replyMarkup: inlineKeyboard,
                    cancellationToken: cancellationToken);
            }
            else
            {
                Message sendMessage = await botClient.SendTextMessageAsync(
                    chatId: update.CallbackQuery.From.Id,
                    text:
                    $"Добро пожаловать к виртуальному помощнику сети салонов красоты \"Beautiful girl\", {update.CallbackQuery.From.Username}!\n\nДля новых клиентов у нас действует скидка 10% (обязательно ею воспользуйся!).",
                    replyMarkup: inlineKeyboard,
                    cancellationToken: cancellationToken);
            }
        }
    }

    public async void WelcomeUserFromButton(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            // first row
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Как добраться", callbackData: "11"),
                InlineKeyboardButton.WithCallbackData(text: "Записаться", callbackData: "записаться"),
            },
            // second row
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Мои записи", callbackData: "мои записи"),
                InlineKeyboardButton.WithCallbackData(text: "Оставить отзыв", callbackData: "22"),
            },
        });

        Message sentMessage = await botClient.SendTextMessageAsync(
            chatId: update.CallbackQuery.From.Id,
            text:
            $"$\"Добро пожаловать к виртуальному помощнику сети салонов красоты \\\"Beautiful girl\\\", !\\n\\nДля новых клиентов у нас действует скидка 10% (обязательно ею воспользуйся!).",
            replyMarkup: inlineKeyboard,
            cancellationToken: cancellationToken);
    }
}