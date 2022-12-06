using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
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
                return RedirectToAction("Students");
            }
            //ModelState.AddModelError("", "Its my error");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStudent(string StudentId)
        {
            await student.DeleteStudent(StudentId);
            return RedirectToAction("Students");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStudent(string StudentId)
        {
            var model = await student.GetStudentById(StudentId);
            return View(model);
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
