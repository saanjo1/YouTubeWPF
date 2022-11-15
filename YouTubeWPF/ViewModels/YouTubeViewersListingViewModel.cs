using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.Models;
using YouTubeWPF.Stores;

namespace YouTubeWPF.ViewModels
{
    public class YouTubeViewersListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _youTubeViewersListingItemViewModels;

        public IEnumerable<YouTubeViewersListingItemViewModel> YouTubeViewersListingItemViewModels => _youTubeViewersListingItemViewModels;


        private readonly SelectedYouTubeViewerStore selectedYouTubeViewStore;

        private YouTubeViewersListingItemViewModel _selectedYouTubeViewerListingItemViewModel;

        public YouTubeViewersListingItemViewModel SelectedYouTubeViewewrListingItemViewModel
        {
            get { return _selectedYouTubeViewerListingItemViewModel; }
            set { 
                _selectedYouTubeViewerListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedYouTubeViewewrListingItemViewModel));

                selectedYouTubeViewStore.SelectedYouTubeViewer = _selectedYouTubeViewerListingItemViewModel?._youTubeViewer;
            
            }
        }




        public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore _selectedYouTubeViewerStore)
        {
            selectedYouTubeViewStore = _selectedYouTubeViewerStore;
            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();

            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();
            _youTubeViewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel(new YouTubeViewer("Sanjin", true, true)));
            _youTubeViewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel(new YouTubeViewer("Mirza", false, false)));
            _youTubeViewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel(new YouTubeViewer("Amina", false, true)));
        }
    }
}
