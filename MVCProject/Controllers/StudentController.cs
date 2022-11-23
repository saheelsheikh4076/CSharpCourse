using Microsoft.AspNetCore.Mvc;
using MVCProject.ViewModels;
using System.Data.SqlClient;

namespace MVCProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration configuration;

        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            List<StudentIndexViewModel> model = new();

            return View(model);
        }
        [HttpPost]
        public IActionResult Index(string text)
        {
            List<StudentIndexViewModel> model = new();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //select * from StudentTable where Name like '  ';Delete from StudentTable --%'
                string cmd = "select * from StudentTable where Name = '@text'";
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    command.Parameters.AddWithValue("@text", text);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                model.Add(new StudentIndexViewModel
                                {
                                    //Id = reader.GetInt32(0),
                                    //Id = Convert.ToInt32(reader[0]),
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    Age = Convert.ToInt32(reader["Age"]),
                                    Gender = Convert.ToInt32(reader["Gender"])
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
