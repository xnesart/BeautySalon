using BeautySalon.BLL;
using BeautySalon.BLL.Models;
using BeautySalon.DAL;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BeuatySalon.TG;

public class Program
{
    public static List<AllChatIdOutputModel> Chats { get; set; }
    static void Main(string[] args)
    {
        UserClient userClient = new UserClient();
        Chats = userClient.GetAllChatId();
        ITelegramBotClient client = new TelegramBotClient(Options.TelegramToken);
        var cts = new CancellationTokenSource(); //это токен связи
        var cancellationToken = cts.Token;

        var receiverOptions = new ReceiverOptions()
        {
            AllowedUpdates = [UpdateType.Message, UpdateType.CallbackQuery],
            ThrowPendingUpdates = true
        };

        client.StartReceiving
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
        } while ( end != "end");
    }

    public static void HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == UpdateType.Message)
        {
            Console.WriteLine($"{update.Message.Chat.Id} {update.Message.Chat.FirstName} {update.Message.Text}");
        }

        foreach (var chat in Chats)
        {
            if (chat.ChatId == 301921042)
            {
                botClient.SendTextMessageAsync(update.Message.Chat.Id,
                    $" {update.Message.Chat.FirstName} {update.Message.Chat.LastName} Здравствуй, о Администратор)))");
            }

            if (chat.ChatId != update.Message.Chat.Id)
            {
                
            }
        }
        botClient.SendTextMessageAsync(update.Message.Chat.Id,
            $" {update.Message.Chat.FirstName} {update.Message.Chat.LastName} сам ты {update.Message.Text}");

    }

    public static void HandleError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {

    }
}