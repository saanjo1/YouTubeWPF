using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.Models;
using YouTubeWPF.Stores;
using YouTubeWPF.ViewModels;

namespace YouTubeWPF.Commands
{
    public class SubmitAddCommand : AsyncCommandBase
    {
        private readonly AddYouTubeViewerViewModel _addYouTubeViewerViewModel;
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly YouTubeViewersStore _youTubeViewersStore;

        public SubmitAddCommand(AddYouTubeViewerViewModel addYouTubeViewerViewModel, ModelNavigationStore modelNavigationStore, YouTubeViewersStore youTubeViewersStore)
        {
            _addYouTubeViewerViewModel = addYouTubeViewerViewModel;
            _modelNavigationStore = modelNavigationStore;
            _youTubeViewersStore = youTubeViewersStore;
        }

        public override async void Execute(object parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception) { }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            //Add to database
           var formViewModel = _addYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel;

            YouTubeViewer youTubeViewer = new YouTubeViewer(
                Guid.NewGuid(),
                formViewModel.Username, 
                formViewModel.IsSubscribed, 
                formViewModel.IsMember);

            try
            {
                await _youTubeViewersStore.Add(youTubeViewer);
            }
            catch (Exception) { }
            _modelNavigationStore.Close();
        }
    }
}
