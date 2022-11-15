using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeWPF.Models;
using YouTubeWPF.Stores;
using YouTubeWPF.ViewModels;

namespace YouTubeWPF.Commands
{
    public class OpenEditYouTubeViewerCommand : CommandBase
    {

        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly YouTubeViewer _youTubeViewer;

        public OpenEditYouTubeViewerCommand(ModelNavigationStore modelNavigationStore, YouTubeViewer youTubeViewer)
        {
            _modelNavigationStore = modelNavigationStore;
            _youTubeViewer = youTubeViewer;
        }

        public override void Execute(object parameter)
        {
            EditYouTubeViewersViewModel editYouTubeViewersViewModel = new EditYouTubeViewersViewModel(_youTubeViewer, _modelNavigationStore);
            _modelNavigationStore.CurrentViewModel = editYouTubeViewersViewModel;
        }
    }
}
