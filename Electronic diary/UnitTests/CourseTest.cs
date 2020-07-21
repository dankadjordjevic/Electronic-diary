using DataLayer;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CheckCoursesLength()
        {
            // Arrange
            List<Course> courseList = new List<Course>();
            ICourseRepository icr = new CourseRepository();
            // Act
            courseList = icr.GetAllCourses();
            // Assert
            Assert.AreNotEqual(null, courseList.Count);
        }

        [TestMethod]
        public void CheckInsertCourse()
        {
            // Arrange
            Course c = new Course();
            List<Course> courseList = new List<Course>();
            ICourseRepository icr = new CourseRepository();
            int elemListBefore, elemListAfter;
            c.GetSetName = "TestPredmet";
            c.GetSetDescription = "Test Opis";
            // Act
            courseList = icr.GetAllCourses();
            elemListBefore = courseList.Count;
            icr.InsertCourse(c);
            courseList = icr.GetAllCourses();
            elemListAfter = courseList.Count;
            // Assert
            Assert.AreEqual(elemListBefore, elemListAfter - 1);
        }
    }
}