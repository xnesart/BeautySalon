using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using BeautySalon.BLL.Clents;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Models.Output_Models;
using BeautySalon.DAL;
using BeautySalon.TG.MessageHandlers;
using BeuatySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace BeautySalon.TG;

public class Program
{
    public static List<int> Chats { get; set; }
    public static string Callback { get; set; }
    public static long ChatId { get; set; }
    public static List<AllServicesByIdFromCurrentTypeOutputModel> CurrentServices { get; set; }

    static void Main(string[] args)
    {
        IServiceClient serviceClient = new ServiceClient();
        serviceClient.GetAllServicesByIdFromCurrentType(1);
        var cts = new CancellationTokenSource(); //это токен связи
        var cancellationToken = cts.Token;

        var receiverOptions = new ReceiverOptions()
        {
            AllowedUpdates = [UpdateType.Message, UpdateType.CallbackQuery],
            ThrowPendingUpdates = true
        };
        try
        {
            TelegramClientInstance.Client.StartReceiving
            (
                HandleUpdate,
                HandleError,
                receiverOptions,
                cancellationToken
            );
            string end = "";
            do
            {
                end = Console.ReadLine();
            } while (end != "end");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static async void HandleUpdate(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        if (update?.Message != null && botClient != null)
        {
            if (update.Type == UpdateType.Message)
            {
                ChatId = update.Message.Chat.Id;
                if (update.Message.Text == "/start")
                {
                    UserWelcomeHandler welcomeHandler = new UserWelcomeHandler();
                    welcomeHandler.WelcomeUser(botClient, update, cancellationToken);
                }

                Console.WriteLine($"{update.Message.Chat.Id} {update.Message.Chat.FirstName} {update.Message.Text}");
            }
            else if (update.Type == UpdateType.CallbackQuery)
            {
                var callbackQuery = update.CallbackQuery;
                var data = callbackQuery.Data;
            }
        }

        //здесь мы распознаем и выводим нажатые кнопки
        else if (update.CallbackQuery != null || update.CallbackQuery.Data != null)
        {
            if (update.CallbackQuery.Data == "записаться")
            {
                ServicesHandler servicesHandler = new ServicesHandler();
                servicesHandler.ShowServices(botClient, update, cancellationToken);
            }

            if (update.CallbackQuery.Data == "вернуться в главное меню")
            {
                ServicesHandler servicesHandler = new ServicesHandler();
                servicesHandler.GetBackToMenu(botClient, update, cancellationToken);
            }

            if (update.CallbackQuery.Data == "стрижка")
            {
                ServicesHandler servicesHandler = new ServicesHandler();
                servicesHandler.ChoseHaircut(botClient, update, cancellationToken);
            }

            ServiceClient serviceClient = new ServiceClient();
            CurrentServices = serviceClient.GetAllServicesByIdFromCurrentType(1);
            foreach (var service in CurrentServices)
            {
                if (service.Title.ToLower() == update.CallbackQuery.Data)
                {
                    ShiftsHandler shiftsHandler = new ShiftsHandler();
                    shiftsHandler.ChoseShift(botClient, update, cancellationToken);
                }
            }
            
        }

        // botClient.SendTextMessageAsync(update.Message.Chat.Id,
        //     $" {update.Message.Chat.FirstName} {update.Message.Chat.LastName} сам ты {update.Message.Text}");
    }

    public static void HandleError(ITelegramBotClient botClient, Exception exception,
        CancellationToken cancellationToken)
    {
    }
}