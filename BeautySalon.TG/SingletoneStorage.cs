using BeautySalon.DAL;
using BeautySalon.TG.States;
using Microsoft.VisualBasic;
using Telegram.Bot;

namespace BeautySalon.TG;

public class SingletoneStorage
{
    private static SingletoneStorage _object = null;
    
    public ITelegramBotClient Client { get; private set; }
    
    public Dictionary<long, AbstractState> Clients { get; private set; }
    
    private SingletoneStorage()
    {
        Client = new TelegramBotClient(Options.TelegramToken);

        Clients = new Dictionary<long, AbstractState>();
    }

    public static SingletoneStorage GetStorage()
    {
        if(_object is null)
        {
            _object = new SingletoneStorage();
        }
        return _object;
    }
}