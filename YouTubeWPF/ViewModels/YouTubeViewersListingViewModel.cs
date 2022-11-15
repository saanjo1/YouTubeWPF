using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeWPF.Commands;
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




        public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore _selectedYouTubeViewerStore, ModelNavigationStore modelNavigationStore)
        {
            selectedYouTubeViewStore = _selectedYouTubeViewerStore;
            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();

            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();
            AddYouTubeViewer(new YouTubeViewer("Sanjin", false, false), modelNavigationStore);
            AddYouTubeViewer(new YouTubeViewer("Mirza", true, false), modelNavigationStore);
            AddYouTubeViewer(new YouTubeViewer("Amina", true, true), modelNavigationStore);
        }

        private void AddYouTubeViewer(YouTubeViewer youTubeViewer, ModelNavigationStore modelNavigationStore)
        {
            ICommand editCommand = new OpenEditYouTubeViewerCommand(modelNavigationStore, youTubeViewer);
            _youTubeViewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel(youTubeViewer, editCommand));
        }
    }
}
