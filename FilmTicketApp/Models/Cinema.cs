using FilmTicketApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace FilmTicketApp.Models
{
   public class Cinema: IEntityBase
   {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo picture is required")]
        public string Logo { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
