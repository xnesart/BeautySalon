using System;
using System.Collections.Generic;
using System.Threading;
using BeautySalon.DAL;
using BeautySalon.TG.MessageHandlers;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BeautySalon.TG;

public class Program
{
    public static List<int> Chats { get; set; }

    static void Main(string[] args)
    {
        var cts = new CancellationTokenSource(); //это токен связи
        var cancellationToken = cts.Token;

        var receiverOptions = new ReceiverOptions()
        {
            AllowedUpdates = [UpdateType.Message, UpdateType.CallbackQuery],
            ThrowPendingUpdates = true
        };

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

    public static void HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == UpdateType.Message)
        {
            if (update.Message.Text == "/start")
            {
                UserWelcomeHandler welcomeHandler = new UserWelcomeHandler();
                welcomeHandler.WelcomeUser(botClient, update, cancellationToken);
            }

            Console.WriteLine($"{update.Message.Chat.Id} {update.Message.Chat.FirstName} {update.Message.Text}");
        }

        // botClient.SendTextMessageAsync(update.Message.Chat.Id,
        //     $" {update.Message.Chat.FirstName} {update.Message.Chat.LastName} сам ты {update.Message.Text}");
    }

    public static void HandleError(ITelegramBotClient botClient, Exception exception,
        CancellationToken cancellationToken)
    {
    }
}