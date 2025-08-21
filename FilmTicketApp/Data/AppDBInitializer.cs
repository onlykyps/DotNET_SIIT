using FilmTicketApp.Models;

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

            if (!context.Cinemas.Any())
            {
               context.Cinemas.AddRange(new List<Cinema>()
               {
                  new Cinema()
                  {
                     Name = "Cinema 1",
                     Logo = "https://unsplash.com/photos/turned-on-capitol-theatre-neon-light-signage-IOr6a62l4L4",
                     Description = "Cinema description"
                  },
                  new Cinema()
                  {
                     Name = "Cinema 2",
                     Logo = "https://unsplash.com/photos/red-and-white-concrete-building-7kBkJbhl7IY",
                     Description = "Cinema description"
                  },
                  new Cinema()
                  {
                     Name = "Cinema 3",
                     Logo = "https://unsplash.com/photos/blue-and-red-neon-sign-NFBhiOLH-l8",
                     Description = "Cinema description"
                  },
                  new Cinema()
                  {
                     Name = "Cinema 4",
                     Logo = "https://unsplash.com/photos/a-movie-theater-at-night-with-lights-on-7-N13Zl_DAQ",
                     Description = "Cinema description"
                  },
               });
               context.SaveChanges();
            }

            if (!context.Actors.Any())
            {
               context.Actors.AddRange(new List<Actor>()
               {
                  new Actor()
                  {
                     ProfilePicture = "Imgs\\photo-1578671815798-7b9b0ab22d73.jpeg",
                     FullName = "Actor 1",
                     Biography = "Actor description"
                  },
                  new Actor()
                  {
                     ProfilePicture = "Imgs\\photo-1609293519338-9e7a88404068.jpeg",
                     FullName = "Actor 2",
                     Biography = "Actor description"
                  },
                  new Actor()
                  {
                     ProfilePicture = "https://images.unsplash.com/photo-1578671815798-7b9b0ab22d73?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                     FullName = "Actor 3",
                     Biography = "Actor description"
                  },
                  new Actor()
                  {
                     ProfilePicture = "https://unsplash.com/photos/a-movie-theater-at-night-with-lights-on-7-N13Zl_DAQ",
                     FullName = "Actor 4",
                     Biography = "Actor description"
                  },
               });
               context.SaveChanges();
            }

            if (!context.Producers.Any())
            {
               context.Producers.AddRange(new List<Producer>()
               {
                  new Producer()
                  {
                     FullName = "Actor 1",
                     ProfilePicture = "https://unsplash.com/photos/turned-on-capitol-theatre-neon-light-signage-IOr6a62l4L4",
                     Biography = "Actor description"
                  },
                  new Producer()
                  {
                     FullName = "Actor 2",
                     ProfilePicture = "https://unsplash.com/photos/red-and-white-concrete-building-7kBkJbhl7IY",
                     Biography = "Actor description"
                  },
                  new Producer()
                  {
                     FullName = "Actor 3",
                     ProfilePicture = "https://unsplash.com/photos/blue-and-red-neon-sign-NFBhiOLH-l8",
                     Biography = "Actor description"
                  },
                  new Producer()
                  {
                     FullName = "Actor 4",
                     ProfilePicture = "https://unsplash.com/photos/a-movie-theater-at-night-with-lights-on-7-N13Zl_DAQ",
                     Biography = "Actor description"
                  },
               });
               context.SaveChanges();
            }

            if (!context.Films.Any())
            {
               context.Films.AddRange(new List<Film>()
               {
                  new Film()
                  {
                     Name = "Film 1",
                     ImageURL = "https://unsplash.com/photos/turned-on-capitol-theatre-neon-light-signage-IOr6a62l4L4",
                     Description = "Film description",
                     StartDate = DateTime.Now.AddDays(-10),
                     EndDate = DateTime.Now.AddDays(-2),
                     CinemaID = 1,
                     ProducerID = 3,
                     FilmGenre = Enums.FilmGenre.Action,
                     Price = 3.5

                  },
                  new Film()
                  {
                     Name = "Film 2",
                     ImageURL = "https://unsplash.com/photos/red-and-white-concrete-building-7kBkJbhl7IY",
                     Description = "Film description",
                     StartDate = DateTime.Now.AddDays(10),
                     EndDate = DateTime.Now.AddDays(2),
                     CinemaID = 1,
                     ProducerID = 3,
                     FilmGenre = Enums.FilmGenre.Documentary,
                     Price = 3.5

                  },
                  new Film()
                  {
                     Name = "Film 3",
                     ImageURL = "https://unsplash.com/photos/blue-and-red-neon-sign-NFBhiOLH-l8",
                     Description = "Film description",
                     StartDate = DateTime.Now.AddDays(-15),
                     EndDate = DateTime.Now.AddDays(-3),
                     CinemaID = 2,
                     ProducerID = 2,
                     FilmGenre = Enums.FilmGenre.Comedy,
                     Price = 3.5

                  },
                  new Film()
                  {
                     Name = "Actor 4",
                     ImageURL = "https://unsplash.com/photos/a-movie-theater-at-night-with-lights-on-7-N13Zl_DAQ",
                     Description = "Film description",
                     StartDate = DateTime.Now.AddDays(-18),
                     EndDate = DateTime.Now.AddDays(4),
                     CinemaID = 3,
                     ProducerID = 1,
                     FilmGenre = Enums.FilmGenre.Drama,
                     Price = 3.5

                  },
               });
               context.SaveChanges();
            }

            if (!context.ActorToFilm.Any())
            {
               context.ActorToFilm.AddRange(new List<ActorToFilm>()
               {
                  new ActorToFilm()
                  {
                     ActorID = 1,
                     FilmID = 1
                  },
                  new ActorToFilm()
                  {
                     ActorID = 3,
                     FilmID = 3
                  },
                  new ActorToFilm()
                  {
                     ActorID = 3,
                     FilmID = 2
                  },
                  new ActorToFilm()
                  {
                    ActorID = 2,
                    FilmID = 2
                  },
               });
               context.SaveChanges();
            }

         }


      }
   }
}
