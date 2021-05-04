using System;
using System.Collections.Generic;
using System.Text;

namespace Les2
{
    public enum Geslacht
    {
        Mannelijk,
        Vrouwelijk
    }

    public class Student
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public Geslacht Sex { get; set; }

        public Student(string firstname, string lastname, int age, Geslacht sex)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            Sex = sex;
        }
    }
}
