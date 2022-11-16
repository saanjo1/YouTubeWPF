using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeWPF.Stores;
using YouTubeWPF.ViewModels;

namespace YouTubeWPF.Commands
{
    public class OpenAddYouTubeViewerCommand : CommandBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly YouTubeViewersStore _youTubeViewersStore;

        public OpenAddYouTubeViewerCommand(ModelNavigationStore modelNavigationStore, YouTubeViewersStore youTubeViewersStore)
        {
            _modelNavigationStore = modelNavigationStore;
            _youTubeViewersStore = youTubeViewersStore;
        }

        public override void Execute(object parameter)
        {
            AddYouTubeViewerViewModel addYouTubeViewerViewModel = new AddYouTubeViewerViewModel(_modelNavigationStore, _youTubeViewersStore);
            _modelNavigationStore.CurrentViewModel = addYouTubeViewerViewModel;
        }
    }
}
