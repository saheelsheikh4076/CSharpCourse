namespace MVCProject.ViewModels
{
    public class AccountIndexViewModel
    {
        public List<Book> Books { get; set; }
    }
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }       
    }
}
