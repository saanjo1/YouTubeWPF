using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YouTubeWPF.Domain.Commands;
using YouTubeWPF.Domain.Queries;
using YouTubeWPF.EntityFramework;
using YouTubeWPF.EntityFramework.Commands;
using YouTubeWPF.EntityFramework.Queries;
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

        private readonly YouTubeViewersDbContextFactory contextFactory;
        private readonly IGetAllYouTubeViewersQuery _getAllYouTubeViewersQuery;
        private readonly ICreateYouTubeViewerCommand _createYouTubeViewerCommand;
        private readonly IUpdateYouTubeViewerCommand _updateYouTubeViewerCommand;
        private readonly IDeleteYouTubeViewerCommand _deleteYouTubeViewerCommand;

        public App()
        {
            contextFactory = new YouTubeViewersDbContextFactory();
            _getAllYouTubeViewersQuery = new GetAllYouTubeViewersQuery(contextFactory);
            _createYouTubeViewerCommand = new CreateYouTubeViewerCommand(contextFactory);
            _updateYouTubeViewerCommand = new UpdateYouTubeViewerCommand(contextFactory);
            _deleteYouTubeViewerCommand = new DeleteYouTubeViewerCommand(contextFactory);
            _youTubeViewersStore = new YouTubeViewersStore(_getAllYouTubeViewersQuery, _createYouTubeViewerCommand, _updateYouTubeViewerCommand, _deleteYouTubeViewerCommand);
            _selectedYouTubeViewerStore = new SelectedYouTubeViewerStore(_youTubeViewersStore);
            _modelNavigationStore = new ModelNavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (YouTubeViewersDbContext context = contextFactory.Create())
            {
                context.Database.CreateIfNotExists();
            }


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
