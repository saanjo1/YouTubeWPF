using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeWPF.Models;

namespace YouTubeWPF.ViewModels
{
    public class YouTubeViewersListingItemViewModel : ViewModelBase
    {
        public YouTubeViewer _youTubeViewer { get; }

        public string Username => _youTubeViewer.Username;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public YouTubeViewersListingItemViewModel(YouTubeViewer youTubeViewer)
        {
            _youTubeViewer = youTubeViewer;
        }
    }
}
