using System;

namespace DataLayer.Models
{
    public class Student
    {
        private int JustifiedAbscence, UnjustifiedAbscence;
        private String FirstName, LastName, Class, Id;
        private DateTime DateOfBirth;

        public String GetSetId
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

        public int GetSetJustifiedAbscence
        {
            get
            {
                return JustifiedAbscence;
            }
            set
            {
                JustifiedAbscence = value;
            }
        }

        public int GetSetUnjustifiedAbscence
        {
            get
            {
                return UnjustifiedAbscence;
            }
            set
            {
                UnjustifiedAbscence = value;
            }
        }

        public String GetSetFirstName
        {
            get
            {
                return FirstName;
            }
            set
            {
                FirstName = value;
            }
        }

        public String GetSetLastName
        {
            get
            {
                return LastName;
            }
            set
            {
                LastName = value;
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
    }
}