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
        List<BeautySalon.BLL.Models.Output_Models.UserByChatIdOutputModel> result =  client.GetUserByChatId((int)chatId);

        List<BeautySalon.BLL.Models.Output_Models.UserByChatIdOutputModel> filteredResult = result.Where((user) => user.IsDeleted == false).ToList();

        bool isUserRegistered = filteredResult.Count > 0;

        if (isUserRegistered)
        {
            return filteredResult[0].Id;
        }
        else
        {
            return null;
        }

    }

    public int GetFreeMasterIdByIntervalId(int interval)
    {
        IUserClient userClient = new UserClient();
        int id = userClient.GetFreeMasterByIntervalIdNew(interval);
        return id;
    }
    
    public async void HowToGet(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            // first row
            new []
            {
                InlineKeyboardButton.WithUrl(text: "Проложить маршрут", url: "https://yandex.ru/maps/"),
            },
            // second row
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в главное меню", callbackData: "вернуться в главное меню"),
            },
        });

        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Список стрижек",
            replyMarkup: inlineKeyboard);
    }

}

public class UserByChatIdOutputModel
{
}