namespace BuildingManagement.Entity.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public string BlockInfo { get; set; } = default!;
        public bool OccupancyStatus { get; set; }
        public string ApartmentType { get; set; } = default!;
        public int FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public string OwnerOrTenant { get; set; } = default!;

        //Bir daire bir kullanıcıya aittir (one to one)
        public int? UserId { get; set; }
        public User? User { get; set; }


        // Bir Apartment, birden fazla Dues ve Payment'a sahip olabilir
        public ICollection<Dues>? Dues { get; set; }
        public ICollection<Payment>? Payments { get; set; }


        // Bir Apartment bir Building'e aittir (one to many ilişkisi)
        public int? BuildingId { get; set; }
        public Building? Building { get; set; } = default!;

        // one to many
        public ICollection<ApartmentBill>? ApartmentBills { get; set; }
    }
}
