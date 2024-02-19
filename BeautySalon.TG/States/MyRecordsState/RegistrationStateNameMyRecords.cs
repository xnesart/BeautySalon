using BeautySalon.TG.States;
using BeautySalon.TG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace BeuatySalon.TG.States.MyRecordsState
{
    public class RegistrationStateNameMyRecords:AbstractState
    {
        public async override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            await SingletoneStorage.GetStorage().Client
                .SendTextMessageAsync(chatId, "Пожалуйста укажите, как к Вам обращаться");
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            this. Name = update?.Message.Text;
            return new RegistrationStatePhoneMyRecords() { Name = this.Name};
        }
    }
}
