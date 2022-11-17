using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;
using YouTubeWPF.Domain.Commands;
using YouTubeWPF.Domain.Queries;
using YouTubeWPF.EntityFramework;
using YouTubeWPF.EntityFramework.Commands;
using YouTubeWPF.EntityFramework.Queries;
using System.Linq;
using System.Threading.Tasks;
using YouTubeWPF.Stores;
using YouTubeWPF.ViewModels;

namespace YouTubeWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        private readonly IHost _host;

        public App()
        {

            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<YouTubeViewersDbContextFactory>();

                    services.AddSingleton<ICreateYouTubeViewerCommand, CreateYouTubeViewerCommand>();
                    services.AddSingleton<IUpdateYouTubeViewerCommand, UpdateYouTubeViewerCommand>();
                    services.AddSingleton<IDeleteYouTubeViewerCommand, DeleteYouTubeViewerCommand>();

                    services.AddSingleton<IGetAllYouTubeViewersQuery, GetAllYouTubeViewersQuery>();

                    services.AddSingleton<YouTubeViewersStore>();
                    services.AddSingleton<SelectedYouTubeViewerStore>();
                    services.AddSingleton<ModelNavigationStore>();

                    services.AddTransient<YouTubeViewersViewModel>(CreateYouTubeViewersViewModel);
                    services.AddSingleton<MainViewModel>();

                    services.AddSingleton<MainWindow>((service) => new MainWindow
                    {
                        DataContext = service.GetRequiredService<MainViewModel>()
                    });

                }).Build();
           
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
           var contextFactory = _host.Services.GetRequiredService<YouTubeViewersDbContextFactory>();
            using (YouTubeViewersDbContext context = contextFactory.Create())
            {
                context.Database.CreateIfNotExists();
            }

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }

        private YouTubeViewersViewModel CreateYouTubeViewersViewModel(IServiceProvider services)
        {
            return YouTubeViewersViewModel.LoadViewModel(
                services.GetRequiredService<SelectedYouTubeViewerStore>(),
                services.GetRequiredService<ModelNavigationStore>(),
                services.GetRequiredService<YouTubeViewersStore>());
        }
    }
}
