using BeautySalon.TG.MessageHandlers;
using BeuatySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class ShiftState:AbstractState
{
    public ShiftState(int typeId)
    {
        TypeId = typeId;
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
            return new IntervalsState(ShiftId, TypeId);
        }
        return new StartStateFromButton();
    }
}