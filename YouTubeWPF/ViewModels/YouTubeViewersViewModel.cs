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

        private bool _IsLoading;

        public bool IsLoading
        {
            get { return _IsLoading; }
            set { 
                _IsLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }




        public ICommand AddYouTubeViewersCommand { get; }
        public ICommand _LoadYouTubeViewersCommand { get; }


        public YouTubeViewersViewModel(SelectedYouTubeViewerStore _selectedYouTubeViewerStore, ModelNavigationStore modalNavigationStore, YouTubeViewersStore youTubeViewersStore)
        {
            
            YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel(_selectedYouTubeViewerStore, modalNavigationStore, youTubeViewersStore);
            YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel(_selectedYouTubeViewerStore);

            _LoadYouTubeViewersCommand = new LoadYouTubeViewersCommand(this, youTubeViewersStore);
            AddYouTubeViewersCommand = new OpenAddYouTubeViewerCommand(modalNavigationStore, youTubeViewersStore);
        }

        public static YouTubeViewersViewModel LoadViewModel(SelectedYouTubeViewerStore _selectedYouTubeViewerStore, ModelNavigationStore modelNavigationStore, YouTubeViewersStore youTubeViewersStore)
        {
            YouTubeViewersViewModel viewModel = new YouTubeViewersViewModel(_selectedYouTubeViewerStore, modelNavigationStore, youTubeViewersStore);

            viewModel._LoadYouTubeViewersCommand.Execute(null);

            return viewModel;

        }
    }
}
