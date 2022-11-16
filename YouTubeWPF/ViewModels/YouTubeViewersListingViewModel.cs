using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeWPF.Commands;
using YouTubeWPF.Domain.Models;
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

        public ICommand _LoadYouTubeViewersCommand { get; }


        public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore _selectedYouTubeViewerStore, ModelNavigationStore modelNavigationStore, YouTubeViewersStore youTubeViewersStore)
        {
            selectedYouTubeViewStore = _selectedYouTubeViewerStore;
            _youtubeViewersStore = youTubeViewersStore;
            _modelNavigationStore = modelNavigationStore;

            _LoadYouTubeViewersCommand = new LoadYouTubeViewersCommand(youTubeViewersStore);
            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();

            _youtubeViewersStore.YouTubeViewerAdded += _youtubeViewersStore_YouTubeViewerAdded;
            _youtubeViewersStore.YouTubeViewerUpdated += _youtubeViewersStore_YouTubeViewerUpdated;
            _youtubeViewersStore.YouTubeViewersLoaded += _youtubeViewersStore_YouTubeViewersLoaded;
            _youtubeViewersStore.YouTubeViewersDeleted += _youtubeViewersStore_YouTubeViewersDeleted;

        }

        private void _youtubeViewersStore_YouTubeViewersDeleted(Guid obj)
        {
            var itemViewModel = _youTubeViewersListingItemViewModels.FirstOrDefault(x => x._youTubeViewer?.Id == obj);

            if(itemViewModel != null)
            {
                _youTubeViewersListingItemViewModels.Remove(itemViewModel);
            }
        }

        private void _youtubeViewersStore_YouTubeViewersLoaded()
        {
            _youTubeViewersListingItemViewModels.Clear();

            foreach (var youTubeViewer in _youtubeViewersStore.YouTubeViewers)
            {
                AddYouTubeViewer(youTubeViewer);
            }

        }

        public static YouTubeViewersListingViewModel LoadViewModel(SelectedYouTubeViewerStore _selectedYouTubeViewerStore, ModelNavigationStore modelNavigationStore, YouTubeViewersStore youTubeViewersStore)
        {
            YouTubeViewersListingViewModel viewModel = new YouTubeViewersListingViewModel(_selectedYouTubeViewerStore, modelNavigationStore, youTubeViewersStore);

            viewModel._LoadYouTubeViewersCommand.Execute(null);

            return viewModel;

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
            _youtubeViewersStore.YouTubeViewersLoaded -= _youtubeViewersStore_YouTubeViewersLoaded; 
            _youtubeViewersStore.YouTubeViewersDeleted -= _youtubeViewersStore_YouTubeViewersDeleted;


            base.Dispose();
        }

        private void AddYouTubeViewer(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersListingItemViewModel vms = new YouTubeViewersListingItemViewModel(_youtubeViewersStore, _modelNavigationStore, youTubeViewer);
            _youTubeViewersListingItemViewModels.Add(vms);
        }
    }
}
