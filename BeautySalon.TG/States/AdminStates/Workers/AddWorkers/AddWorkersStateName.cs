using BeautySalon.TG;
using BeautySalon.TG.States;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.States.Employees.AddWorkers;

public class AddWorkersStateName:AbstractState
{
    public AddWorkersStateName(string password, int roleId)
    {
        Password = password;
        RoleId = roleId;
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
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
            "Введите имя сотрудника:",
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
            string name = update.Message.Text;
            return new AddWorkersStatePhone(Password, RoleId, name);
        }
    }
}