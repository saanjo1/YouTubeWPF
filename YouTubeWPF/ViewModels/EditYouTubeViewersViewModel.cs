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
        private readonly ModelNavigationStore _modelNavigationStore;
        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }

        public EditYouTubeViewersViewModel(YouTubeViewer youtubeviewer, ModelNavigationStore model)
        {
            _modelNavigationStore = model;
            ICommand cancelCommand = new CloseModalCommand(_modelNavigationStore);
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(null, cancelCommand)
            {
                Username = youtubeviewer.Username,
                IsMember = youtubeviewer.IsMember,
                IsSubscribed = youtubeviewer.IsSubscribed
            };
        }
    }
}
