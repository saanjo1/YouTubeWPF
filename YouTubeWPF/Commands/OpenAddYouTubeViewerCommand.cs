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

        public OpenAddYouTubeViewerCommand(ModelNavigationStore modelNavigationStore)
        {
            _modelNavigationStore = modelNavigationStore;
        }

        public override void Execute(object parameter)
        {
            AddYouTubeViewerViewModel addYouTubeViewerViewModel = new AddYouTubeViewerViewModel(_modelNavigationStore);
            _modelNavigationStore.CurrentViewModel = addYouTubeViewerViewModel;
        }
    }
}
