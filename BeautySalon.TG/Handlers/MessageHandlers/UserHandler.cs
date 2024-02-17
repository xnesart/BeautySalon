using BeautySalon.BLL;
using BeautySalon.BLL.IClient;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.Handlers.MessageHandlers;

public class UserHandler
{
    public UserHandler(int serviceId,int shiftId,int intervalId,int typeId,string name,string phone, long id)
    {
        ServiceId = serviceId
    }
    public async void AddUserToDB(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken )
    {
        //botClient.SendTextMessageAsync(update.Message.Chat.Id,$"Добро пожаловать к виртуальному помощнику сети салонов красоты \"Beautiful girl\", ${update.Message.Chat.Username}!\n\nДля новых клиентов у нас действует скидка 10% (обязательно ею воспользуйся!).");

        IUserClient client = new UserClient();

        client.AddUserByChatId(RegistrationStateMail.);

    }
}