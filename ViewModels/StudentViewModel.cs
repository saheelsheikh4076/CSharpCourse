namespace ViewModels
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            this.Name = string.Empty;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? Gender { get; set; }
    }
}