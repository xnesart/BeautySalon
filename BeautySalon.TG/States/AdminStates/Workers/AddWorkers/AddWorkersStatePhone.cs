using BeautySalon.TG;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.States.Employees.AddWorkers;

public class AddWorkersStatePhone:AbstractState
{
    public AddWorkersStatePhone(string password, int roleId, string name)
    {
        Password = password;
        RoleId = roleId;
        Name = name;
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
            "Введите телефон сотрудника:",
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
            string phone = update.Message.Text;
            return new AddWorkersMailState(Password, RoleId, Name, phone);
        }
    }
}