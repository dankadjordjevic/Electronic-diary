using DataLayer.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
    public class RatingRepository : IRatingRepository
    {
        public List<Rating> GetAllRatings()
        {
            List<Rating> listToReturn = new List<Rating>();
            using (SqlConnection dataConnection = new SqlConnection(GlobalVariables.connString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT r.Id,r.DateOfRating, r.Mark, r.NameOfTeacher, s.FirstName, s.LastName, c.Name FROM Ratings r JOIN Courses c ON r.CourseId = c.Id JOIN Students s ON r.StudentId = s.Id;";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Rating r = new Rating();

                    r.GetSetId = dataReader.GetInt32(0);
                    r.GetSetDateOfRate = dataReader.GetDateTime(1);
                    r.GetSetMark = dataReader.GetInt32(2);
                    r.GetSetNameOfTeacher = dataReader.GetString(3);
                    r.GetSetFirstStudentName = dataReader.GetString(4);
                    r.GetSetLastStudentName = dataReader.GetString(5);
                    r.GetSetCourseName = dataReader.GetString(6);
                    listToReturn.Add(r);
                }
            }
            return listToReturn;
        }

        public void InsertRating(Rating r)
        {
            using (SqlConnection dataConnection = new SqlConnection(GlobalVariables.connString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Ratings VALUES (@dateOfRating, @mark, @nameOfTeacher, @studentId, @courseId)";
                command.Parameters.AddWithValue("@dateOfRating", r.GetSetDateOfRate);
                command.Parameters.AddWithValue("@mark", r.GetSetMark);
                command.Parameters.AddWithValue("@nameOfTeacher", r.GetSetNameOfTeacher);
                command.Parameters.AddWithValue("@studentId", r.GetSetStudentId);
                command.Parameters.AddWithValue("@courseId", r.GetSetCourseId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteRating(Rating r)
        {
            using (SqlConnection dataConnection = new SqlConnection(GlobalVariables.connString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "DELETE FROM Ratings WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", r.GetSetId);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateRating(Rating r)
        {
            using (SqlConnection dataConnection = new SqlConnection(GlobalVariables.connString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Ratings SET DateOfRating = @dateOfRating, Mark = @mark, NameOfTeacher = @nameOfTeacher,StudentId = @studentId, CourseId = @courseId WHERE Id = @personalId";
                command.Parameters.AddWithValue("@personalId", r.GetSetId);
                command.Parameters.AddWithValue("@dateOfRating", r.GetSetDateOfRate);
                command.Parameters.AddWithValue("@mark", r.GetSetMark);
                command.Parameters.AddWithValue("@nameOfTeacher", r.GetSetNameOfTeacher);
                command.Parameters.AddWithValue("@studentId", r.GetSetStudentId);
                command.Parameters.AddWithValue("@courseId", r.GetSetCourseId);
                command.ExecuteNonQuery();
            }
        }

        public List<Rating> GetAllRatingsAVG(string personalId)
        {
            List<Rating> listToReturn = new List<Rating>();
            using (SqlConnection dataConnection = new SqlConnection(GlobalVariables.connString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT s.FirstName, s.LastName, s.DateOfBirth, s.Class, s.JustifiedAbscence, s.UnjustifiedAbscence, AVG(Cast(Mark as Float)) AS GDP FROM Ratings r JOIN Courses c ON r.CourseId = c.Id JOIN Students s ON r.StudentId = s.Id WHERE s.Id = @personalId GROUP BY  s.FirstName, s.LastName, s.DateOfBirth, s.Class, s.JustifiedAbscence, s.UnjustifiedAbscence";
                command.Parameters.AddWithValue("@personalId", personalId);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Rating r = new Rating();

                    r.GetSetFirstStudentName = dataReader.GetString(0);
                    r.GetSetLastStudentName = dataReader.GetString(1);
                    r.GetSetDateOfBirth = dataReader.GetDateTime(2);
                    r.GetSetClass = dataReader.GetString(3);
                    r.GetSetJustified = dataReader.GetInt32(4);
                    r.GetSetUnjustified = dataReader.GetInt32(5);
                    r.GetSetAvg = dataReader.GetDouble(6);
                    listToReturn.Add(r);
                }
            }
            return listToReturn;
        }
    }
}