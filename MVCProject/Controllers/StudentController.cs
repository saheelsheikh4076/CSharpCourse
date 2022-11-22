using Microsoft.AspNetCore.Mvc;
using MVCProject.ViewModels;
using System.Data.SqlClient;

namespace MVCProject.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            List<StudentIndexViewModel> model = new ();
            string connectionString = "Data Source=(local);Initial Catalog=TestDb1;Integrated Security=True";
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                using (SqlCommand command = new SqlCommand("select * from StudentTable", connection))
                {
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
