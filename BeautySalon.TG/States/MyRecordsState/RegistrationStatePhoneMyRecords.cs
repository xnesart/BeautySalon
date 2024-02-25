using BeautySalon.TG.States;
using BeautySalon.TG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace BeautySalon.TG.States.MyRecordsState
{
    public class RegistrationStatePhoneMyRecords : AbstractState
    {

        public async override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            await SingletoneStorage.GetStorage().Client
                .SendTextMessageAsync(chatId, "Пожалуйста введите Ваш актуальный номер телефона для связи:");
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            this.Phone = update?.Message.Text;
            return new RegistrationStateMailMyRecords() { Phone = this.Phone, Name = this.Name };
        }
    }
}
