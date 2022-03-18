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

        public Func<ChartPoint, string> PointLabel { get; set; }

        public ApplicationStatisticsPage()
        {
            InitializeComponent();

            _applicationEventsService = new();
            LoadData();

        }

        public void LoadData()
        {
            ApplicationEvent[] events = _applicationEventsService.GetAllEvents();
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
