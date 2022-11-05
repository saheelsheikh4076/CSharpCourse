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
        public string Title { get; set; }
        [Required(ErrorMessage ="Please enter author name")]
        [Display(Name ="Author Name",Prompt ="Enter author name")]
        public string Auth { get; set; }       
    }
}
