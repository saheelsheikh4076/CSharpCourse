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
        StudentViewModel GetStudentById(string id);
        void UpdateStudent(StudentViewModel student);
        void AddStudent(StudentViewModel student);
        void DeleteStudent(string id);
        List<StudentViewModel> GetAllStudents();
    }
}
