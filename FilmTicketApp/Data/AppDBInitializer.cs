using FilmTicketApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace FilmTicketApp.Data
{
   public class AppDBInitializer
   {
      public static void Seed(IApplicationBuilder appBuilder)
      {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();

                context.Database.EnsureCreated();

                // Admin seeding is now handled by AdminController.SeedAdmin()

                // Seed Cinemas
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Main Theater",
                            Logo = "https://images.unsplash.com/photo-1489599735734-79b4169c2a78?w=500&h=300&fit=crop",
                            Description = "Our main theater with state-of-the-art seating and sound system"
                        }
                    });
                    context.SaveChanges();
                }

                // Seed TicketTypes
                if (!context.TicketTypes.Any())
                {
                    context.TicketTypes.AddRange(new List<TicketType>()
                    {
                        new TicketType()
                        {
                            Category = TicketCategory.Full,
                            Name = "Full Price",
                            Price = 30.00m,
                            Description = "Standard adult ticket",
                            Is3D = false,
                            IsReduced = false
                        },
                        new TicketType()
                        {
                            Category = TicketCategory.FullWith3D,
                            Name = "Full Price + 3D Glasses",
                            Price = 32.00m,
                            Description = "Adult ticket with 3D glasses",
                            Is3D = true,
                            IsReduced = false
                        },
                        new TicketType()
                        {
                            Category = TicketCategory.Reduced,
                            Name = "Reduced Price",
                            Price = 20.00m,
                            Description = "Student/Senior discount ticket",
                            Is3D = false,
                            IsReduced = true
                        },
                        new TicketType()
                        {
                            Category = TicketCategory.ReducedWith3D,
                            Name = "Reduced Price + 3D Glasses",
                            Price = 22.00m,
                            Description = "Discount ticket with 3D glasses",
                            Is3D = true,
                            IsReduced = true
                        }
                    });
                    context.SaveChanges();
                }

                // Seed Films
                if (!context.Films.Any())
                {
                    context.Films.AddRange(new List<Film>()
                    {
                        new Film()
                        {
                            Title = "The Matrix Resurrections",
                            Description = "Return to the world of The Matrix in this mind-bending sequel.",
                            DurationMinutes = 148,
                            Genre = "Sci-Fi",
                            Rating = "R",
                            ReleaseDate = new DateTime(2021, 12, 22),
                            IsActive = true
                        },
                        new Film()
                        {
                            Title = "Spider-Man: No Way Home",
                            Description = "Peter Parker's secret identity is revealed to the entire world.",
                            DurationMinutes = 148,
                            Genre = "Action",
                            Rating = "PG-13",
                            ReleaseDate = new DateTime(2021, 12, 17),
                            IsActive = true
                        },
                        new Film()
                        {
                            Title = "Dune",
                            Description = "A mythic and emotionally charged hero's journey.",
                            DurationMinutes = 155,
                            Genre = "Sci-Fi",
                            Rating = "PG-13",
                            ReleaseDate = new DateTime(2021, 10, 22),
                            IsActive = true
                        }
                    });
                    context.SaveChanges();
                }

                // Seed Sessions
                if (!context.Sessions.Any())
                {
                    var Films = context.Films.ToList();
                    var cinemas = context.Cinemas.ToList();

                    if (Films.Any() && cinemas.Any())
                    {
                        var sessions = new List<Session>();
                        var today = DateTime.Today;

                        foreach (var cinema in cinemas)
                        {
                            foreach (var Film in Films)
                            {
                                // Create sessions for the next 7 days
                                for (int day = 0; day < 7; day++)
                                {
                                    var sessionDate = today.AddDays(day);

                                    // Morning session
                                    sessions.Add(new Session
                                    {
                                        FilmId = Film.Id,
                                        CinemaId = cinema.Id,
                                        SessionDate = sessionDate,
                                        StartTime = new TimeSpan(10, 0, 0), // 10:00 AM
                                        EndTime = new TimeSpan(10, 0, 0).Add(TimeSpan.FromMinutes(Film.DurationMinutes + 30)), // Film + 30 min buffer
                                        IsActive = true,
                                        CreatedDate = DateTime.Now
                                    });

                                    // Afternoon session
                                    sessions.Add(new Session
                                    {
                                        FilmId = Film.Id,
                                        CinemaId = cinema.Id,
                                        SessionDate = sessionDate,
                                        StartTime = new TimeSpan(14, 30, 0), // 2:30 PM
                                        EndTime = new TimeSpan(14, 30, 0).Add(TimeSpan.FromMinutes(Film.DurationMinutes + 30)),
                                        IsActive = true,
                                        CreatedDate = DateTime.Now
                                    });

                                    // Evening session
                                    sessions.Add(new Session
                                    {
                                        FilmId = Film.Id,
                                        CinemaId = cinema.Id,
                                        SessionDate = sessionDate,
                                        StartTime = new TimeSpan(19, 0, 0), // 7:00 PM
                                        EndTime = new TimeSpan(19, 0, 0).Add(TimeSpan.FromMinutes(Film.DurationMinutes + 30)),
                                        IsActive = true,
                                        CreatedDate = DateTime.Now
                                    });
                                }
                            }
                        }

                        context.Sessions.AddRange(sessions);
                        context.SaveChanges();
                    }
                }

                // Seed Seats for each cinema (20x20 grid)
                if (!context.Seats.Any())
                {
                    var cinemas = context.Cinemas.ToList();
                    var seats = new List<Seat>();

                    foreach (var cinema in cinemas)
                    {
                        for (int row = 1; row <= 20; row++)
                        {
                            for (int seatNumber = 1; seatNumber <= 20; seatNumber++)
                            {
                                seats.Add(new Seat
                                {
                                    Row = row,
                                    SeatNumber = seatNumber,
                                    IsOccupied = false,
                                    CinemaId = cinema.Id,
                                    CreatedDate = DateTime.Now
                                });
                            }
                        }
                    }

                    context.Seats.AddRange(seats);
                    context.SaveChanges();
                }
            }


        }
    }
}
