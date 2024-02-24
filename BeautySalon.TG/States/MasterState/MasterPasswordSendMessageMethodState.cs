using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BeuatySalon.TG.States.MasterState
{
    public abstract class AbstarctMasterPasswordSendMessageMethodState 
    {
        public abstract AbstarctMasterPasswordSendMessageMethodState SendMessage(long chatId, Update update, CancellationToken cancellationToken, InlineKeyboardMarkup replyMarkup);
    }
}
