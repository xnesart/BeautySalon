using BeautySalon.TG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.States.MasterState
{
    public class Rest : AbstarctMasterPasswordSendMessageMethodState
    {
        public override AbstarctMasterPasswordSendMessageMethodState SendMessage(long chatId, Update update, CancellationToken cancellationToken, InlineKeyboardMarkup replyMarkup)
        {
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Неверный пароль. Попробуйте ввести другой пароль:",
                replyMarkup: replyMarkup,
                cancellationToken: cancellationToken
             );
            return this;
        }
    }
}
