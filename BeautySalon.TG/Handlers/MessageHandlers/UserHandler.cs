using BeautySalon.BLL;
using BeautySalon.BLL.Client;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.Models.Output_Models;
using BeautySalon.DAL.DTO;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.Handlers.MessageHandlers;

public class UserHandler
{
    public async void AddUserToDB(AddUserByChatIdInputModel model)
    {
        IUserClient client = new UserClient();
        client.AddUserByChatId(model);
    }

    public int GetClientByNameAndPhone(string name, string phone)
    {
        IUserClient client = new UserClient();
        List<ClientByNameAndPhoneOutputModel> models = client.GetClientByNameAndPhone(name, phone);
        foreach (var model in models)
        {
            return (int)model.Id;
        }
        return 0;
    }

    public int GetMasterByNameAndPhone(string name, string phone)
    {
        IUserClient client = new UserClient();
        List<MasterByNameAndPhoneOutputModel> masters = client.GetMasterByNameAndPhone(name, phone);
        List<MasterByNameAndPhoneOutputModel> models = client.GetMasterByNameAndPhone(name, phone);
        foreach (var model in models)
        {
            return (int)model.Id;
        }
        return 0;
    }

    public int? GetUserByChatId(long chatId)
    {
        UserClient client = new UserClient();
        List<BeautySalon.BLL.Models.Output_Models.UserByChatIdOutputModel> result = client.GetUserByChatId((int)chatId);
        List<BeautySalon.BLL.Models.Output_Models.UserByChatIdOutputModel> filteredResult =
            result.Where((user) => user.IsDeleted == false).ToList();
        bool isUserRegistered = result.Count > 0;
        if (isUserRegistered)
        {
            return result[0].Id;
        }
        else
        {
            return null;
        }
    }

    public int GetFreeMasterIdByIntervalId(int interval)
    {
        IUserClient userClient = new UserClient();
        int id = userClient.GetFreeMasterByIntervalIdNew(interval);
        return id;
    }

    public async void HowToGet(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithUrl(text: "Проложить маршрут", url: "https://yandex.ru/maps/"),
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

    public async void LeaveFeedback(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            // // first row
            // new[]
            // {
            //     InlineKeyboardButton.WithCallbackData(text: "Написать администратору",
            //         callbackData: "написать администратору"),
            // },
            // second row
            new[]
            {
                InlineKeyboardButton.WithUrl(text: "Перейти на сайт", url: "https://irecommend.ru/"),
            },
            // third row
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                    callbackData: "вернуться в главное меню"),
            },
        });
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите действие:",
            replyMarkup: inlineKeyboard);
    }

    public void GetAllWorkersByRoleId(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        IUserClient userClient = new UserClient();
        var workers = userClient.GetAllWorkersByRoleId();
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= workers.Count; i += rowsCount)
        {
            // Выбираем порцию услуг для текущего ряда
            var rowServices = workers.Skip(i).Take(rowsCount);
            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(worker => InlineKeyboardButton.WithCallbackData(text: $"{worker.Name} {worker.RoleId}",
                    callbackData: worker.Id.ToString()))
                .ToArray();
            // Добавляем массив кнопок в список
            buttons.Add(row);
        }
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Добавить сотрудника",
                callbackData: "добавить сотрудника")
        });
        //добавляем вернуться в главное меню
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                callbackData: "вернуться в главное меню")
        });
        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
        botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "Выберите сотрудника, которого хотите удалить из базы, или другое действие:",
            replyMarkup: inlineKeyboard);
    }

    public async void RemoveWorkerGetButtons(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Удалить сотрудника",
                    callbackData: "удалить сотрудника"),
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

    public async void RemoveWorkerById(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken,
        int workerId)
    {
        IUserClient userClient = new UserClient();
        UserIdInputModel model = new UserIdInputModel
        {
            Id = workerId
        };
        userClient.RemoveUserById(model);
    }

    public async void AddWorkersStateGetButtons(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Администратор",
                    callbackData: "администратор"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Мастер",
                    callbackData: "мастер"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                    callbackData: "вернуться в главное меню"),
            },
        });
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите роль сотрудника:",
            replyMarkup: inlineKeyboard);
    }
    
    public async void AddWorkerByRoleId(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken,int roleId, string name,
         string phone, string mail)
    {
        UserClient userClient = new UserClient();
        WorkerByRoleIdInputModel model = new WorkerByRoleIdInputModel
        {
            Name = name,
            RoleId = roleId,
            Mail = mail,
            Phone = phone
        };
        userClient.AddWorkerByRoleId(model);
    }
}