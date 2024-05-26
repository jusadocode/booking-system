using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingSystem.Server.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }


        public List<Room> Rooms { get; set; } = new List<Room>();

        public Hotel(string name, string location, List<Room> rooms, string imgUrl)
        {
            Name = name;
            ImageUrl = imgUrl;
            Address = location;
            Rooms = rooms;
        }

        public Hotel() { }


    }




}
