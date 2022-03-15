using AA.Domain.Applications;
using AA.Services.Applications;
using System.Windows.Controls;

namespace AA.UI.Views.Pages
{
    /// <summary>
    /// Interaction logic for ApplicationsPage.xaml
    /// </summary>
    public partial class ApplicationsPage : Page
    {
        private readonly ApplicationsService _applicationsService;

        public Application[] Apps { get; set; }

        public ApplicationsPage()
        {
            InitializeComponent();
            _applicationsService = new();
            LoadApplications();
        }

        public void LoadApplications()
        {
            Apps =_applicationsService.GetApplications();
            this.DataContext = this;
        }

        private void ApplicationsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            if (list is null) return;

            Application app = list.SelectedItem as Application;
            if (app is null) return;

            App.ChangeToEditApplicationPage(app);

            list.SelectedIndex = -1;
        }
    }
}
