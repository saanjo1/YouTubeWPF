using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeWPF.Commands;
using YouTubeWPF.Models;
using YouTubeWPF.Stores;

namespace YouTubeWPF.ViewModels
{
    public class YouTubeViewersListingItemViewModel : ViewModelBase
    {

        public YouTubeViewer _youTubeViewer { get; private set; }
        public string Username => _youTubeViewer.Username;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }


        public YouTubeViewersListingItemViewModel(YouTubeViewersStore youtubeViewersStore, ModelNavigationStore modelNavigationStore, YouTubeViewer youTubeViewer)
        {
            _youTubeViewer = youTubeViewer;

            EditCommand = new OpenEditYouTubeViewerCommand(this, youtubeViewersStore, modelNavigationStore);
        }
     
        public void Update(YouTubeViewer obj)
        {
            _youTubeViewer = obj;

            OnPropertyChanged(nameof(Username));
        }
    }
}
