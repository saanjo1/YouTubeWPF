using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.Domain.Models;

namespace YouTubeWPF.Stores
{
    public class SelectedYouTubeViewerStore
    {
        private YouTubeViewer _selectedYouTubeViewer;
        private YouTubeViewersStore _youTubeViewersStore;

        public SelectedYouTubeViewerStore(YouTubeViewersStore youTubeViewersStore)
        {
            _youTubeViewersStore = youTubeViewersStore;

            _youTubeViewersStore.YouTubeViewerUpdated += _youTubeViewersStore_YouTubeViewerUpdated;
        }

        private void _youTubeViewersStore_YouTubeViewerUpdated(YouTubeViewer obj)
        {
           if(obj.Id == SelectedYouTubeViewer?.Id)
            {
                SelectedYouTubeViewer = obj;
            }
        }

        public YouTubeViewer SelectedYouTubeViewer
        {
            get { return _selectedYouTubeViewer; }

            set
            {
                _selectedYouTubeViewer = value;
                SelectedYouTubeViewerChanged?.Invoke();
            }
        }

        public event Action SelectedYouTubeViewerChanged;
    }
}
