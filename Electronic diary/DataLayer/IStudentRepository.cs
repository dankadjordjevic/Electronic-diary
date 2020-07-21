using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();

        void InsertStudent(Student s);

        void DeleteStudent(Student s);

        void UpdateStudent(Student s);
    }
}