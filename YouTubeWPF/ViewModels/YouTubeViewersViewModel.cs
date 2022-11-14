using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeWPF.Stores;

namespace YouTubeWPF.ViewModels
{
    public class YouTubeViewersViewModel : ViewModelBase
    {
        public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel { get; }
        public YouTubeViewersListingViewModel YouTubeViewersListingViewModel { get; }

        public ICommand AddYouTubeViewersCommand { get; }

        public YouTubeViewersViewModel(SelectedYouTubeViewerStore _selectedYouTubeViewerStore)
        {
            
            YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel(_selectedYouTubeViewerStore);
            YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel(_selectedYouTubeViewerStore);
        }
    }
}
