using System.ComponentModel.DataAnnotations;

namespace FilmTicketApp.Models
{
   public class Producer
   {
      [Key]
      public int Id { get; set; }
       
      [Display(Name = "Profile Picture")]
      public string ProfilePicture { get; set; }

      [Display(Name = "Full Name")]
      public string FullName { get; set; }

      [Display(Name = "Biography")]
      public string Biography { get; set; }

      public List<Film> Films { get; set; }  

   }
}
