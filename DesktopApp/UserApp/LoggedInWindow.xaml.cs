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
using System.Windows.Shapes;
using Image = System.Drawing.Image;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для LoggedInWindow.xaml
    /// </summary>
    public partial class LoggedInWindow : Window
    {
        private string _login;
        private string _password;
        private string _role;
        public LoggedInWindow(User user)
        {
            InitializeComponent();
            _login = user.Login;
            _password = user.GetPassword();
            if (user.Role == 0)
            {
                _role = "Administrator";
            }

            if (user.Role == 1)
            {
                _role = "Manager";
            }

            LoginTextBlock.Text += _login;
            PasswordTextBlock.Text += _password;
            RoleTextBlock.Text += _role;
            UserIcon.Source= user.Icon;
        }
    }
}
