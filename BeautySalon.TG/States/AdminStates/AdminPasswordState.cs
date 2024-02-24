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
        UserClient userClient = new UserClient();
        string adminName = userClient.GetWorkerNameByPassword(update.Message.Text);
        if (adminName != null)
        {
            Password = update.Message.Text;
            userClient.ChangeChatIdAndUserNameByPassword(Password, (int)update.Message.Chat.Id, update.Message.Chat.Username);
            return new AdminControlPanelState(Password);
        }
        else
        {
            return this;
        }
    }
}