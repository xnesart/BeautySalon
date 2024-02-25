using System.Runtime.InteropServices.JavaScript;
using BeautySalon.BLL.Clients;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.Models.InputModels;
using BeautySalon.BLL.Models.Output_Models;
using BeautySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.MessageHandlers;

public class ServicesHandler
{
    public static List<AllServicesByIdFromCurrentTypeOutputModel> Services { get; set; }

    public async void GetBackToMenu(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Как добраться", callbackData: "как добраться"),
                InlineKeyboardButton.WithCallbackData(text: "Записаться", callbackData: "записаться"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Мои записи", callbackData: "мои записи"),
                InlineKeyboardButton.WithCallbackData(text: "Оставить отзыв", callbackData: "оставить отзыв"),
            },
        });
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Главное меню",
            replyMarkup: inlineKeyboard);
    }

    public async void ShowServices(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        ITypeClient typeClient = new TypeClient();
        var types = typeClient.GetAllServiceTypes();
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= types.Count; i += rowsCount)
        {
            // Выбираем порцию услуг для текущего ряда
            var rowServices = types.Skip(i).Take(rowsCount);
            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(type => InlineKeyboardButton.WithCallbackData(text: $"{type.Title} ",
                    callbackData: type.Title.ToString()))
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
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "Выберите интересующий Вас тип услуг:",
            replyMarkup: inlineKeyboard);
    }

    public async void ShowServicesForModify(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        ITypeClient typeClient = new TypeClient();
        var types = typeClient.GetAllServiceTypes();
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= types.Count; i += rowsCount)
        {
            // Выбираем порцию услуг для текущего ряда
            var rowServices = types.Skip(i).Take(rowsCount);
            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(type => InlineKeyboardButton.WithCallbackData(text: $"{type.Title} ",
                    callbackData: type.Title.ToString()))
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
        if (update.Message != null)
        {
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Выберите интересующий Вас тип услуг:",
                replyMarkup: inlineKeyboard);
        }
        else
        {
            await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
                "Выберите интересующий Вас тип услуг:",
                replyMarkup: inlineKeyboard);
        }
    }

    public async void ChoseMakeUp(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        ServiceClient serviceClient = new ServiceClient();
        var services = serviceClient.GetAllServicesByIdFromCurrentType(1);
        Services = serviceClient.GetAllServicesByIdFromCurrentType(1);
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= services.Count; i += rowsCount)
        {
            // Выбираем порцию услуг для текущего ряда
            var rowServices = services.Skip(i).Take(rowsCount);
            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(service => InlineKeyboardButton.WithCallbackData(text: $"{service.Title} {service.Price}",
                    callbackData: service.Id.ToString()))
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
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "В нашем салоне доступны следующие услуги по визажу:",
            replyMarkup: inlineKeyboard);
    }

    public async void ChoseMakeUpForModify(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        ServiceClient serviceClient = new ServiceClient();
        var services = serviceClient.GetAllServicesByIdFromCurrentType(1);
        Services = serviceClient.GetAllServicesByIdFromCurrentType(1);
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= services.Count; i += rowsCount)
        {
            // Выбираем порцию услуг для текущего ряда
            var rowServices = services.Skip(i).Take(rowsCount);
            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(service => InlineKeyboardButton.WithCallbackData(text: $"{service.Title} {service.Price}",
                    callbackData: service.Id.ToString()))
                .ToArray();
            // Добавляем массив кнопок в список
            buttons.Add(row);
        }
        //добавляем Добавить услугу
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Добавить услугу к типу \"Визаж\"",
                callbackData: "добавить услугу к типу \"Визаж\"")
        });
        //добавляем вернуться в главное меню
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                callbackData: "вернуться в главное меню")
        });
        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "В нашем салоне доступны следующие услуги по визажу:",
            replyMarkup: inlineKeyboard);
    }

    public async void ChoseHaircut(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        ServiceClient serviceClient = new ServiceClient();
        var services = serviceClient.GetAllServicesByIdFromCurrentType(2);
        Services = serviceClient.GetAllServicesByIdFromCurrentType(2);
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= services.Count; i += rowsCount)
        {
            // Выбираем порцию услуг для текущего ряда
            var rowServices = services.Skip(i).Take(rowsCount);
            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(service => InlineKeyboardButton.WithCallbackData(text: $"{service.Title} {service.Price}",
                    callbackData: service.Id.ToString()))
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
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "В нашем салоне доступны следующие виды стрижек:",
            replyMarkup: inlineKeyboard);
    }

    public async void ChoseHaircutForModify(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        ServiceClient serviceClient = new ServiceClient();
        var services = serviceClient.GetAllServicesByIdFromCurrentType(2);
        Services = serviceClient.GetAllServicesByIdFromCurrentType(2);
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= services.Count; i += rowsCount)
        {
            // Выбираем порцию услуг для текущего ряда
            var rowServices = services.Skip(i).Take(rowsCount);
            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(service => InlineKeyboardButton.WithCallbackData(text: $"{service.Title} {service.Price}",
                    callbackData: service.Id.ToString()))
                .ToArray();
            // Добавляем массив кнопок в список
            buttons.Add(row);
        }
        //добавляем Добавить услугу
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Добавить услугу к типу \"Стрижка\"",
                callbackData: "добавить услугу к типу \"Стрижка\"")
        });
        //добавляем вернуться в главное меню
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                callbackData: "вернуться в главное меню")
        });
        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "В нашем салоне доступны следующие виды стрижек:",
            replyMarkup: inlineKeyboard);
    }

    public async void ChoseColoring(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        ServiceClient serviceClient = new ServiceClient();
        var services = serviceClient.GetAllServicesByIdFromCurrentType(3);
        Services = serviceClient.GetAllServicesByIdFromCurrentType(3);
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= services.Count; i += rowsCount)
        {
            // Выбираем порцию услуг для текущего ряда
            var rowServices = services.Skip(i).Take(rowsCount);
            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(service => InlineKeyboardButton.WithCallbackData(text: $"{service.Title} {service.Price}",
                    callbackData: service.Id.ToString()))
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
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "В нашем салоне доступны следующие виды окрашивания:",
            replyMarkup: inlineKeyboard);
    }

    public async void ChoseColoringForModify(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        ServiceClient serviceClient = new ServiceClient();
        var services = serviceClient.GetAllServicesByIdFromCurrentType(3);
        Services = serviceClient.GetAllServicesByIdFromCurrentType(3);
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= services.Count; i += rowsCount)
        {
            // Выбираем порцию услуг для текущего ряда
            var rowServices = services.Skip(i).Take(rowsCount);
            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(service => InlineKeyboardButton.WithCallbackData(text: $"{service.Title} {service.Price}",
                    callbackData: service.Id.ToString()))
                .ToArray();
            // Добавляем массив кнопок в список
            buttons.Add(row);
        }
        //добавляем Добавить услугу
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Добавить услугу к типу Окрашивание",
                callbackData: "добавить услугу к типу Окрашивание")
        });
        //добавляем вернуться в главное меню
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                callbackData: "вернуться в главное меню")
        });
        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "В нашем салоне доступны следующие виды окрашивания:",
            replyMarkup: inlineKeyboard);
    }

    public async void ChoseStyling(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        ServiceClient serviceClient = new ServiceClient();
        var services = serviceClient.GetAllServicesByIdFromCurrentType(4);
        Services = serviceClient.GetAllServicesByIdFromCurrentType(4);
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= services.Count; i += rowsCount)
        {
            // Выбираем порцию услуг для текущего ряда
            var rowServices = services.Skip(i).Take(rowsCount);
            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(service => InlineKeyboardButton.WithCallbackData(text: $"{service.Title} {service.Price}",
                    callbackData: service.Id.ToString()))
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
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "В нашем салоне доступны следующие услуги по моделированию причёски:",
            replyMarkup: inlineKeyboard);
    }

    public async void ChoseStylingForModify(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        ServiceClient serviceClient = new ServiceClient();
        var services = serviceClient.GetAllServicesByIdFromCurrentType(4);
        Services = serviceClient.GetAllServicesByIdFromCurrentType(4);
        List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
        int rowsCount = 2;
        for (int i = 0; i <= services.Count; i += rowsCount)
        {
            // Выбираем порцию услуг для текущего ряда
            var rowServices = services.Skip(i).Take(rowsCount);
            // Создаем массив кнопок для текущего ряда
            InlineKeyboardButton[] row = rowServices
                .Select(service => InlineKeyboardButton.WithCallbackData(text: $"{service.Title} {service.Price}",
                    callbackData: service.Id.ToString()))
                .ToArray();
            // Добавляем массив кнопок в список
            buttons.Add(row);
        }
        //добавляем Добавить услугу
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Добавить услугу",
                callbackData: "добавить услугу")
        });
        //добавляем вернуться в главное меню
        buttons.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню",
                callbackData: "вернуться в главное меню")
        });
        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(buttons);
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "В нашем салоне доступны следующие услуги по моделированию причёски:",
            replyMarkup: inlineKeyboard);
    }

    public async void ServiceEdit(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Удалить", callbackData: "удалить"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Изменить цену", callbackData: "изменить цену"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Изменить название", callbackData: "изменить название"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Изменить продолжительность",
                    callbackData: "изменить продолжительность"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться к выбору услуги",
                    callbackData: "вернуться к выбору услуги"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться к выбору типа услуг",
                    callbackData: "вернуться к выбору типа услуг"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в меню админа",
                    callbackData: "вернуться в меню админа"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Перейти в меню клиента",
                    callbackData: "перейти в меню клиента"),
            },
        });
        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "Меню редактирования выбранной услуги.",
            replyMarkup: inlineKeyboard);
    }

    public async void ServiceRemove(ITelegramBotClient botClient, Update update, int serviceId)
    {
        IServiceClient serviceClient = new ServiceClient();
        ServiceIdInputModel model = new ServiceIdInputModel
        {
            Id = serviceId
        };
        serviceClient.RemoveServiceById(model);
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться к выбору услуги",
                    callbackData: "вернуться к выбору услуги"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться к выбору типа услуг",
                    callbackData: "вернуться к выбору типа услуг"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в меню админа",
                    callbackData: "вернуться в меню админа"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Перейти в меню клиента",
                    callbackData: "перейти в меню клиента"),
            },
        });
        botClient.SendTextMessageAsync(update.CallbackQuery.From.Id,
            "Выбранная услуга удалена из базы данных.",
            replyMarkup: inlineKeyboard);
    }

    public async void ServiceUpdatePrice(ITelegramBotClient botClient, Update update, int serviceId,
        decimal servicePrice)
    {
        IServiceClient serviceClient = new ServiceClient();
        ServiceIdAndServicePriceInputModel model = new ServiceIdAndServicePriceInputModel
        {
            Id = serviceId,
            Price = servicePrice
        };
        serviceClient.UpdateServicePrice(model);
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться к выбору услуги",
                    callbackData: "вернуться к выбору услуги"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться к выбору типа услуг",
                    callbackData: "вернуться к выбору типа услуг"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в меню админа",
                    callbackData: "вернуться в меню админа"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Перейти в меню клиента",
                    callbackData: "перейти в меню клиента"),
            },
        });
        if (update.Message != null)
        {
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Цена на выбранную услугу изменена.",
                replyMarkup: inlineKeyboard);
        }
        else
        {
            await botClient.SendTextMessageAsync(update.CallbackQuery.From.Id, "Цена на выбранную услугу изменена.");
        }
    }

    public async void ServiceUpdateTitle(ITelegramBotClient botClient, Update update, int serviceId, string title)
    {
        IServiceClient serviceClient = new ServiceClient();
        ServiceIdAndServiceTitleInputModel model = new ServiceIdAndServiceTitleInputModel()
        {
            Id = serviceId,
            Title = title
        };
        serviceClient.UpdateServiceTitle(model);
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться к выбору услуги",
                    callbackData: "вернуться к выбору услуги"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться к выбору типа услуг",
                    callbackData: "вернуться к выбору типа услуг"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в меню админа",
                    callbackData: "вернуться в меню админа"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Перейти в меню клиента",
                    callbackData: "перейти в меню клиента"),
            },
        });
        if (update.Message != null)
        {
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Название выбранной услуги изменено.",
                replyMarkup: inlineKeyboard);
        }
        else
        {
            await botClient.SendTextMessageAsync(update.CallbackQuery.From.Id,
                "Название выбранной услуги изменено.");
        }
    }

    public async void ServiceUpdateDuration(ITelegramBotClient botClient, Update update, int serviceId,
        string duration)
    {
        IServiceClient serviceClient = new ServiceClient();
        ServiceIdAndServiceDurationInputModel model = new ServiceIdAndServiceDurationInputModel
        {
            Id = serviceId,
            Duration = duration
        };
        serviceClient.UpdateServiceDuration(model);
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться к выбору услуги",
                    callbackData: "вернуться к выбору услуги"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться к выбору типа услуг",
                    callbackData: "вернуться к выбору типа услуг"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в меню админа",
                    callbackData: "вернуться в меню админа"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Перейти в меню клиента",
                    callbackData: "перейти в меню клиента"),
            },
        });
        if (update.Message != null)
        {
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Продолжительность выбранной услуги изменена.",
                replyMarkup: inlineKeyboard);
        }
        else
        {
            await botClient.SendTextMessageAsync(update.CallbackQuery.From.Id, "Продолжительность выбранной услуги изменена.");
        }
    }

    public void AddNewService(ITelegramBotClient botClient, Update update, ServiceByIdInputModel model)
    {
        IServiceClient serviceClient = new ServiceClient();
        serviceClient.AddServiceById(model);
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться к выбору услуги",
                    callbackData: "вернуться к выбору услуги"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться к выбору типа услуг",
                    callbackData: "вернуться к выбору типа услуг"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в меню админа",
                    callbackData: "вернуться в меню админа"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Перейти в меню клиента",
                    callbackData: "перейти в меню клиента"),
            },
        });
        botClient.SendTextMessageAsync(update.Message.Chat.Id,
            "Вы успешно добавили новою услугу в базу данных.",
            replyMarkup: inlineKeyboard);
    }
}