using AA.Domain.Applications;
using AA.Domain.Applications.Events;
using AA.Domain.Results;
using AA.Services.Applications;
using AA.UI.Tools;
using System;
using System.Windows.Controls;

namespace AA.UI.Views.Pages
{
    /// <summary>
    /// Interaction logic for AddApplicationPage.xaml
    /// </summary>
    public partial class ApplicationEditorPage : Page
    {
        private readonly ApplicationsService _applicationsService;

        public ApplicationBlank Application { get; set; }

        public ApplicationEditorPage(Application? app = null)
        {
            InitializeComponent();
            _applicationsService = new();
            Application = app is null ? new ApplicationBlank() : new ApplicationBlank(app.Id, app.UserId, app.Name);

            if (app is not null)
            {
                Application = new ApplicationBlank(app.Id, app.UserId, app.Name);
                deleteButton.Visibility = System.Windows.Visibility.Visible;

                EventOneButton.Visibility = System.Windows.Visibility.Visible;
                EventTwoButton.Visibility = System.Windows.Visibility.Visible;
                EventThreeButton.Visibility = System.Windows.Visibility.Visible;
                EventFourButton.Visibility = System.Windows.Visibility.Visible;
            }
            else Application = new ApplicationBlank(null, App.CurrentUser.Id, null);

            this.DataContext = this;
        }

        private void saveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Result result = _applicationsService.SaveApp(Application);
            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error!);
                return;
            }

            App.ShowMessage("Приложение сохранено!");
            App.Base.RefreshMenu();
            App.ChangeToApplicationsPage();
        }

        private void deleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.MessageBoxResult mbresult = App.ShowMessage("Вы уверены, что хотите удалить приложение?", System.Windows.MessageBoxButton.YesNo);
            if (mbresult == System.Windows.MessageBoxResult.No) return;

            Result result = _applicationsService.DeleteApp(Application.Id.Value);
            if (!result.IsSuccess)
            {
                App.ShowMessage(result.Error);
                return;
            }

            App.ShowMessage("Приложение удалено!");
            App.ChangeToApplicationsPage();
        }

        private async void SendEvent_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button is null) return;

            Int32? eventNumber = Convert.ToInt32(button.Tag);
            if (eventNumber is null) return;

            ApplicationEventBlank eventBlank = new(null, Application.Id,
                eventNumber switch
                {
                    1 => ApplicationEventType.EventOne,
                    2 => ApplicationEventType.EventTwo,
                    3 => ApplicationEventType.EventThree,
                    4 => ApplicationEventType.EventFour,
                    _ => throw new Exception("Точка недостижимости")
                }
            );

            await HttpHelper.SaveEvent(eventBlank);
        }
    }
}
