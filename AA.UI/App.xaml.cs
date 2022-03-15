using AA.Domain.Users;
using AA.UI.Models;
using AA.UI.Views.Pages;
using AA.UI.Views.Windows;
using System;
using System.Windows;

namespace AA.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static MenuItem[] UnAuthItems =
        {
            new("На главную", ChangeToMainPage),
            new("Авторизация", ChangeToAuthorizationPage),
            new("Регистрация", ChangeToRegistrationPage),
        };

        private static MenuItem[] AuthItems =
        {
            new("На главную", ChangeToMainPage),
            new("Справочник приложений", ChangeToApplicationsPage),
            new("Добавить приложение", ChangeToAddApplicationPage),
            new("Выйти", UnsetUser),
        };

        public static BaseWindow Base => Current.MainWindow is BaseWindow baseWindow ? baseWindow : throw new Exception("Не удалось найти базовое окно");
        public static User? CurrentUser { get; set; }
        internal static MenuItem[] MenuItems { get; set; } = UnAuthItems!;

        #region Pages

        public static void ChangeToMainPage()
        {
            Base.MainFrame.Content = new MainPage();
            Base.SetTitle("Аналитика приложений");
        }

        public static void ChangeToAuthorizationPage()
        {
            Base.MainFrame.Content = new AuthorizationPage();
            Base.SetTitle("Авторизация");
        }

        public static void ChangeToRegistrationPage()
        {
            Base.MainFrame.Content = new RegistrationPage();
            Base.SetTitle("Регистрация");
        }

        public static void ChangeToApplicationsPage()
        {
            Base.MainFrame.Content = new ApplicationsPage();
            Base.SetTitle("Справочник приложений");
        }

        public static void ChangeToAddApplicationPage()
        {
            Base.MainFrame.Content = new ApplicationEditorPage();
            Base.SetTitle("Добавление приложения");
        }

        public static void ChangeToEditApplicationPage(AA.Domain.Applications.Application app)
        {
            Base.MainFrame.Content = new ApplicationEditorPage(app);
            Base.SetTitle("Редактирование приложения");
        }

        #endregion Pages

        public static void SetUser(User user)
        {
            CurrentUser = user;
            MenuItems = AuthItems;
            ChangeToMainPage();
            Base.RefreshMenu();
        }

        public static void UnsetUser()
        {
            CurrentUser = null;
            MenuItems = UnAuthItems;
            ChangeToMainPage();
            Base.RefreshMenu();
        }

        public static MessageBoxResult ShowMessage(String error, MessageBoxButton button = MessageBoxButton.OK, MessageBoxImage image = MessageBoxImage.Asterisk)
        {
            return MessageBox.Show(error, "Информация", button, image);
        }
    }
}
