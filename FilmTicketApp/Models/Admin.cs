using System.ComponentModel.DataAnnotations;

namespace FilmTicketApp.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Password Hash")]
        public string PasswordHash { get; set; } = string.Empty;
        
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        [Display(Name = "Last Login")]
        public DateTime? LastLogin { get; set; }
        
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;
    }
}