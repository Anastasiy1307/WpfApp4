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
    /// Логика взаимодействия для Avt.xaml
    /// </summary>
    public partial class Avt : Page
    {
        public Frame frame1; 
        List<User_p> user_s = new List<User_p>();
        public Avt(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
            user_s = Entities.GetContext().User_p.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < user_s.Count; i++)
            {
                if (login.Text == user_s[i].user_)
                {
                    if (pass.Text == user_s[i].password)
                    {
                        frame1.Navigate(new Glavn(frame1));
                    }
                    else
                    {
                        MessageBox.Show("Пароль не правильный", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else 
                {
                    MessageBox.Show("Логин не правильный", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
