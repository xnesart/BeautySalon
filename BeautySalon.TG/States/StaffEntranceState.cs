using BeautySalon.TG;
using BeautySalon.TG.States;
using BeuatySalon.TG.Handlers.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace BeuatySalon.TG.States
{
    public class StaffEntranceState : AbstractState
    {
        private PasswordHandlers _passwordHandlers { get; set; }

        public StaffEntranceState(PasswordHandlers password)
        {
            password = _passwordHandlers;
        }

        public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                      chatId: update.CallbackQuery.From.Id,
                      text: $"Введите пароль :",
                      cancellationToken: cancellationToken
                   );
        }
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery && UpdateType.CallbackQuery != null)
            {
                if (update.CallbackQuery.Data.ToLower() == "Я сотрудник")
                {
                    // Проверяем, соответствует ли введенный пароль сохраненному
                    var enteredPassword = update.CallbackQuery.Message.Text;
                    var storedPassword = _passwordHandlers.GetPassword(enteredPassword);

                }
                if (storedPassword != null)
                {
                    // Если пароль совпадает, меняем состояние на новое
                    return new AdminState();
                }
                else
                {
                    // Если пароль не совпадает, отправляем сообщение об ошибке
                    // ...
                }

            }
        }
    }
}
