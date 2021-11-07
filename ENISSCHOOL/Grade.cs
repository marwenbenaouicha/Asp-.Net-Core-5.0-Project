using System.Collections.Generic;

namespace ENISSCHOOL
{
    public class Grade
    {
        public int Id { get; set; }
        public int ClassNumber { get; set; }
        public string Speciality { get; set; }
        public IList<Student> Students  { get; set; }
       
    }
}