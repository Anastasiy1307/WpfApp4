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
    /// Логика взаимодействия для update.xaml
    /// </summary>
    public partial class update : Page
    {
        public Frame frame1;
        object jj;
        List<Auto> autos = new List<Auto> { new Auto() };
        public update(Frame frame, object jjj)
        {
            InitializeComponent();
            frame1 = frame;
            jj = jjj;
            autos[0] = (Auto)jj;
            Namee.Text= autos[0].Name;
            Powerr.Text = autos[0].Power;
                        
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            List<Auto> autos1 = new List<Auto>();
            autos1= Entities.GetContext().Auto.ToList();

            for (int i = 0; i < autos1.Count; i++)
            {
                if (autos[0].ID == autos1[i].ID)
                {
                    autos1[i].Name = Namee.Text;
                    autos1[i].Power = Powerr.Text;
                    Entities.GetContext().SaveChanges();
                    frame1.Navigate(new Glavn(frame1));
                    break;
                }
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            List<Auto> autos2 = new List<Auto>();
            autos2 = Entities.GetContext().Auto.ToList();
            for (int i = 0; i < autos2.Count; i++)
            {
                if (autos[0].ID == autos2[i].ID)
                {
                    Entities.GetContext().Auto.Remove(autos[i]);
                    Entities.GetContext().SaveChanges();
                    frame1.Navigate(new Glavn(frame1));
                    break;
                }
            }
        }
    }
}
