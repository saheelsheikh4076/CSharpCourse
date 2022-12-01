using ViewModels;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

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

        public void DeleteStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var query = "Delete from StudentTable where Id = @id";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   command.Parameters.AddWithValue("@id", id);
                   var rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void UpdateStudent(StudentViewModel student)//Make sure that student parameter has id
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var query = "Update StudentTable Set Age = @age, Gender = @gender, Name = @name where id = @id";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", student.Id);
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
                            StudentViewModel student = new StudentViewModel();//This line is taken out to prevent high memory usage
                            //to avoid multiple instantiations.
                            //in this case we have to assign all the properties compulsorily
                            while (reader.Read())
                            {
                                var isGender = int.TryParse(reader["Gender"].ToString(), out int gender);
                                var isAge = int.TryParse(reader["Age"].ToString(), out int age);
                               
                                student.Id = Convert.ToInt32(reader["Id"]);
                                student.Name = reader["Name"].ToString();
                                //if (isGender) student.Gender = gender; if next row has null then it will keep old value for next row
                                student.Gender = isGender ? gender : null;
                                student.Age = isAge ? age : null;
                                model.Add(student);
                            }
                        }
                    }
                }
                connection.Close();
            }
            return model;
        }

        public StudentViewModel GetStudentById(int id)
        {
            StudentViewModel model = new StudentViewModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "select top(1) * from StudentTable where Id = @id";
                using (SqlCommand cmd = new SqlCommand(query,connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            var isGender = int.TryParse(reader["Gender"].ToString(), out int gender);
                            var isAge = int.TryParse(reader["Age"].ToString(), out int age);
                            reader.Read();
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
