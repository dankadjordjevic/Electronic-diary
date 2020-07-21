using DataLayer;
using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class CourseBusiness
    {
        private ICourseRepository courseRepository;

        public CourseBusiness(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public List<Course> GetAllCourses()
        {
            return this.courseRepository.GetAllCourses();
        }

        public void InsertCourse(Course c)
        {
            this.courseRepository.InsertCourse(c);
        }

        public void DeleteCourse(Course c)
        {
            this.courseRepository.DeleteCourse(c);
        }

        public void UpdateCourse(Course c)
        {
            this.courseRepository.UpdateCourse(c);
        }

        public List<Course> GetAllCoursesById(int id)
        {
            return this.courseRepository.GetAllCourses().Where(c => c.GetSetId == id).ToList();
        }
    }
}