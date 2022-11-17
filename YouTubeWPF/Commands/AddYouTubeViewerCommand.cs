using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.Domain.Models;
using YouTubeWPF.Stores;
using YouTubeWPF.ViewModels;

namespace YouTubeWPF.Commands
{
    public class AddYouTubeViewerCommand : AsyncCommandBase
    {
        private readonly AddYouTubeViewerViewModel _addYouTubeViewerViewModel;
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly YouTubeViewersStore _youTubeViewersStore;

        public AddYouTubeViewerCommand(AddYouTubeViewerViewModel addYouTubeViewerViewModel, ModelNavigationStore modelNavigationStore, YouTubeViewersStore youTubeViewersStore)
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

            formViewModel.IsSubmitting = true;
            formViewModel.ErrorMessage = null;

            YouTubeViewer youTubeViewer = new YouTubeViewer(
                Guid.NewGuid(),
                formViewModel.Username, 
                formViewModel.IsSubscribed, 
                formViewModel.IsMember);

            try
            {
                await _youTubeViewersStore.Add(youTubeViewer);
                _modelNavigationStore.Close();

            }
            catch (Exception) {

                formViewModel.ErrorMessage = "Failed to add a new YouTube Viewer. Please try again in a while.";
            
            }
            finally
            {
                formViewModel.IsSubmitting = false;
            }
        }
    }
}
