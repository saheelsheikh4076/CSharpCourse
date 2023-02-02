using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCProject.Models;
using MVCProject.ViewModels;
using Services;
using System.Data.SqlClient;
using ViewModels;

namespace MVCProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IStudent student;
        private readonly IDataProtector protector;

        public StudentController(IConfiguration configuration, IStudent student,
            IDataProtectionProvider dataProtectionProvider)
        {
            this.protector = dataProtectionProvider.CreateProtector("Irfan");
            this.configuration = configuration;
            this.student = student;
        }
        [HttpGet]
        public async Task<IActionResult> Students()
        {
            var model = await student.GetAllStudents();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentsApi()
        {
            try
            {
                List<StudentViewModel> model = await student.GetAllStudents();
                return Json(new ApiResponse<List<StudentViewModel>>
                {
                    IsSuccess = true,
                    Message = "",
                    Data = model
                });
            }
            catch (Exception ex)
            {
                return Json(new ApiResponse<List<StudentViewModel>>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = new List<StudentViewModel>()
                });
            }
            
        }


        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent(StudentViewModel model)
        {
            //model.Id = 0;
            if (ModelState.IsValid)
            {
                await student.AddStudent(model);
                return RedirectToAction("Students","student");
            }
            //ModelState.AddModelError("", "Its my error");
            return View(model);
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudentApi(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await student.AddStudent(model);
                    return Json(new ApiResponse<string>
                    {
                        IsSuccess = true,
                        Message = "Student added successfully",
                        Data = ""
                    });
                }
                catch (Exception ex)
                {
                    return Json(new ApiResponse<string>
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                        Data = ""
                    });
                }
            }
            else
            {
                var errorList = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                var errors = string.Empty;
                foreach (var error in errorList)
                {
                    errors += error.ToString() + ",";
                }
                return Json(new ApiResponse<string>
                {
                    IsSuccess = false,
                    Message = errors,
                    Data = ""
                });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStudent(string StudentId)
        {
            await student.DeleteStudent(StudentId);
            return RedirectToAction("Students");
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStudentApi(string StudentId)
        {
            try
            {
                await student.DeleteStudent(StudentId);
                return Json(new ApiResponse<string>
                {
                    IsSuccess = true,
                    Message = "Student deleted successfully",
                    Data = ""
                });
            }
            catch (Exception ex)
            {
                return Json(new ApiResponse<string>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = ""
                });
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStudent(string StudentId)
        {
            StudentViewModel model = await student.GetStudentById(StudentId);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentByIdApi(string StudentId)
        {
            try
            {
                StudentViewModel model = await student.GetStudentById(StudentId);
                return Json(new ApiResponse<StudentViewModel>
                {
                    IsSuccess = true,
                    Message = "",
                    Data = model
                });
            }
            catch (Exception ex)
            {
                return Json(new ApiResponse<string>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = ""
                });
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStudent(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                await student.UpdateStudent(model);
                return RedirectToAction("Students");
            }
            return View(model);
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStudentApi(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await student.UpdateStudent(model);
                    return Json(new ApiResponse<string>
                    {
                        IsSuccess = true,
                        Message = "Record updated successfully",
                        Data = ""
                    });
                }
                catch (Exception ex)
                {
                    return Json(new ApiResponse<string>
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                        Data = ""
                    });
                }                
            }
            var errorList = ModelState.Select(s => s.Value.Errors)
                            .Where(s => s.Any())
                            .ToList();
            var errors = string.Empty;
            foreach (var error in errorList)
            {
                errors += error.ToString() + ",";
            }
            return Json(new ApiResponse<string>
            {
                IsSuccess = false,
                Message = errors,
                Data = ""
            });
        }

        public IActionResult Index()
        {
            List<StudentIndexViewModel> model = new();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string text)
        {
            List<StudentIndexViewModel> model = new();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                //select * from StudentTable where Name like '  ';Delete from StudentTable --%'
                string cmd = "select * from StudentTable where Name Like @text";
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = cmd;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@text", text+"%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int.TryParse(reader["Gender"].ToString(), out int gender);
                                model.Add(new StudentIndexViewModel
                                {
                                    //Id = reader.GetInt32(0),
                                    //Id = Convert.ToInt32(reader[0]),
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    Age = Convert.ToInt32(reader["Age"]),
                                    Gender = gender
                                });
                            }
                        }
                    }
                }
                connection.Close();
            }

            //SqlConnection connection = new SqlConnection(connectionString);
            //try
            //{
            //    connection.Open();
            //    //
            //}
            //catch (Exception)
            //{


            //}
            //finally
            //{//Finally block executes always
            //    connection.Close();
            //}

            return View(model);
        }
    }
}
