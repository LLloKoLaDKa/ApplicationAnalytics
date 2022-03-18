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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AA.UI.Views.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly ApplicationsService _applicationsService;

        public MainPage()
        {
            InitializeComponent();
            _applicationsService = new();
            if (App.CurrentUser is not null)
            {
                AppBlock.Visibility = Visibility.Visible;
                AppBlock.Text = $"Приложений под вашим руководством: {_applicationsService.GetCountForUser(App.CurrentUser!.Id)}";
            }
        }
    }
}
