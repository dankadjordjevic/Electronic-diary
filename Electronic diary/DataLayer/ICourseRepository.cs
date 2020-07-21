using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();

        void InsertCourse(Course c);

        void DeleteCourse(Course c);

        void UpdateCourse(Course c);
    }
}