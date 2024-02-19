using BeautySalon.BLL.Models;
using BeuatySalon.TG.Handlers.MessageHandlers;
using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public class IntervalsState:AbstractState
{
    public int ShiftId { get; set; }
    public int TypeId { get; set; }
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
            
            string intervalTitle = update.CallbackQuery.Data;
            foreach (var interval in _intervals)
            {
                if (interval.Title.ToLower() == update.CallbackQuery.Data.ToLower())
                {
                    this.IntervalId = interval.Id;
                }
            }
       
            //Передаем в стейт интервалов выбранный айди смены.
            return new RegistrationStateName(ShiftId, IntervalId,ServiceId, TypeId);
        }
        return new StartState();
    }
}