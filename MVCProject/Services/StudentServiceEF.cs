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
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    GenderTable gender = new GenderTable()
                    {
                        Gender = "Male"
                    };
                    await dbContext.GenderTable.AddAsync(gender);
                    await dbContext.SaveChangesAsync();
                    //If error occurs here
                    //Here we can get id of above table
                    StudentTable std = new StudentTable
                    {
                        Name = student.Name,
                        GenderTableId = gender.Id,
                        Age = student.Age,
                    };
                    await dbContext.StudentTable.AddAsync(std);
                    await dbContext.SaveChangesAsync();
                    //if control reaches here, it means data saved successfully
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    //Here we can execute code for refund if process fails
                } 
            }
        }

        public async Task DeleteStudent(string id)
        {
            var _id = Convert.ToInt32(protector.Unprotect(id));
            var student = await dbContext.StudentTable.FindAsync(_id);
            var student1 = await dbContext.StudentTable.Where(s => s.Id == _id).SingleOrDefaultAsync();
            var student2 = await dbContext.StudentTable.Where(s => s.Id == _id).FirstOrDefaultAsync();
            var student3 = await dbContext.StudentTable.Where(s => s.Id == _id).LastOrDefaultAsync();
            var student4 = await dbContext.StudentTable.FirstOrDefaultAsync(s => s.Id == _id);

            var student5 = await (from s in dbContext.StudentTable where s.Id == _id select s).FirstOrDefaultAsync();

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
            var studentList1 = await (from s in dbContext.StudentTable select s).ToListAsync();
            foreach (var item in studentList)
            {
                students.Add(new StudentViewModel()
                {
                    Age = item.Age,
                    Name = item.Name,
                    Gender = item.GenderTableId,
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
                model.Gender = student.GenderTableId;
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
                    std.GenderTableId = student.Gender;
                    await dbContext.SaveChangesAsync();
                } 
            }
        }
    }
}
