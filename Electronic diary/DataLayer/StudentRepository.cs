using DataLayer.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> GetAllStudents()
        {
            List<Student> listToReturn = new List<Student>();
            using (SqlConnection dataConnection = new SqlConnection(GlobalVariables.connString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM Students";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Student s = new Student();

                    s.GetSetId = dataReader.GetString(0);
                    s.GetSetFirstName = dataReader.GetString(1);
                    s.GetSetLastName = dataReader.GetString(2);
                    s.GetSetDateOfBirth = dataReader.GetDateTime(3);
                    s.GetSetClass = dataReader.GetString(4);
                    s.GetSetJustifiedAbscence = dataReader.GetInt32(5);
                    s.GetSetUnjustifiedAbscence = dataReader.GetInt32(6);
                    listToReturn.Add(s);
                }
            }
            return listToReturn;
        }

        public void InsertStudent(Student s)
        {
            using (SqlConnection dataConnection = new SqlConnection(GlobalVariables.connString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Students VALUES (@personalId, @firstName, @lastName, @date, @class, @justified, @unjustified)";
                command.Parameters.AddWithValue("@personalId", s.GetSetId);
                command.Parameters.AddWithValue("@firstName", s.GetSetFirstName);
                command.Parameters.AddWithValue("@lastName", s.GetSetLastName);
                command.Parameters.AddWithValue("@date", s.GetSetDateOfBirth);
                command.Parameters.AddWithValue("@class", s.GetSetClass);
                command.Parameters.AddWithValue("@justified", s.GetSetJustifiedAbscence);
                command.Parameters.AddWithValue("@unjustified", s.GetSetUnjustifiedAbscence);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(Student s)
        {
            using (SqlConnection dataConnection = new SqlConnection(GlobalVariables.connString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "DELETE FROM Students WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", s.GetSetId);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student s)
        {
            using (SqlConnection dataConnection = new SqlConnection(GlobalVariables.connString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Students SET FirstName = @firstName, LastName = @lastName, DateOfBirth = @date, Class = @class, JustifiedAbscence = @justified, UnjustifiedAbscence = @unjustified WHERE Id = @personalId";
                command.Parameters.AddWithValue("@personalId", s.GetSetId);
                command.Parameters.AddWithValue("@firstName", s.GetSetFirstName);
                command.Parameters.AddWithValue("@lastName", s.GetSetLastName);
                command.Parameters.AddWithValue("@date", s.GetSetDateOfBirth);
                command.Parameters.AddWithValue("@class", s.GetSetClass);
                command.Parameters.AddWithValue("@justified", s.GetSetJustifiedAbscence);
                command.Parameters.AddWithValue("@unjustified", s.GetSetUnjustifiedAbscence);
                command.ExecuteNonQuery();
            }
        }
    }
}