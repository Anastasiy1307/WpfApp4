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
    /// Логика взаимодействия для Glavn.xaml
    /// </summary>
    public partial class Glavn : Page
    {
        public Frame frame1;
        List <Auto> auto = new List <Auto> ();

        public Glavn(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
            auto = Entities.GetContext().Auto.ToList ();
            Autos.ItemsSource = auto;
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        public void Update()
        {
            var poisk = Entities.GetContext().Auto.ToList();
            poisk = poisk.Where(p => p.Name.ToLower().Contains(Poisk.Text.ToLower())).ToList();
            Autos.ItemsSource = poisk;
        }

        private async void Autos_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay (100);
            object j = Autos.SelectedItem;
            frame1.Navigate(new update(frame1, j));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new add(frame1));
        }
    }
}
