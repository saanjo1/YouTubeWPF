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
    public class AddYouTubeViewerViewModel : ViewModelBase
    {
        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }

        public AddYouTubeViewerViewModel(ModelNavigationStore modelNavigationStore, YouTubeViewersStore _youTubeViewersStore)
        {
            ICommand cancelCommand = new CloseModalCommand(modelNavigationStore);
            ICommand submitCommand = new SubmitAddCommand(this, modelNavigationStore, _youTubeViewersStore);
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
