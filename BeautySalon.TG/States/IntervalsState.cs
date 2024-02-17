using BeuatySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class IntervalsState:AbstractState
{
    public IntervalsState(int shiftId)
    {
        ShiftId = shiftId;
    }
    public override void SendMessage(long chatId, Update update, CancellationToken cancellationToken)
    {
        IntervalsHanlder intervalsHanlder = new IntervalsHanlder();
        
        Console.WriteLine(ShiftId);
        intervalsHanlder.GetFreeIntervalsOnCurrentShift(SingletoneStorage.GetStorage().Client, update, cancellationToken, this.ShiftId);
    }

    public override AbstractState ReceiveMessage(Update update)
    {
        if (update.CallbackQuery.Data != "вернуться в главное меню")
        {
            this.IntervalId = int.Parse(update.CallbackQuery.Data);
            Console.WriteLine(ShiftId);
            //Передаем в стейт интервалов выбранный айди смены.
            return new RegistrationState(ShiftId, IntervalId,ServiceId);
        }
        return new StartStateFromButton();
    }
}