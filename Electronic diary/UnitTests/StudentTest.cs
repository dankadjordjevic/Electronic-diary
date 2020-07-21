using DataLayer;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void CheckDeleteStudent()
        {
            // Arrange
            int lengthOfStudents;
            int newLengthOfStudents;
            Student s = new Student();
            IStudentRepository isr = new StudentRepository();
            s.GetSetId = "1256778412789";
            s.GetSetFirstName = "Test";
            s.GetSetLastName = "Test";
            s.GetSetDateOfBirth = DateTime.Now;
            s.GetSetClass = "I razred";
            s.GetSetJustifiedAbscence = 1;
            s.GetSetUnjustifiedAbscence = 2;
            // Act
            isr.InsertStudent(s);
            lengthOfStudents = isr.GetAllStudents().Count;
            isr.DeleteStudent(s);
            newLengthOfStudents = isr.GetAllStudents().Count;
            // Assert
            Assert.AreEqual(lengthOfStudents, newLengthOfStudents + 1);
        }

        // Delete row in Students table with id specified below (1223556789458) after every run test
        [TestMethod]
        public void CheckUpdateStudent()
        {
            // Arrange
            Student s = new Student();
            IStudentRepository isr = new StudentRepository();
            s.GetSetId = "1223556789458";
            s.GetSetFirstName = "Test";
            s.GetSetLastName = "Test";
            s.GetSetDateOfBirth = DateTime.Now;
            s.GetSetClass = "I razred";
            s.GetSetJustifiedAbscence = 1;
            s.GetSetUnjustifiedAbscence = 2;
            // Act
            isr.InsertStudent(s);
            s.GetSetFirstName = "Test Promenjen";
            isr.UpdateStudent(s);
            // Assert
            Assert.AreEqual(s.GetSetFirstName, "Test Promenjen");
        }
    }
}