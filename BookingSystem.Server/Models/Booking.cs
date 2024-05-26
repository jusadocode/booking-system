namespace BookingSystem.Server.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
        public decimal CleaningFee = 20m;
        public decimal BreakfastFee = 15m;
        public int BreakfastRequests { get; set; } = 0; // Amount of people choosing to take the breakfast option

        public decimal TotalPrice
        {
            get
            {
                int numberOfNights = (CheckOutDate.ToDateTime(TimeOnly.MinValue) - CheckInDate.ToDateTime(TimeOnly.MinValue)).Days;
                return numberOfNights * (Room.Price + BreakfastRequests * BreakfastFee) + CleaningFee;
            }
        }

        public Booking() { }
    }
}
