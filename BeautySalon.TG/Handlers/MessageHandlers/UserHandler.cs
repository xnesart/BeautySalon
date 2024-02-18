using BeautySalon.BLL;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Models;
using BeautySalon.DAL.DTO;
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

}