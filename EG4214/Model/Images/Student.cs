using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace EG4214.Model
{
    public class Student
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public BitmapImage Image { get; set; }

        public string DateOfBirth { get; set; }
        public Double GPA { get; set; }

        public String ImagePath
        {
            get { return $"/Model/Images/{Image}"; }
        }

        public Student(int age, string fName, string lName, string dateOfBirth, BitmapImage image, Double gpa)
        {
            Age = age;
            FirstName = fName;
            LastName = lName;
            DateOfBirth = dateOfBirth;
            Image = image;
            GPA = gpa;
        }

        public Student()
        {
        }
    }
}
