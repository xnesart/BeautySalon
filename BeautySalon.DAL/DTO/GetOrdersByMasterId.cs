using System;

namespace BeautySalon.DAL.DTO;

public class GetOrdersByMasterId
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int IntervalId { get; set; }
    
    public string IntervalTitle { get; set; }
    
    public UsersDTO Client { get; set; }
    public UsersDTO Master { get; set; }
    public ServicesDTO Services { get; set; }
}