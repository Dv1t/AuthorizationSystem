using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly string _connectionString;
        public RegisterWindow()
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

        private void ClickRegister(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.ToString();
            string password = PasswordBox.Password.ToString();
            string confirmPassword = PasswordConfirmBox.Password.ToString();
            if (password != confirmPassword)
            {
                MessageBox.Show("Введнные пароли должны совпадать");
                return;
            }
            string sql = $"INSERT INTO Users (Login,Password,Role) VALUES('{login}','{password}',1)";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.BeginExecuteNonQuery();
                MessageBox.Show("Новый пользователь  зарегестрирован");
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
    }
}
