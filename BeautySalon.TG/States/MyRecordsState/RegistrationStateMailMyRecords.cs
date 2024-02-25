using BeautySalon.TG.States;
using BeautySalon.TG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Reflection;
using BeautySalon.BLL.Models;
using BeautySalon.TG.Handlers.MessageHandlers;

namespace BeautySalon.TG.States.MyRecordsState
{
    public class RegistrationStateMailMyRecords : AbstractState
    {
        public async override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
        {
            await SingletoneStorage.GetStorage().Client
                .SendTextMessageAsync(chatId, "Пожалуйста, укажите Ваш e-mail для подписки на рассылку спецпредложений (по желанию):");
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            this.Mail = update?.Message.Text;
            SingletoneStorage.GetStorage().Client
            .SendTextMessageAsync(update.Message.Chat.Id, "Благодарим за регистрацию! Будем рады видеть Вас в нашем салоне. Хорошего дня!");
            long id = update.Message.Chat.Id;
            UserHandler userHandler = new UserHandler();
            AddUserByChatIdInputModel model = new AddUserByChatIdInputModel
            {
                ChatId = Convert.ToInt32(id),
                Name = Name,
                Phone = Phone,
                Mail = Mail,
                RoleId = 1,
            };
            userHandler.AddUserToDB(model);
            return new StartState();
        }
    }
}
