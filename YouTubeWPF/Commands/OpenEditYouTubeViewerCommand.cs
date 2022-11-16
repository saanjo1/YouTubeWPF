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
        private YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel;
        private YouTubeViewersStore youtubeViewersStore;


        public OpenEditYouTubeViewerCommand(YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel, YouTubeViewersStore youtubeViewersStore, ModelNavigationStore modelNavigationStore)
        {
            this.youTubeViewersListingItemViewModel = youTubeViewersListingItemViewModel;
            this.youtubeViewersStore = youtubeViewersStore;
            this._modelNavigationStore = modelNavigationStore;
        }

        public override void Execute(object parameter)
        {
            YouTubeViewer _youTubeViewer = youTubeViewersListingItemViewModel._youTubeViewer;

            EditYouTubeViewersViewModel editYouTubeViewersViewModel = new EditYouTubeViewersViewModel(_youTubeViewer, youtubeViewersStore, _modelNavigationStore);
            _modelNavigationStore.CurrentViewModel = editYouTubeViewersViewModel;
        }
    }
}
