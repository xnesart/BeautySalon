using BeautySalon.TG;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.States.Employees.AddWorkers;

public class AddWorkersMailState:AbstractState
{
    public AddWorkersMailState(string password, int roleId, string name, string phone)
    {
        Password = password;
        RoleId = roleId;
        Name = name;
        Phone = phone;
    }
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в меню администратора",
                    callbackData: "вернуться в главное меню"),
            },
        });
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat.Id,
            "Введите e-mail сотрудника для связи:",
            replyMarkup: inlineKeyboard);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery != null)
        {
            return new AdminControlPanelState(Password);
        }
        else
        {
            string mail = update.Message.Text;
            return new AddWorkersCompleteState(Password, RoleId, Name,Phone ,mail);
        }
    }
}