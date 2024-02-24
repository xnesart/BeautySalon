using System;
using System.Collections.Generic;

namespace BeautySalon.DAL.DTO;

public class GetAllOrdersOnTodayForMasterDTO
{
    public DateTime Date { get; set; }
    public  ServicesDTO Services { get; set; }
    public UsersDTO Master { get; set; }
    public UsersDTO Client { get; set; }
    public IntеrvalsDTO Intervals { get; set; }
    public OrdersDTO Orders { get; set; }

}