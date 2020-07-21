using System;

namespace DataLayer.Models
{
    public class Rating
    {
        private int Id, Mark, CourseId, Justified, Unjustified;
        private double avg;
        private DateTime DateOfRate, DateOfBirth;
        private String NameOfTeacher, StudentFirstName, StudentLastName, CourseName, StudentId, Class;

        public int GetSetId
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }

        public int GetSetMark
        {
            get
            {
                return Mark;
            }
            set
            {
                Mark = value;
            }
        }

        public int GetSetJustified
        {
            get
            {
                return Justified;
            }
            set
            {
                Justified = value;
            }
        }

        public int GetSetUnjustified
        {
            get
            {
                return Unjustified;
            }
            set
            {
                Unjustified = value;
            }
        }

        public String GetSetStudentId
        {
            get
            {
                return StudentId;
            }
            set
            {
                StudentId = value;
            }
        }

        public String GetSetClass
        {
            get
            {
                return Class;
            }
            set
            {
                Class = value;
            }
        }

        public int GetSetCourseId
        {
            get
            {
                return CourseId;
            }
            set
            {
                CourseId = value;
            }
        }

        public DateTime GetSetDateOfRate
        {
            get
            {
                return DateOfRate;
            }
            set
            {
                DateOfRate = value;
            }
        }

        public DateTime GetSetDateOfBirth
        {
            get
            {
                return DateOfBirth;
            }
            set
            {
                DateOfBirth = value;
            }
        }

        public String GetSetNameOfTeacher
        {
            get
            {
                return NameOfTeacher;
            }
            set
            {
                NameOfTeacher = value;
            }
        }

        public String GetSetFirstStudentName
        {
            get
            {
                return StudentFirstName;
            }
            set
            {
                StudentFirstName = value;
            }
        }

        public String GetSetLastStudentName
        {
            get
            {
                return StudentLastName;
            }
            set
            {
                StudentLastName = value;
            }
        }

        public String GetSetCourseName
        {
            get
            {
                return CourseName;
            }
            set
            {
                CourseName = value;
            }
        }

        public double GetSetAvg
        {
            get
            {
                return avg;
            }
            set
            {
                avg = value;
            }
        }
    }
}