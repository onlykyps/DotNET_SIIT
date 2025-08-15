using FilmTicketApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmTicketApp.Data
{
   public class AppDBContext: DbContext
   {
      public AppDBContext(DbContextOptions<AppDBContext> dbContextOp): base(dbContextOp)
      {
         
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<ActorToFilm>().HasKey(atf => new
         {
            atf.FilmID,
            atf.ActorID
         });

         modelBuilder.Entity<ActorToFilm>().HasOne( f => f.Film)
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
   }
}
