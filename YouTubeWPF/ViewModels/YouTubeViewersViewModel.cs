using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeWPF.Commands;
using YouTubeWPF.Stores;

namespace YouTubeWPF.ViewModels
{
    public class YouTubeViewersViewModel : ViewModelBase
    {
        public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel { get; }
        public YouTubeViewersListingViewModel YouTubeViewersListingViewModel { get; }

        public ICommand AddYouTubeViewersCommand { get; }

        public YouTubeViewersViewModel(SelectedYouTubeViewerStore _selectedYouTubeViewerStore, ModelNavigationStore modalNavigationStore, YouTubeViewersStore youTubeViewersStore)
        {
            
            YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel(_selectedYouTubeViewerStore, modalNavigationStore, youTubeViewersStore);
            YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel(_selectedYouTubeViewerStore);

            AddYouTubeViewersCommand = new OpenAddYouTubeViewerCommand(modalNavigationStore, youTubeViewersStore);
        }
    }
}
