using BeautySalon.TG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;

namespace BeuatySalon.TG.States.MasterState
{
    public class First : AbstarctMasterPasswordSendMessageMethodState
    {
        public override AbstarctMasterPasswordSendMessageMethodState SendMessage(long chatId, Update update, CancellationToken cancellationToken, InlineKeyboardMarkup replyMarkup)
        {
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                chatId: update.CallbackQuery.From.Id,
                text: "Введите Ваш пароль:",
                replyMarkup: replyMarkup,
                cancellationToken: cancellationToken
             );
            return new Rest();
        }
    }
}
