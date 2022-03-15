using AA.Domain.Results;
using AA.Domain.Users;
using AA.Services.Users;
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

namespace AA.UI.Views.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        private readonly UsersService _usersService;

        public AuthorizationPage()
        {
            InitializeComponent();
            _usersService = new();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            UserBlank blank = new();
            blank.Email = EmailBox.Text;
            blank.Password = PasswordBox.Password;

            Result result = _usersService.LogIn(blank);
            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error!);
                return;
            }

            App.SetUser(result.Data is User user ? user : throw new Exception("Точка недостижимости"));
        }
    }
}
