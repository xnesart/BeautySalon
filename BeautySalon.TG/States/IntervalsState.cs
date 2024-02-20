using BeautySalon.BLL.Models;
using BeautySalon.BLL.Models.InputModels;
using BeuatySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class IntervalsState:AbstractState
{
    private List<IntervalsIdTitleStartTimeOutputModel> _intervals { get; set; }
    public IntervalsState(int shiftId, int typeId, int serviceId)
    {
        ShiftId = shiftId;
        TypeId = typeId;
        ServiceId = serviceId;
    }
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        IntervalsHanlder intervalsHanlder = new IntervalsHanlder();
        
        Console.WriteLine(ShiftId);
        intervalsHanlder.GetFreeIntervalsOnCurrentShift(SingletoneStorage.GetStorage().Client, update, cancellationToken, this.ShiftId);
        _intervals = intervalsHanlder.ListOfFreeIntervals;
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            foreach (var interval in _intervals)
            {
                if (interval.Title.ToLower() == update.CallbackQuery.Data.ToLower())
                {
                    this.IntervalId = interval.Id;
                }
            }

            UserHandler userHandler = new UserHandler();
            long chatId = update.CallbackQuery.From.Id;
            int? userId = userHandler.GetUserByChatId(chatId);

            bool isUserRegistered = userId != null;

            if  (isUserRegistered == true)
            {

                OrderHandler orderHandler = new OrderHandler();
                NewOrderInputModel orderInputModel = new NewOrderInputModel
                {
                    
                    ClientId = (int)userId,
                    MasterId = (int)userId,
                    ServiceId = ServiceId,
                    IntervalId = IntervalId,
                    Date = DateTime.Now,
                };
                orderHandler.CreateNewOrder(orderInputModel);

                return new StartState();

            }
            else
            {
                return new RegistrationStateName(ShiftId, IntervalId, ServiceId, TypeId);
            }
        }

        return new StartState();
    }
}