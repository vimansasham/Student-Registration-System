using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EG4214.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace EG4214
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;
        [ObservableProperty]
        public Student selectedStudent = null;



        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }




        [RelayCommand]
        public void message()
        {

            MessageBox.Show($"{selectedStudent.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new UserInterfaceVM();
            vm.title = "ADD STUDENT";
            UserInterface window = new UserInterface(vm);
            window.ShowDialog();

            if (vm.Member.FirstName != null)
            {
                students.Add(vm.Member);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedStudent != null)
            {
                string name = selectedStudent.FirstName;
                students.Remove(selectedStudent);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");

            }
            else
            {
                MessageBox.Show("Please Select the Student before you Delete.", "Error");


            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedStudent != null)
            {
                var vm = new UserInterfaceVM(selectedStudent);
                vm.title = "EDIT STUDENT";
                var window = new UserInterface(vm);

                window.ShowDialog();


                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
                students.Insert(index, vm.Member);



            }
            else
            {
                MessageBox.Show("You have not selected a student. Please Select the Student", "Warning!");
            }
        }

        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            students.Add(new Student(12, "Vimansa", "Shamali", "19/04/1999", image1, 3.234));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            students.Add(new Student(12, "Lathini", "Nawoda", "12/11/1999", image2, 3.056));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            students.Add(new Student(12, "Sadishka", "Ravindi", "15/05/1999", image3, 2.845));
            BitmapImage image4 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            students.Add(new Student(12, "Lasindu", "Ravishan", "16/11/2000", image4, 2.095));
            BitmapImage image5 = new BitmapImage(new Uri("/Model/Images/5.png", UriKind.Relative));
            students.Add(new Student(12, "Nishadi", "Shanika", "18/02/2000", image5, 3.905));
            BitmapImage image6 = new BitmapImage(new Uri("/Model/Images/6.png", UriKind.Relative));
            students.Add(new Student(12, "Nimesha", "Sewwandi", "22/09/2000", image6, 2.097));
            BitmapImage image7 = new BitmapImage(new Uri("/Model/Images/7.png", UriKind.Relative));
            students.Add(new Student(12, "Imasha", "Udeshi", "09/11/1999", image7, 3.778));
            BitmapImage image8 = new BitmapImage(new Uri("/Model/Images/7.png", UriKind.Relative));
            students.Add(new Student(12, "Devni", "Chanchala", "10/08/1999", image8, 2.778));


        }
    }
}
