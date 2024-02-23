using BeautySalon.TG.MessageHandlers;
using BeautySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class ShiftState:AbstractState
{
    public int ShiftId { get; set; }
    public ShiftState(int typeId, int serviceId)
    {
        TypeId = typeId;
        ServiceId = serviceId;
    }
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        ShiftsHandler shiftsHandler = new ShiftsHandler();
        shiftsHandler.ChoseShift(SingletoneStorage.GetStorage().Client, update, cancellationToken);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            ShiftId = int.Parse(update.CallbackQuery.Data);
            Console.WriteLine(ShiftId);
            //Передаем в стейт интервалов выбранный айди смены.
            return new IntervalsState(ShiftId, TypeId, ServiceId);
        }
        return new StartState();
    }
}