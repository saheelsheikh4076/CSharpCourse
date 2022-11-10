using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModels
{
    public class AccountIndexViewModel
    {
        public Book Book { get; set; }
        public List<Book>? Books { get; set; }
    }
    public class Book
    {
        [Required(ErrorMessage=" Please enter book title")]
        [Display(Name ="Book title", Prompt ="Enter book title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please enter author name")]
        [Display(Name ="Author Name",Prompt ="Enter author name")]
        public string Auth { get; set; }
        [Display(Name ="Is published?")]
        public bool IsPublished { get; set; }
        public string Language { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Address { get; set; }
        
        public string Colour { get; set; }
        public string Gender { get; set; }
        public List<string> Tags { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public IFormFile File { get; set; }
    }
}
