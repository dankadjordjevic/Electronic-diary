using DataLayer.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
    public class CourseRepository : ICourseRepository
    {
        public List<Course> GetAllCourses()
        {
            List<Course> listToReturn = new List<Course>();
            using (SqlConnection dataConnection = new SqlConnection(GlobalVariables.connString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM Courses";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Course c = new Course();

                    c.GetSetId = dataReader.GetInt32(0);
                    c.GetSetName = dataReader.GetString(1);
                    c.GetSetDescription = dataReader.GetString(2);
                    listToReturn.Add(c);
                }
            }
            return listToReturn;
        }

        public void InsertCourse(Course c)
        {
            using (SqlConnection dataConnection = new SqlConnection(GlobalVariables.connString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Courses VALUES (@name, @description)";
                command.Parameters.AddWithValue("@name", c.GetSetName);
                command.Parameters.AddWithValue("@description", c.GetSetDescription);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCourse(Course c)
        {
            using (SqlConnection dataConnection = new SqlConnection(GlobalVariables.connString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "DELETE FROM Courses WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", c.GetSetId);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCourse(Course c)
        {
            using (SqlConnection dataConnection = new SqlConnection(GlobalVariables.connString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Courses SET Name = @name, Description = @description WHERE Id = @personalId";
                command.Parameters.AddWithValue("@personalId", c.GetSetId);
                command.Parameters.AddWithValue("@name", c.GetSetName);
                command.Parameters.AddWithValue("@description", c.GetSetDescription);
                command.ExecuteNonQuery();
            }
        }
    }
}