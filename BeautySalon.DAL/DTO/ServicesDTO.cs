using System;

namespace BeautySalon.DAL.DTO
{
    public class ServicesDTO
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Duratoin { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
