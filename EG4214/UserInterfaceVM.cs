using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EG4214.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace EG4214
{
    public partial class UserInterfaceVM : ObservableObject

    {


        [ObservableProperty]
        public string fname;


        [ObservableProperty]
        public string lname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public double gpa;



        



        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage image;



        public UserInterfaceVM(Student u)
        {
            Member = u;

            fname = Member.FirstName;
            lname = Member.LastName;
            age = Member.Age;
            gpa = Member.GPA;
            dateofbirth = Member.DateOfBirth;
            image = Member.Image;

        }
        public UserInterfaceVM()
        {

        }


       
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                image = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Image is successfuly uploded!", "successfull");
            }
        }






        public Student Member { get; private set; }
        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void Save()
        {



            if (gpa < 0 || gpa > 4)
            {
                MessageBox.Show("GPA value must be between 0 and 4.", "Error");
                return;
            }
            if (Member == null)
            {

                Member = new Student()
                {
                    FirstName = fname,
                    LastName = lname,
                    Age = age,
                    DateOfBirth = dateofbirth,
                    Image = image,

                    GPA = gpa

                };


            }
            else
            {

                Member.FirstName = fname;
                Member.LastName = lname;
                Member.Age = age;
                Member.GPA = gpa;
                Member.Image = image;
                Member.DateOfBirth = dateofbirth;



            }

            if (Member.FirstName != null)
            {

                CloseAction();
            }
            Application.Current.MainWindow.Show();


        }
    }
}
