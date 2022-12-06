using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services
{
    public interface IStudent
    {
        Task<StudentViewModel> GetStudentById(string id);
        Task UpdateStudent(StudentViewModel student);
        Task AddStudent(StudentViewModel student);
        Task DeleteStudent(string id);
        Task<List<StudentViewModel>> GetAllStudents();
    }
}
