﻿using System;
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
    }
}
