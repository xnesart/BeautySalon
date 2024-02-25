using BeautySalon.BLL;
using BeautySalon.TG;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class AdminPasswordState : AbstractState
{
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
            chatId: update.CallbackQuery.From.Id,
            text: "Введите Ваш пароль:"
        );
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        string password = update.Message.Text;
        UserClient userClient = new UserClient();
        string adminName = userClient.GetWorkerNameByPassword(password);
        // var models = userClient.GetWorkerNameAndChatIdAndIdByPassword(password);
        // int? chatId;
        // int? id;
        // foreach (var model in models)
        // {
        //     chatId = model.ChatId;
        //     id = model.Id;
        // }
        if (adminName != "")
        {
            Password = update.Message.Text;
            userClient.ChangeChatIdAndUserNameByPassword(Password, (int)update.Message.Chat.Id, update.Message.Chat.Username);
            return new AdminControlPanelState(Password);
        }else if()
        {
            
        }
        else
        {
            if (update.Message != null)
            {
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat.Id,
                    "Введённый пароль отсутствует в базе. Попробуйте другой пароль или вернитесь в меню клиента.");
                return new AdminState(); 
            }
        }
        return this;
    }
}