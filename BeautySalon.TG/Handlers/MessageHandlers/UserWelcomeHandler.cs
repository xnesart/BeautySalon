using BeautySalon.BLL;
using BeautySalon.BLL.IClient;
using BeuatySalon.TG.States;
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
                InlineKeyboardButton.WithCallbackData(text: "Оставить отзыв", callbackData: "оставить отзыв"),
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
                    $"Добро пожаловать к виртуальному помощнику салона красоты \"Beautiful girl\", {update.Message.Chat.Username}!\nДля новых клиентов у нас действует скидка 10% (обязательно ею воспользуйся!).",
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
                    $"Добро пожаловать к виртуальному помощнику салона красоты \"Beautiful girl\", {update.CallbackQuery.From.Username}!\nДля новых клиентов у нас действует скидка 10% (обязательно ею воспользуйся!).",
                    replyMarkup: inlineKeyboard,
                    cancellationToken: cancellationToken);
            }
        }
    }

    public async void WelcomeAdmin(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        UserClient userClient = new UserClient();

        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            // first row
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Ввести пароль", callbackData: "ввести пароль"),
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню", callbackData: "вернуться в главное меню"),
            },
        });

        if (update.Message != null)
        {
            Message sendMessage = await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text:
                $"Здраствуйте! Введите пароль администратора или вернитесь в главное меню",
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
        }
    }

    public async void WelcomeAdminControl(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken, string password)
    {
        UserClient userClient = new UserClient();

        string name = userClient.GetWorkerNameByPassword(password);

        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Редактировать услугу",
                    callbackData: "редактировать услугу"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Редактировать сотрудника",
                    callbackData: "редактировать сотрудника"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Редактировать расписание",
                    callbackData: "редактировать расписание"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Показать активные записи",
                    callbackData: "показать активные записи"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                    callbackData: "вернуться в главное меню"),
            },
        });

        if (update.Message != null)
        {
            Message sendMessage = await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text:
                $"Добро пожаловать к виртуальному помощнику салона красоты \"Beautiful girl\", {name}!\nЧто Вы хотите сделать?",
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
        }
    }
}