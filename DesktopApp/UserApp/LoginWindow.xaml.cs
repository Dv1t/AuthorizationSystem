using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly string _connectionString;
        public LoginWindow()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void ClearLoginField(object o, MouseButtonEventArgs e)
        {
            TextBox sender = (TextBox)o;
            FieldsBehaviour.ClearLoginField(sender);
        }

        private void ClearPasswordField(object o, MouseButtonEventArgs e)
        {
            PasswordBox sender = (PasswordBox)o;
            FieldsBehaviour.ClearPasswordField(sender);
        }

        private void FillLoginField(object o, RoutedEventArgs routedEventArgs)
        {
            TextBox sender = (TextBox)o;
            FieldsBehaviour.FillLoginField(sender);
        }

        private void FillPasswordField(object o, RoutedEventArgs routedEventArgs)
        {
            PasswordBox sender = (PasswordBox)o;
            FieldsBehaviour.FillPasswordField(sender);
        }

        private void ClickLogin(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.ToString();
            string password = PasswordBox.Password.ToString();
            if ((login.Length==0)||(password.Length==0))
            {
                MessageBox.Show("Неправильно введён логин и/или пароль");
                return;
            }
            SqlConnection connection = null;
            try
            {
                string sql = $"SELECT * FROM Users WHERE LOGIN='{login}' AND Password='{password}'";
                connection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable userTable = new DataTable();
                connection.Open();
                adapter.Fill(userTable);
                if (userTable.Rows.Count == 1)
                {
                    BitmapImage icon = new BitmapImage();
                    icon.BeginInit();
                    icon.CacheOption = BitmapCacheOption.OnLoad;
                    icon.StreamSource = new MemoryStream((byte[])userTable.Rows[0]["Icon"]);
                    icon.EndInit();
                    User user = new User (password, login,int.Parse(userTable.Rows[0]["Role"].ToString()), int.Parse(userTable.Rows[0]["id"].ToString()), icon);
                    LoggedInWindow authorizedWindow = new LoggedInWindow(user);
                    authorizedWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection?.Close();
            }
        }

        private void ClickRegister(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow { Owner = this };
            registerWindow.Show();
        }
    }
}
