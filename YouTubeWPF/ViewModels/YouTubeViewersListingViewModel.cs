using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeWPF.ViewModels
{
    public class YouTubeViewersListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _youTubeVIewersListingItemViewModels;

        public IEnumerable<YouTubeViewersListingItemViewModel> YouTubeViewersListingItemViewModels => _youTubeVIewersListingItemViewModels;

        public YouTubeViewersListingViewModel()
        {
            _youTubeVIewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();
            _youTubeVIewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel("Mary"));
            _youTubeVIewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel("Seam"));
            _youTubeVIewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel("Tom"));
        }
    }
}
