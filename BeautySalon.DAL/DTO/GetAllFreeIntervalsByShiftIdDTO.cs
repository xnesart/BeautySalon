using System;
using System.Collections.Generic;

namespace BeautySalon.DAL.DTO;

public class GetAllFreeIntervalsByShiftIdDTO
{
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime StartTime { get; set; }
}