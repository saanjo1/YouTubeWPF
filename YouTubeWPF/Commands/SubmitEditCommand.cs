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
    public class SubmitEditCommand : AsyncCommandBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly Guid _youTubeViewerId;
        private readonly EditYouTubeViewersViewModel _editYouTubeViewersViewModel;

        public SubmitEditCommand(EditYouTubeViewersViewModel editYouTubeViewersViewModel, ModelNavigationStore modelNavigationStore, YouTubeViewersStore youTubeViewersStore, Guid youTubeViewerId)
        {
            _modelNavigationStore = modelNavigationStore;
            _youTubeViewersStore = youTubeViewersStore;
            _youTubeViewerId = youTubeViewerId;
            _editYouTubeViewersViewModel = editYouTubeViewersViewModel;
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
            //Edit and submit to database
            //Add to database
            var formViewModel = _editYouTubeViewersViewModel.YouTubeViewerDetailsFormViewModel;

            YouTubeViewer youTubeViewer = new YouTubeViewer(
                _youTubeViewerId,
                formViewModel.Username,
                formViewModel.IsSubscribed,
                formViewModel.IsMember);

            try
            {
                await _youTubeViewersStore.Update(youTubeViewer);
            }
            catch (Exception) { }
            _modelNavigationStore.Close();
        }
    }
    }

