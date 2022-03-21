using AA.Domain.Applications.Events;
using AA.Services.Applications;
using AA.Services.Applications.Events;
using AA.UI.Tools;
using LiveCharts;
using LiveCharts.Wpf;
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
    /// Interaction logic for ApplicationStatisticsPage.xaml
    /// </summary>
    public partial class ApplicationStatisticsPage : Page
    {
        private readonly ApplicationEventsService _applicationEventsService;
        public AA.Domain.Applications.Application App { get; set; }

        public ApplicationStatisticsPage(AA.Domain.Applications.Application application)
        {
            InitializeComponent();

            _applicationEventsService = new();
            App = application;
            LoadData();

        }

        public void LoadData()
        {
            ApplicationEvent[] events = _applicationEventsService.GetApplicationId(App.Id);
            if (events.Length == 0)
            {
                PieCharts.Visibility = Visibility.Hidden;
                PlaceHolderText.Visibility = Visibility.Visible;
                return;
            }

            Dictionary<ApplicationEventType, Int32> dictionary = events.GroupBy(ev => ev.Type).ToDictionary(group => group.Key, group => group.Count());

            SeriesCollection series = new();
            foreach (KeyValuePair<ApplicationEventType, Int32> item in dictionary)
            {
                PieSeries serie = new();
                serie.Title = item.Key.GetDisplayName();
                serie.Values = new ChartValues<Int32> { item.Value };
                serie.DataLabels = true;

                series.Add(serie);
            }

            PieCharts.Series = series;
        }
    }
}
