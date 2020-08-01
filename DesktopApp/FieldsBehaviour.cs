using System.Windows.Controls;

namespace UserApp
{
    static class FieldsBehaviour
    {
        public static void ClearLoginField(TextBox sender)
        {
            if (sender.Text == "Login")
                sender.Text = "";
        }

        public static void ClearPasswordField(PasswordBox sender)
        {
            if (sender.Password == "******")
                sender.Password = "";
        }

        public static void FillLoginField(TextBox sender)
        {
            if (sender.Text == "")
                sender.Text = "Login";
        }

        public static void FillPasswordField(PasswordBox sender)
        {
            if (sender.Password == "")
                sender.Password = "******";
        }
    }
}
