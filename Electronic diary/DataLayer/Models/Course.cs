using System;

namespace DataLayer.Models
{
    public class Course
    {
        private int Id;
        private String Name, Description;

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

        public String GetSetName
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        public String GetSetDescription
        {
            get
            {
                return Description;
            }
            set
            {
                Description = value;
            }
        }
    }
}