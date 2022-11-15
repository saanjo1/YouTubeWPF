using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.Stores;

namespace YouTubeWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;

        public ViewModelBase CurrentModalViewModel => _modelNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modelNavigationStore.IsOpen;

        public YouTubeViewersViewModel YouTubeViewersViewModel { get; }

        public MainViewModel(ModelNavigationStore modelNavigationStore, YouTubeViewersViewModel youTubeViewersViewModel)
        {
            _modelNavigationStore = modelNavigationStore;
            YouTubeViewersViewModel = youTubeViewersViewModel;

            _modelNavigationStore.CurrentViewModelChanged += _modelNavigationStore_CurrentViewModelChanged;

            _modelNavigationStore.CurrentViewModel = new AddYouTubeViewerViewModel();
        }
        protected override void Dispose()
        {
            _modelNavigationStore.CurrentViewModelChanged -= _modelNavigationStore_CurrentViewModelChanged;

            base.Dispose();
        }

        private void _modelNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
