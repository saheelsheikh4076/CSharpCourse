using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            this.Name = string.Empty;
        }
        public string? ProtectedId { get; set; }
        [Display(Name="Unique ID")]
        public int Id { get; set; }
        [Display(Name="Full Name")]
        public string Name { get; set; }
        public int? Age { get; set; }
        public byte? Gender { get; set; }
    }
}