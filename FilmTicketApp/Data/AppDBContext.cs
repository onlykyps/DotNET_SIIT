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
            // Configure all foreign keys to use NoAction to prevent cascade conflicts
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            modelBuilder.Entity<Cinema>().HasKey(c => c.Id);
            modelBuilder.Entity<Cinema>().Property(c => c.Id).ValueGeneratedOnAdd();

            // Seat configurations
            modelBuilder.Entity<Seat>().HasKey(s => s.Id);
            modelBuilder.Entity<Seat>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Seat>().HasIndex(s => new { s.CinemaId, s.Row, s.SeatNumber }).IsUnique();

            // Configure Seat relationships
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Cinema)
                .WithMany()
                .HasForeignKey(s => s.CinemaId)
                .OnDelete(DeleteBehavior.NoAction);

            // TicketType configurations
            modelBuilder.Entity<TicketType>().HasKey(tt => tt.Id);
            modelBuilder.Entity<TicketType>().Property(tt => tt.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TicketType>().Property(tt => tt.Price).HasColumnType("TEXT").HasConversion<string>();

            // TicketReservation configurations
            modelBuilder.Entity<TicketReservation>().HasKey(tr => tr.Id);
            modelBuilder.Entity<TicketReservation>().Property(tr => tr.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TicketReservation>().Property(tr => tr.TotalAmount).HasColumnType("TEXT").HasConversion<string>();
            modelBuilder.Entity<TicketReservation>().HasIndex(tr => tr.BookingReference).IsUnique();

            // Configure cascade behavior to prevent multiple cascade paths
            modelBuilder.Entity<TicketReservation>()
                .HasOne(tr => tr.Seat)
                .WithMany(s => s.Reservations)
                .HasForeignKey(tr => tr.SeatId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TicketReservation>()
                .HasOne(tr => tr.TicketType)
                .WithMany(tt => tt.Reservations)
                .HasForeignKey(tr => tr.TicketTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TicketReservation>()
                .HasOne(tr => tr.Session)
                .WithMany(s => s.TicketReservations)
                .HasForeignKey(tr => tr.SessionId)
                .OnDelete(DeleteBehavior.NoAction);

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
