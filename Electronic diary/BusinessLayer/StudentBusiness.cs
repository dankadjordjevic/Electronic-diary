using DataLayer;
using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class StudentBusiness
    {
        private IStudentRepository studentRepository;

        public StudentBusiness(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public List<Student> GetAllStudents()
        {
            return this.studentRepository.GetAllStudents();
        }

        public void InsertStudent(Student s)
        {
            this.studentRepository.InsertStudent(s);
        }

        public void DeleteStudent(Student s)
        {
            this.studentRepository.DeleteStudent(s);
        }

        public void UpdateStudent(Student s)
        {
            this.studentRepository.UpdateStudent(s);
        }

        public List<Student> GetAllStudentById(string id)
        {
            return this.studentRepository.GetAllStudents().Where(c => c.GetSetId == id).ToList();
        }
    }
}