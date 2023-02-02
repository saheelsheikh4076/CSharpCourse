using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using MVCProject.Data;
using Services;
using System.Collections.Generic;
using ViewModels;

namespace MVCProject.Services
{
    public class StudentServiceEF1 : IStudent
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IDataProtector protector;
        public StudentServiceEF1(ApplicationDbContext dbContext, IDataProtectionProvider dataProtectionProvider)
        {
            this.protector = dataProtectionProvider.CreateProtector("Irfan");
            this.dbContext = dbContext;
        }
        public async Task AddStudent(StudentViewModel student)
        {
            StudentTable1 model = new StudentTable1
            {
                Name = student.Name,
                Age = student.Age,
                Gender = student.Gender == 1 ? "Male" : "Female"
            };
            await dbContext.StudentTable1.AddAsync(model);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(string id)
        {
            var intId = Convert.ToInt32(protector.Unprotect(id));
            var student = await dbContext.StudentTable1.FindAsync(intId);
            if (student != null)
            {
                dbContext.StudentTable1.Remove(student);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<StudentViewModel>> GetAllStudents()
        {
            var studets = await dbContext.StudentTable1.Select(s=>new StudentViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
                Gender = s.Gender == "Male"? (byte)1:(byte)2
            }).ToListAsync();
            studets.ForEach(s => s.ProtectedId = protector.Protect(s.Id.ToString()));
            return studets;
        }

        public async Task<StudentViewModel> GetStudentById(string id)
        {
            var intId = Convert.ToInt32(protector.Unprotect(id));

            var student = await dbContext.StudentTable1.FindAsync(intId);
            StudentViewModel model = new StudentViewModel();
            if (student != null)
            {
                model.Id = student.Id;
                model.ProtectedId = id;// protector.Protect(intId.ToString());
                model.Name = student.Name;
                model.Gender = student.Gender == "Male"? (byte)1 :(byte)2;
                model.Age = student.Age;
            }
            return model;
        }

        public async Task UpdateStudent(StudentViewModel student)
        {
            var intId = Convert.ToInt32(protector.Unprotect(student.ProtectedId));

            var model = await dbContext.StudentTable1.FindAsync(intId);
            if (model != null)
            {
                model.Name = student.Name;
                model.Age = student.Age;
                model.Gender = student.Gender == 1 ? "Male" : "Female";
                await dbContext.SaveChangesAsync();
            }
        }

    }
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
                    //GenderTable gender = new GenderTable()
                    //{
                    //    Gender = "Male"
                    //};
                    //await dbContext.GenderTable.AddAsync(gender);
                    //await dbContext.SaveChangesAsync();
                    //If error occurs here
                    //Here we can get id of above table
                    StudentTable std = new StudentTable
                    {
                        Name = student.Name,
                        GenderTableId = 10,
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
