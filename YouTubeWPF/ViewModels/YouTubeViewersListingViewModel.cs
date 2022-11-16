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
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly YouTubeViewersStore _youtubeViewersStore;

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




        public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore _selectedYouTubeViewerStore, ModelNavigationStore modelNavigationStore, YouTubeViewersStore youTubeViewersStore)
        {
            selectedYouTubeViewStore = _selectedYouTubeViewerStore;
            _youtubeViewersStore = youTubeViewersStore;
            _modelNavigationStore = modelNavigationStore;

            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();

            _youtubeViewersStore.YouTubeViewerAdded += _youtubeViewersStore_YouTubeViewerAdded;
            _youtubeViewersStore.YouTubeViewerUpdated += _youtubeViewersStore_YouTubeViewerUpdated;

        }

        private void _youtubeViewersStore_YouTubeViewerUpdated(YouTubeViewer obj)
        {
            var youTubeViewModel = _youTubeViewersListingItemViewModels.FirstOrDefault(x => x._youTubeViewer.Id == obj.Id);

            if(youTubeViewModel != null)
            {
                youTubeViewModel.Update(obj);
            }
        }

        private void _youtubeViewersStore_YouTubeViewerAdded(YouTubeViewer obj)
        {
            AddYouTubeViewer(obj);
        }
        protected override void Dispose()
        {
            _youtubeViewersStore.YouTubeViewerAdded -= _youtubeViewersStore_YouTubeViewerAdded;
            _youtubeViewersStore.YouTubeViewerUpdated -= _youtubeViewersStore_YouTubeViewerUpdated;

            base.Dispose();
        }

        private void AddYouTubeViewer(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersListingItemViewModel vms = new YouTubeViewersListingItemViewModel(_youtubeViewersStore, _modelNavigationStore, youTubeViewer);
            _youTubeViewersListingItemViewModels.Add(vms);
        }
    }
}
