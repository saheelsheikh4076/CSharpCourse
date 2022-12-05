using Microsoft.AspNetCore.DataProtection;
using MVCProject.Data;
using Services;
using ViewModels;

namespace MVCProject.Services
{
    public class StudentServiceEF : IStudent
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IDataProtector protector;
        public StudentServiceEF(ApplicationDbContext dbContext, IDataProtectionProvider dataProtectionProvider)
        {
            this.protector = dataProtectionProvider.CreateProtector("Irfan");
            this.dbContext = dbContext;
        }
        public void AddStudent(StudentViewModel student)
        {
            StudentTable std = new StudentTable
            {
                Name = student.Name,
                Gender = student.Gender,
                Age = student.Age,
            };
            dbContext.StudentTable.Add(std);
            dbContext.SaveChanges();
        }

        public void DeleteStudent(string id)
        {
            var student = dbContext.StudentTable.Find(id);
            if(student!=null)
            {
                dbContext.StudentTable.Remove(student);
                dbContext.SaveChanges();
            }
        }

        public List<StudentViewModel> GetAllStudents()
        {
            var students = dbContext.StudentTable.Select(s=>new StudentViewModel
            {
                Name = s.Name,
                Gender = s.Gender,
                Age = s.Age,
                Id = s.Id
            }).ToList();
            students.ForEach(s => s.ProtectedId = protector.Protect(s.Id.ToString()));
            return students;
        }

        public StudentViewModel GetStudentById(string id)
        {
            StudentViewModel model = new StudentViewModel();
            var _id = Convert.ToInt32(protector.Unprotect(id));
            var student = dbContext.StudentTable.Find(_id);
            if (student != null)
            {
                model.Id = student.Id;
                model.ProtectedId = protector.Protect(student.Id.ToString());
                model.Name = student.Name;
                model.Age = student.Age; 
                model.Gender = student.Gender;
            }
            return model;
        }

        public void UpdateStudent(StudentViewModel student)
        {
            var _id = Convert.ToInt32(protector.Unprotect(student.ProtectedId));
            var std = dbContext.StudentTable.Find(_id);
            if (std != null)
            {
                std.Name = student.Name;
                std.Age = student.Age;
                std.Gender = student.Gender;
                dbContext.SaveChanges();
            }
        }
    }
}
