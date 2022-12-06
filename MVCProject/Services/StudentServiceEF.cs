using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using MVCProject.Data;
using Services;
using System.Collections.Generic;
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
        public async Task AddStudent(StudentViewModel student)
        {
            StudentTable std = new StudentTable
            {
                Name = student.Name,
                Gender = student.Gender,
                Age = student.Age,
            };
            await dbContext.StudentTable.AddAsync(std);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(string id)
        {
            var _id = Convert.ToInt32(protector.Unprotect(id));
            var student = await dbContext.StudentTable.FindAsync(_id);
            if(student!=null)
            {
                dbContext.StudentTable.Remove(student);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<StudentViewModel>> GetAllStudents()
        {
            //var students = dbContext.StudentTable.Select(s=>new StudentViewModel
            //{
            //    Name = s.Name,
            //    Gender = s.Gender,
            //    Age = s.Age,
            //    Id = s.Id
            //}).ToList();
            //students.ForEach(s => s.ProtectedId = protector.Protect(s.Id.ToString()));
            List<StudentViewModel> students = new List<StudentViewModel>();
            var studentList = await dbContext.StudentTable.ToListAsync();//Tracking Avoid
            foreach (var item in studentList)
            {
                students.Add(new StudentViewModel()
                {
                    Age = item.Age,
                    Name = item.Name,
                    Gender = item.Gender,
                    Id = item.Id,
                    ProtectedId = protector.Protect(item.Id.ToString())
                });
            }
            return students;
        }

        public async Task<StudentViewModel> GetStudentById(string id)
        {
            StudentViewModel model = new StudentViewModel();
            var _id = Convert.ToInt32(protector.Unprotect(id));
            var student = await dbContext.StudentTable.FindAsync(_id);//Avoid Tracking
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

        public async Task UpdateStudent(StudentViewModel student)
        {
            if (!string.IsNullOrEmpty(student.ProtectedId))
            {
                var _id = Convert.ToInt32(protector.Unprotect(student.ProtectedId));
                var std = await dbContext.StudentTable.FindAsync(_id);
                if (std != null)
                {
                    std.Name = student.Name;
                    std.Age = student.Age;
                    std.Gender = student.Gender;
                    await dbContext.SaveChangesAsync();
                } 
            }
        }
    }
}
