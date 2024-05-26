using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using BookingSystem.Server.Models;
using System.Collections.Generic;

namespace BookingSystem.Server.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookingContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookingContext>>()))
            {
                // Ensure the database is created.
                context.Database.EnsureCreated();

                // Check if any hotels exist.
                if (context.Hotel.Any())
                {
                    return; // Database has been seeded
                }

                // Seed hotels and rooms
                var hotels = new[]
                {
                    new Hotel
                    {
                        Name = "Grand Hotel",
                        Address = "123 Main St, Springfield",
                        ImageUrl = "https://149345965.v2.pressablecdn.com/wp-content/uploads/img-hotels-IADGV_006-Dusk-Exterior-home.jpg",
                        Rooms = new List<Room>
                        {
                            new Room("Standart room with garden view", RoomType.Standart, 3),
                            new Room("Standart room with garden view", RoomType.Standart, 3),
                            new Room("Deluxe room with sea view", RoomType.Deluxe, 3),
                            new Room("Suite room with luxury amenities", RoomType.Suite, 3)
                        }
                    },
                    new Hotel
                    {
                        Name = "Ocean Breeze Hotel",
                        Address = "456 Ocean Ave, Miami",
                        ImageUrl = "https://images.unsplash.com/photo-1587213811864-46e59f6873b1?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Rooms = new List<Room>
                        {
                            new Room("Standart room with pool view", RoomType.Standart, 2),
                            new Room("Deluxe room with beach access", RoomType.Deluxe, 2),
                            new Room("Suite room with private balcony", RoomType.Suite, 2)
                        }
                    },
                    new Hotel
                    {
                        Name = "Purple Forest Hotel",
                        Address = "12 Wolf Street, Portland",
                        ImageUrl = "https://images.unsplash.com/photo-1517840901100-8179e982acb7?q=80&w=870&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Rooms = new List<Room>
                        {
                            new Room("Perfect place to stay for an evening", RoomType.Standart, 1),
                            new Room("Deluxe room with beach access", RoomType.Deluxe, 2),
                            new Room("Suite room with private balcony", RoomType.Suite, 1)
                        }
                    },
                    new Hotel
                    {
                        Name = "Mountain View Inn",
                        Address = "789 Mountain Rd, Denver",
                        ImageUrl = "https://images.unsplash.com/photo-1542314831-068cd1dbfeeb?q=80&w=870&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Rooms = new List<Room>
                        {
                            new Room("Cozy cabin room with mountain view", RoomType.Standart, 4),
                            new Room("Luxury suite with hot tub", RoomType.Suite, 4),
                            new Room("Family room with kitchenette", RoomType.Deluxe, 4)
                        }
                    },
                    new Hotel
                    {
                        Name = "City Lights Hotel",
                        Address = "101 City Center Blvd, New York",
                        ImageUrl = "https://images.unsplash.com/photo-1542314831-068cd1dbfeeb?q=80&w=870&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Rooms = new List<Room>
                        {
                            new Room("Modern room with city view", RoomType.Standart, 5),
                            new Room("Executive suite with office", RoomType.Suite, 5),
                            new Room("Penthouse suite with rooftop access", RoomType.Suite, 5)
                        }
                    },
                    new Hotel
                    {
                        Name = "Sunset Resort",
                        Address = "202 Sunset Dr, Malibu",
                        ImageUrl = "https://images.unsplash.com/photo-1517840901100-8179e982acb7?q=80&w=870&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Rooms = new List<Room>
                        {
                            new Room("Beachfront room with sunset view", RoomType.Standart, 2),
                            new Room("Premium suite with ocean view", RoomType.Suite, 2),
                            new Room("Family suite with two bedrooms", RoomType.Deluxe, 2)
                        }
                    },
                    new Hotel
                    {
                        Name = "Forest Retreat",
                        Address = "303 Forest Ln, Asheville",
                        ImageUrl = "https://images.unsplash.com/photo-1580041065738-e72023775cdc?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Rooms = new List<Room>
                        {
                            new Room("Cabin room with forest view", RoomType.Standart, 3),
                            new Room("Deluxe cabin with fireplace", RoomType.Deluxe, 3),
                            new Room("Treehouse suite with canopy view", RoomType.Suite, 3)
                        }
                    },
                    new Hotel
                    {
                        Name = "Riverside Hotel",
                        Address = "404 River St, Chicago",
                        ImageUrl = "https://images.unsplash.com/photo-1517840901100-8179e982acb7?q=80&w=870&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Rooms = new List<Room>
                        {
                            new Room("River view room", RoomType.Standart, 2),
                            new Room("Deluxe room with balcony", RoomType.Deluxe, 2),
                            new Room("Suite with river access", RoomType.Suite, 2)
                        }
                    },
                    new Hotel
                    {
                        Name = "Desert Oasis",
                        Address = "505 Desert Rd, Phoenix",
                        ImageUrl = "https://images.unsplash.com/photo-1566073771259-6a8506099945?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Rooms = new List<Room>
                        {
                            new Room("Oasis view room", RoomType.Standart, 1),
                            new Room("Luxury tent with amenities", RoomType.Deluxe, 1),
                            new Room("Desert suite with panoramic view", RoomType.Suite, 1)
                        }
                    },
                    new Hotel
                    {
                        Name = "Snowy Peaks Hotel",
                        Address = "606 Snowy Rd, Aspen",
                        ImageUrl = "https://images.unsplash.com/photo-1580041065738-e72023775cdc?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Rooms = new List<Room>
                        {
                            new Room("Cozy room with snow view", RoomType.Standart, 4),
                            new Room("Ski-in/ski-out suite", RoomType.Suite, 4),
                            new Room("Family chalet with kitchen", RoomType.Deluxe, 4)
                        }
                    }
                };

                context.Hotel.AddRange(hotels);
                context.SaveChanges();

                // var bookings = new[]
                // {
                //     new Booking
                //     {
                //         CheckInDate = new DateOnly(2024, 5, 24),
                //         CheckOutDate = new DateOnly(2024, 5, 27),
                //         Room = new Room("Cozy room with snow view", RoomType.Standart, 4),
                //         Hotel = context.Hotel.FirstOrDefault(h => h.Name == "Grand Hotel"),
                //         BreakfastRequests = 3
                //     },
                // };

                // context.Booking.AddRange(bookings);
                // context.SaveChanges();
            }
        }
    }
}
