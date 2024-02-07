namespace BeautySalon.DAL.DTO
{
    public class OrdersDTO
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int MasterId { get; set; }

        public int ClientId { get; set; }

        public List<ServicesDTO> services { get; set; }

        public int StartIntervalId { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsCompleted { get; set; }
        

    }

}