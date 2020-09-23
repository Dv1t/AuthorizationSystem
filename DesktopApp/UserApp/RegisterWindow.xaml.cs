using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private string _imgSource;
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
            if((login.Length==0)||(password.Length==0)||(login=="Login") || (password == "******"))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Введнные пароли должны совпадать");
                return;
            }
            //string sql = $"INSERT INTO Users (Login,Password,Role,Icon) VALUES('{login}','{password}',1,{_imgPicture})";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO Users VALUES (@Login,@Password,@Role,@Icon)";
                command.Parameters.Add("@Login", SqlDbType.NChar, 15);
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@Role", SqlDbType.Int);
                command.Parameters.Add("@Icon", SqlDbType.Image, 1000000);

                byte[] imageData;
                try
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(_imgSource, FileMode.Open))
                    {
                        imageData = new byte[fs.Length];
                        fs.Read(imageData, 0, imageData.Length);
               

                command.Parameters["@Login"].Value =login;
                command.Parameters["@Password"].Value = password;
                command.Parameters["@Role"].Value = 1;
                command.Parameters["@Icon"].Value = imageData;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Выберите изображение для иконки пользователя");
                    return;
                }
                command.ExecuteNonQuery();
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

        private void ClickChooseIcon(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter =
                "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            ofdPicture.FilterIndex = 1;

            if (ofdPicture.ShowDialog() == true)
                _imgSource = ofdPicture.FileName;
        }
    }
}
