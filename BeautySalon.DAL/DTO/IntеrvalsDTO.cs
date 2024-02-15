using System;
using System.Collections.Generic;

namespace BeautySalon.DAL.DTO
{
    public class IntеrvalsDTO
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public int? ShiftId { get; set; }
        public List<ShiftsDTO>? Shifts { get; set; }
        public DateTime? StartTime { get; set; }
        public bool? IsBusy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}