using ViewModels;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.DataProtection;

namespace Services
{
    public class StudentService
    {
        private readonly string connectionString = string.Empty;
        private readonly IDataProtector protector;
        public StudentService(IConfiguration config,IDataProtectionProvider dataProtectionProvider)
        {
            this.protector = dataProtectionProvider.CreateProtector("Irfan");
            this.connectionString = config.GetConnectionString("DefaultConnection");
        }
        public void AddStudent(StudentViewModel student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var query = "Insert into StudentTable (Name,Age,Gender) values (@name,@age,@gender)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@age", student.Age);
                    command.Parameters.AddWithValue("@gender", student.Gender);
                    var rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void DeleteStudent(string id)
        {
            var _id = Convert.ToInt32(protector.Unprotect(id));
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var query = "Delete from StudentTable where Id = @id";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   command.Parameters.AddWithValue("@id", _id);
                   var rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void UpdateStudent(StudentViewModel student)//Make sure that student parameter has id
        {
            int _id = Convert.ToInt32(protector.Unprotect(student.ProtectedId));
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var query = "Update StudentTable Set Age = @age, Gender = @gender, Name = @name where id = @id";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", _id);
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@age", student.Age);
                    command.Parameters.AddWithValue("@gender", student.Gender);
                    var rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public List<StudentViewModel> GetAllStudents()
        {
            List<StudentViewModel> model = new List<StudentViewModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmd = "select * from StudentTable";
                using (SqlCommand command = new SqlCommand(cmd,connection))
                {
                    //command.Parameters.AddWithValue("@text", text + "%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var isGender = byte.TryParse(reader["Gender"].ToString(), out byte gender);
                                var isAge = int.TryParse(reader["Age"].ToString(), out int age);
                                                           
                                model.Add(new StudentViewModel
                                {
                                    ProtectedId = protector.Protect(reader["Id"].ToString()),
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    Gender = isGender ? gender : null,
                                    Age = isAge ? age : null
                                });
                            }
                        }
                    }
                }
                connection.Close();
            }
            return model;
        }

        public StudentViewModel GetStudentById(string id)
        {
            int _id = Convert.ToInt32(protector.Unprotect(id));
            StudentViewModel model = new StudentViewModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "select top(1) * from StudentTable where Id = @id";
                using (SqlCommand cmd = new SqlCommand(query,connection))
                {
                    cmd.Parameters.AddWithValue("@id", _id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var isGender = byte.TryParse(reader["Gender"].ToString(), out byte gender);
                            var isAge = int.TryParse(reader["Age"].ToString(), out int age);
                            model.ProtectedId = protector.Protect(reader["Id"].ToString());
                            model.Id = Convert.ToInt32(reader["Id"]);
                            model.Name = reader["Name"].ToString();
                            model.Gender = isGender ? gender : null;
                            model.Age = isAge ? age : null;
                        }
                    }
                }
                connection.Close();
            }
            return model;
        }

       
    }
}
