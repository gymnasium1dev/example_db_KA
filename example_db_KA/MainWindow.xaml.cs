using System;
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

namespace example_db_KA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        exampleEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new exampleEntities();
        }

        private void GetTipes_Click(object sender, RoutedEventArgs e)
        {
            List <userTipes> tipeslist = db.userTipes.ToList();
            Console.WriteLine(tipeslist.Count);
            
        }

        private void PrintTypes_Click(object sender, RoutedEventArgs e)
        {
            var allTypes = db.userTipes;
            foreach(var element in allTypes)
            {
                Console.WriteLine(element.title);
                Console.WriteLine($"id: {element.id} Type:{element.title}");
            }
        }

        private void addType_Click(object sender, RoutedEventArgs e)
        {
            string title = TypeTitle.Text;
            userTipes userType = new userTipes();
            userType.title = title;
            db.userTipes.Add(userType);
            db.SaveChanges();
        }

        private void rools_Click(object sender, RoutedEventArgs e)
        {
            userRools userRool = new userRools();
            userRool.title = "fhgh";

            db.userRools.Add(userRool);
            db.SaveChanges();
        }

        private void allRools_Click(object sender, RoutedEventArgs e)
        {
            var allRools = db.userRools;
            foreach(var element1 in allRools)
            {
                Console.WriteLine(element1.title);
            }
        }

        private void addnewUser_Click(object sender, RoutedEventArgs e)
        {
            users user = new users();

            user.userName = userName.Text;
            user.tipe_id = 1;
            user.rools_id = 1;
            user.userRools = db.userRools.ToList()[0];
            db.users.Add(user);
            db.SaveChanges();
        }

        private void printUsers_Click(object sender, RoutedEventArgs e)
        {
            List<users> users = db.users.ToList();
            foreach(var element in users)
            {
                Console.WriteLine($"username: {element.userName} usertype: {element.tipe_id}");
            }
        }
    }
}
