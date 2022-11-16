using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeWPF.Commands;
using YouTubeWPF.Models;
using YouTubeWPF.Stores;
using YouTubeWPF.ViewModels;

namespace YouTubeWPF.ViewModels
{
    public class EditYouTubeViewersViewModel : ViewModelBase
    {
        public Guid YouTubeViewerId { get; }

        private readonly ModelNavigationStore _modelNavigationStore;
        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }

        public EditYouTubeViewersViewModel(YouTubeViewer youtubeviewer, YouTubeViewersStore youtubeViewersStore, ModelNavigationStore model)
        {
            YouTubeViewerId = youtubeviewer.Id;

            _modelNavigationStore = model;
            ICommand cancelCommand = new CloseModalCommand(_modelNavigationStore);
            ICommand submitCommand = new SubmitEditCommand(this, _modelNavigationStore, youtubeViewersStore, YouTubeViewerId);
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(submitCommand, cancelCommand)
            {
                Username = youtubeviewer.Username,
                IsMember = youtubeviewer.IsMember,
                IsSubscribed = youtubeviewer.IsSubscribed
            };
        }
    }
}
