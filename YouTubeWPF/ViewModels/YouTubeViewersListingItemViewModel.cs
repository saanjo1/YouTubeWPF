using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeWPF.Commands;
using YouTubeWPF.Domain.Models;
using YouTubeWPF.Stores;

namespace YouTubeWPF.ViewModels
{
    public class YouTubeViewersListingItemViewModel : ViewModelBase
    {

        public YouTubeViewer _youTubeViewer { get; private set; }
        public string Username => _youTubeViewer.Username;

        private bool _IsDeleting;

        public bool IsDeleting
        {
            get { return _IsDeleting; }
            set { _IsDeleting = value; OnPropertyChanged(nameof(IsDeleting)); }
        }


        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }


        public YouTubeViewersListingItemViewModel(YouTubeViewersStore youtubeViewersStore, ModelNavigationStore modelNavigationStore, YouTubeViewer youTubeViewer)
        {
            _youTubeViewer = youTubeViewer;

            EditCommand = new OpenEditYouTubeViewerCommand(this, youtubeViewersStore, modelNavigationStore);
            DeleteCommand = new DeleteYouTubeViewersCommand(this, youtubeViewersStore);
        }
     
        public void Update(YouTubeViewer obj)
        {
            _youTubeViewer = obj;

            OnPropertyChanged(nameof(Username));
        }
    }
}
