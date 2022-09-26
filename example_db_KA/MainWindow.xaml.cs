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

        private void GetRool_Click(object sender, RoutedEventArgs e)
        {
            users user = db.users.First();
           
            userRools rool = db.userRools.Where((element) => element.id == user.rools_id).First();
            UserRool.Content = $"{user.userName} {rool.title}";

        }

        private void GetTypes_Click(object sender, RoutedEventArgs e)
        {
            users first = db.users.First();
            List<userTipes> x = db.userTipes.ToList();


            for (int i = 0; i<x.Count; i++)
            {
                if (first.tipe_id == x[i].id)
                {
                    Types.Content = $"{first.userName} {x[i].title}";
                }
            }
            
        }

        private void GetUsersByType_Click(object sender, RoutedEventArgs e)
        {
            userTipes type = db.userTipes.First();
            List<users> a = db.users.ToList();
            for (int i = 0; i<a.Count;i++ )
            {
                if (a[i].tipe_id == type.id)
                {
                    Console.WriteLine($"Type:{type.title} users:{a[i].userName}");

                }
            }
        }
    }
}
