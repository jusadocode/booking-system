namespace BookingSystem.Server.Models
{
    public class Room
    {
        public int ID { get; set; }

        public decimal Price => RoomType switch
        {
            RoomType.Standart => 100m,
            RoomType.Deluxe => 150m,
            RoomType.Suite => 200m,
            _ => throw new ArgumentOutOfRangeException()
        };

        public string? Summary { get; set; }
        public RoomType RoomType { get; set; }
        public int NumOfGuests { get; set; }

        public Room(string? summary, RoomType roomType, int numberOfguests)
        {
            Summary = summary;
            RoomType = roomType;
            NumOfGuests = numberOfguests;
        }

        public Room() { }
    }

    public enum RoomType
    {
        Standart,
        Deluxe,
        Suite
    }
}
