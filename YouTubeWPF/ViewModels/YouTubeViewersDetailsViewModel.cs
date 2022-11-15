using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.Models;
using YouTubeWPF.Stores;

namespace YouTubeWPF.ViewModels
{
    public class YouTubeViewersDetailsViewModel : ViewModelBase
    {
        private readonly SelectedYouTubeViewerStore selectedYouTubeViewerStore;

        private YouTubeViewer SelectedYouTubeViewer => selectedYouTubeViewerStore.SelectedYouTubeViewer;
        public bool HasSelectedYouTubeViewer => selectedYouTubeViewerStore.SelectedYouTubeViewer != null;

        public string Username => SelectedYouTubeViewer?.Username ?? "Unknown";
        public string IsSubscribedDisplay => (SelectedYouTubeViewer?.IsSubscribed ?? false) ? "Yes" : "No";
        public string IsMemberDisplayed => (SelectedYouTubeViewer?.IsMember ?? false) ? "Yes" : "No";

        public YouTubeViewersDetailsViewModel(SelectedYouTubeViewerStore _selectedYouTubeViewerStore)
        {
            selectedYouTubeViewerStore = _selectedYouTubeViewerStore;

            selectedYouTubeViewerStore.SelectedYouTubeViewerChanged += _selectedYouTubeViewerStore_SelectedYouTubeViewerChanged;
        }
        protected override void Dispose()
        {
            selectedYouTubeViewerStore.SelectedYouTubeViewerChanged -= _selectedYouTubeViewerStore_SelectedYouTubeViewerChanged;
            base.Dispose();
        }

        private void _selectedYouTubeViewerStore_SelectedYouTubeViewerChanged()
        {
            OnPropertyChanged(nameof(HasSelectedYouTubeViewer));
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(IsSubscribedDisplay));
            OnPropertyChanged(nameof(IsMemberDisplayed));
        }
    }
}
