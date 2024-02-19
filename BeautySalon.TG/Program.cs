using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using BeautySalon.BLL.Clents;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Models.Output_Models;
using BeautySalon.DAL;
using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.States;
using BeuatySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace BeautySalon.TG;

public class Program
{
    public Dictionary<long, AbstractState> ClientState { get; set; }
    public static List<AllServicesByIdFromCurrentTypeOutputModel> CurrentServices { get; set; }

    static void Main(string[] args)
    {
        // IServiceClient serviceClient = new ServiceClient();
        // CurrentServices = serviceClient.GetAllServicesByIdFromCurrentType(1);
        var cts = new CancellationTokenSource(); //это токен связи
        var cancellationToken = cts.Token;

        var receiverOptions = new ReceiverOptions()
        {
            AllowedUpdates = [UpdateType.Message, UpdateType.CallbackQuery],
            ThrowPendingUpdates = true
        };
        try
        {
            SingletoneStorage.GetStorage().Client.StartReceiving
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
        catch (NullReferenceException e)
        {
            Console.WriteLine(e);
        }
    }

    public static async void HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        try
        {
            
            var client = SingletoneStorage.GetStorage().Clients;
            long id;
            if (update.Message != null)
            {
                 id = update.Message.Chat.Id;
            }

            if(isButtonPushed)
            {
                chatId = update.CallbackQuery.From.Id;
            }

            bool isNewUser = !handlersStatesByChatIdDictionary.ContainsKey(chatId);


            if (isNewUser)
            {
                handlersStatesByChatIdDictionary.Add(chatId, new StartState());
            }
            else
            {
                handlersStatesByChatIdDictionary[chatId] = handlersStatesByChatIdDictionary[chatId].ReceiveMessage(update);
            }
            
            handlersStatesByChatIdDictionary[chatId].SendMessage(chatId,update, cancellationToken);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e);
        }
        
    }

    public static void HandleError(ITelegramBotClient botClient, Exception exception,
        CancellationToken cancellationToken)
    {
    }
}