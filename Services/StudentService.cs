using ViewModels;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace Services
{
    public class StudentService : IStudent
    {
        private readonly string connectionString = string.Empty;

        public StudentService(IConfiguration config)
        {
            this.connectionString = config.GetConnectionString("DefaultConnection");
        }
        public void AddStudent(StudentViewModel student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public List<StudentViewModel> GetAllStudents()
        {
            List<StudentViewModel> model = new List<StudentViewModel>();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //select * from StudentTable where Name like '  ';Delete from StudentTable --%'
                string cmd = "select * from StudentTable where Name Like @text";
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = cmd;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@text", text + "%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int.TryParse(reader["Gender"].ToString(), out int gender);
                                model.Add(new StudentViewModel
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

                    connection.Close();
            }
                return model;
        }

        public StudentViewModel GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(StudentViewModel student)
        {
            throw new NotImplementedException();
        }
    }
}
