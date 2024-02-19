using BeautySalon.BLL;
using BeautySalon.BLL.Client;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.Models.Output_Models;
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
    public int? GetUserByChatId(long chatId) 
    { 
        UserClient client= new UserClient();
        List<UsersByChatIdOutputModel> result =  client.GetUsersByChatId((int)chatId);

        bool isUserRegistered = result.Count > 0;

        if (isUserRegistered)
        {
            return result[0].Id;
        }
        else
        {
            return null;
        }

    }

    // public int GetFreeMasterIdByIntervalId(IntervalIdInputModel model)
    // {
    //     IIntervalsClient intervalsClient = new IntervalsClient();
    //     var newModel= intervalsClient.GetFreeMasterIdByIntervalId(model);
    //     foreach (var item in newModel)
    //     {
    //         return item.MasterId;
    //     }
    //     return -1;
    // }

}