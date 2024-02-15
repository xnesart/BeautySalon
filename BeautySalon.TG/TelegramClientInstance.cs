using BeautySalon.DAL;
using Telegram.Bot;

namespace BeautySalon.TG;

public class TelegramClientInstance
{
    private static readonly ITelegramBotClient _client = new TelegramBotClient(Options.TelegramToken);

    public static ITelegramBotClient Client => _client;
}