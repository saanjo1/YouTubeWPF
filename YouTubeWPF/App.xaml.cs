using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YouTubeWPF.Stores;
using YouTubeWPF.ViewModels;

namespace YouTubeWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;

        public App()
        {
            _youTubeViewersStore = new YouTubeViewersStore();
            _selectedYouTubeViewerStore = new SelectedYouTubeViewerStore(_youTubeViewersStore);
            _modelNavigationStore = new ModelNavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            YouTubeViewersViewModel youTubeViewersViewModel = new YouTubeViewersViewModel(_selectedYouTubeViewerStore, _modelNavigationStore, _youTubeViewersStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modelNavigationStore, youTubeViewersViewModel)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
