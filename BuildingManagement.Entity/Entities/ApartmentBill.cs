namespace BuildingManagement.Entity.Entities
{
    public class ApartmentBill
    {
        public int Id { get; set; }
        public int? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public decimal ElectricityAmount { get; set; }
        public decimal WaterAmount { get; set; }
        public decimal GasAmount { get; set; }
        public bool IsPaid { get; set; } = false;
        //public Payment Payment { get; set; }
    }
}
