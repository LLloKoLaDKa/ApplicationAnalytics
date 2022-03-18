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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private readonly UsersService _usersService;

        public RegistrationPage()
        {
            InitializeComponent();
            _usersService = new();
        }

        private void RegistryButton_Click(object sender, RoutedEventArgs e)
        {
            String email = EmailBox.Text;
            String password = PasswordBox.Text;
            String rePassword = RePasswordBox.Text;
            UserBlank blank = new(null, email, password, rePassword);

            Result result = _usersService.Registration(blank);
            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error!);
                return;
            }

            Result userResult = _usersService.LogIn(blank);
            App.SetUser(userResult.Data is User user ? user : throw new Exception("Точка недостижимости"));

            App.ShowMessage("Регистрация прошла успешно!");
            App.ChangeToMainPage();
        }
    }
}
