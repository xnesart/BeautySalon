using BeautySalon.TG;
using BeautySalon.TG.States;
using BeuatySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.States.Employees.AddWorkers;

public class AddWorkersCompleteState : AbstractState
{
    public AddWorkersCompleteState(string password, int roleId, string name, string phone, string mail)
    {
        Password = password;
        RoleId = roleId;
        Name = name;
        Phone = phone;
        Mail = mail;
    }

    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        UserHandler userHandler = new UserHandler();
        userHandler.AddWorkerByRoleId(SingletoneStorage.GetStorage().Client, update, cancellationToken, RoleId, Name,
            Phone, Mail);
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Вернуться в меню администратора",
                    callbackData: "вернуться в главное меню"),
            },
        });
        SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat.Id,
            "Сотрудник успешно добавлен",
            replyMarkup: inlineKeyboard);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        return new AdminControlPanelState(Password);
    }
}