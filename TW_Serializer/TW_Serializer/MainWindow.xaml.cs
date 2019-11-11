using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TW_Serializer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int maximumPersonNumber = 100;
            Person person = new Person(Name.Text, Address.Text, Phone.Text);

            if (Person.SerialNumber < maximumPersonNumber)
            {
                string fileName = @"\person" + Person.SerialNumber + ".dat";
                string directoryPath = @"C:\Users\matra\OneDrive\Asztali gép\codecool\TW_assignments\3rd_week\TW_Serializer";
                string filePath = directoryPath + fileName;
                person.Serialize(filePath);
            }
            else
            {
                MessageBox.Show("You already have 99 people, calm down!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string directoryPath = @"C:\Users\matra\OneDrive\Asztali gép\codecool\TW_assignments\3rd_week\TW_Serializer";
            string fileName = @"\person1.dat";
            string filePath = directoryPath + fileName;
            if (File.Exists(filePath))
            {
                Person person = Person.Deserialize(filePath);
                Name.Text = person.Name;
                Address.Text = person.Address;
                Phone.Text = person.PhoneNumber;
            }
        }
    }
}
