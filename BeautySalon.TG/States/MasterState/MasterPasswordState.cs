using BeautySalon.BLL;
using BeautySalon.TG;
using BeautySalon.TG.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using System.ComponentModel.Design;
using System.Runtime.ExceptionServices;

namespace BeuatySalon.TG.States.MasterState
{
    public class MasterPasswordState : AbstractState
    {
        public AbstarctMasterPasswordSendMessageMethodState state { get; set; }

        public MasterPasswordState()
        {
            this.state = new First();
        }
        public override AbstractState ReceiveMessage(Update update)
        {
            Password = update.Message.Text;

            UserClient userClient = new UserClient();
            
            string? masterName = userClient.GetWorkerNameByPassword(Password);

            if (masterName != null)
            {
                userClient.ChangeChatIdAndUserNameByPassword(Password, (int)update.Message.Chat.Id, update.Message.Chat.Username);

                return new MasterMenuState();
            }
            else 
            {
                return this;
            }
        }

        public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            this.state = this.state.SendMessage(chatId, update, cancellationToken, new InlineKeyboardMarkup(
                        [
                            [InlineKeyboardButton.WithCallbackData(text: "Верунться в главное меню", callbackData: "Верунться в главное меню")],
                        ]
                    ));
        }
    }
}
