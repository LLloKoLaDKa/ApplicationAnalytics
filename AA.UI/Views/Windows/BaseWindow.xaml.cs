using AA.Domain.Applications;
using AA.Services.Applications;
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
using System.Windows.Threading;
using Item = AA.UI.Models.MenuItem;

namespace AA.UI.Views.Windows
{
    /// <summary>
    /// Interaction logic for BaseWindow.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {
        private ApplicationsService _applicationsService;

        public BaseWindow()
        {
            InitializeComponent();

            App.Current.Dispatcher.UnhandledException += ExceptionHandler;
            App.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            _applicationsService = new();
            RefreshMenu();
            App.ChangeToMainPage();
        }

        public void RefreshMenu()
        {
            MenuBox.ItemsSource = App.MenuItems;
            if (App.CurrentUser is not null)
            {
                InfoBlock.Visibility = Visibility.Visible;
                UserBox.DataContext = App.CurrentUser;
                ApplicationsCountBox.Text = $"Приложений: {_applicationsService.GetCountForUser(App.CurrentUser.Id)}";
            }
            else InfoBlock.Visibility = Visibility.Collapsed;
        }

        public void SetTitle(String title) => TitleBox.Text = title;

        private void MenuBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            Item item = list.SelectedItem as Item;
            if (item is null) return;

            item.Action();
            list.SelectedIndex = -1;
        }

        private void ExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            MessageBox.Show("Произошла непредвиденная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            args.Handled = true;
        }
    }
}
