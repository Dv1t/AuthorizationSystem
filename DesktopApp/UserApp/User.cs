using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;

namespace UserApp
{
    public class User
    {
        public readonly string Login;
        private readonly string Password;
        public readonly int Role;
        public readonly int Id;
        public readonly BitmapImage Icon;

        public User(string password,string login,int role,int id,BitmapImage icon)
        {
            Login = login;
            Password = password;
            Role = role;
            Id = id;
            Icon = icon;
        }
        public string GetPassword()
        {
            return Password;
        }


    }
}
