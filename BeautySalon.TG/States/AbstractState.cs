using Telegram.Bot.Types;

namespace BeautySalon.TG.States;

public abstract class AbstractState
{
    public  string Name { get; set; }
    public  string UserName { get; set; }
    public  long Id { get; set; }
    public  int ShiftId { get; set; }
    public  int RoleId { get; set; }
    public string ServiceName { get; set; }
    public int ServiceId { get; set; }
    public int IntervalId { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public int TypeId { get; set; }
    public int OrderId { get; set; }
    
    
    public abstract void SendMessage(long chatId, Update update, CancellationToken cancellationToken);
    public abstract AbstractState ReceiveMessage(Update update);
}