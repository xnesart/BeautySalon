using BeautySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeautySalon.TG.States.Schedule;

// public class RemoveMasterFromShiftCompleteState: AbstractState
// {
//     public RemoveMasterFromShiftCompleteState(string password, int masterId)
//     {
//         Password = password;
//         MasterId = masterId;
//     }
//
//     public int MasterId { get; set; }
//
//     public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken, int masterId)
//     {
//         ShiftsHandler shiftsHandler = new ShiftsHandler();
//         shiftsHandler.RemoveMasterFromShift(SingletoneStorage.GetStorage().Client, update, cancellationToken, masterId);
//         SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выбранный сотрудник удален из выбранной смены.");
//         InlineKeyboardMarkup inlineKeyboard = new(new[]
//         {
//             new[]
//             {
//                 InlineKeyboardButton.WithCallbackData(text: "Вернуться в меню администратора",
//                     callbackData: "вернуться в главное меню"),
//             },
//         });
//         SingletoneStorage.GetStorage().Client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
//             "Выберите действие:",
//             replyMarkup: inlineKeyboard);
//     }
//
//     public override AbstractState ReceiveMessage(Update update)
//     {
//         return new AdminControlPanelState(Password);
//     }
// }