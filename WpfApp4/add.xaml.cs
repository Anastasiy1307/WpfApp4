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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для add.xaml
    /// </summary>
    public partial class add : Page
    {
       public Frame frame1;
        List<Auto> autos = new List<Auto> { new Auto() };

        public add(Frame frame)
        {
            InitializeComponent();
            frame1= frame;
            autos = Entities.GetContext().Auto.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }
        public void Add() 
        {
            autos[0].Name = Namee.Text;
            autos[0].Power = Powerr.Text;
            Entities.GetContext().Auto.Add(autos[0]);
            Entities.GetContext().SaveChanges();
            frame1.Navigate(new Glavn(frame1));
        }
    }
}
