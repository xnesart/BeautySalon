using BeautySalon.BLL;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Models;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.Handlers.MessageHandlers;

public class UserHandler
{
    public async void AddUserToDB(AddUserByChatIdInputModel model)
    {
        //botClient.SendTextMessageAsync(update.Message.Chat.Id,$"Добро пожаловать к виртуальному помощнику сети салонов красоты \"Beautiful girl\", ${update.Message.Chat.Username}!\n\nДля новых клиентов у нас действует скидка 10% (обязательно ею воспользуйся!).");
        IUserClient client = new UserClient();
        client.AddUserByChatId(model);
    }

    public List<ClientByNameAndPhoneOutputModel> GetClientByNameAndPhone(string name, string phone)
    {
        IUserClient client = new UserClient();
        return client.GetClientByNameAndPhone(name, phone);
    }
}