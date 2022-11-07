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
        [Required(ErrorMessage="Title is required")]
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
    }
}
