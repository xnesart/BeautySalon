using BeautySalon.BLL;
using BeautySalon.BLL.IClient;
using BeautySalon.BLL.Models;
using BeautySalon.BLL.Models.InputModels;
using BeuatySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class RegistrationStateMail:AbstractState
{
    public RegistrationStateMail(int serviceID, int shiftId, int intervalId,  int typeId, string name, string phone)
    {
        ServiceId = serviceID;
        ShiftId = shiftId;
        IntervalId = intervalId;
        TypeId = typeId;
        Name = name;
        Phone = phone;
    }

    public async override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        await SingletoneStorage.GetStorage().Client
            .SendTextMessageAsync(chatId, "Пожалуйста укажите Ваш e-mail для рассылки спецпредложений (по желанию):");
        
    }

    public override  AbstractState ReceiveMessage(Update update)
    {
        Mail = update?.Message.Text;
        UserName = update?.Message.Chat.Username;
         SingletoneStorage.GetStorage().Client
            .SendTextMessageAsync(update.Message.Chat.Id, "Будем рады видеть Вас в нашем салоне!\nНаш администратор свяжется с Вами накануне посещения для подтверждения Вашего визита. Хорошего дня!");
         long id = update.Message.Chat.Id;
         UserHandler userHandler = new UserHandler();
         AddUserByChatIdInputModel model = new AddUserByChatIdInputModel
         {
             ChatId = Convert.ToInt32(id),
             UserName = UserName,
             Name = Name,
             Phone = Phone,
             Mail = Mail,
             Salary = 0,
             RoleId = 2,
             IsDeleted = 0,
             IsBlocked = 0,
         };
         // NewOrderInputModel order = new NewOrderInputModel
         // {
         //    Date = DateTime.Today,
         //    MasterId = 2,
         //    ClientId = 
         // }
         userHandler.AddUserToDB(model);
        //Здесь надо зарегать пользователя в системе, затем создать заказ.
         // TODO
         //OrderHandler orderHandler = new OrderHandler();
         
         return new StartState();
    }
}