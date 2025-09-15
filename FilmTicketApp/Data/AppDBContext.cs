using FilmTicketApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmTicketApp.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> dbContextOp) : base(dbContextOp)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorToFilm>().HasKey(atf => new
            {
                atf.FilmID,
                atf.ActorID
            });

            modelBuilder.Entity<Actor>().HasKey(c => c.Id);
            modelBuilder.Entity<Actor>().Property(c => c.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Film>().HasKey(c => c.Id);
            modelBuilder.Entity<Film>().Property(c => c.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Producer>().HasKey(c => c.Id);
            modelBuilder.Entity<Producer>().Property(c => c.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Cinema>().HasKey(c => c.Id);
            modelBuilder.Entity<Cinema>().Property(c => c.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<ActorToFilm>().HasOne(f => f.Film)
                                                .WithMany(f => f.FilmActors)
                                                .HasForeignKey(f => f.FilmID);

            modelBuilder.Entity<ActorToFilm>().HasOne(a => a.Actor)
                                                .WithMany(a => a.ActorFilms)
                                                .HasForeignKey(a => a.ActorID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<ActorToFilm> ActorToFilm { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<TicketReservation> TicketReservations { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
