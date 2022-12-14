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
    public class DeleteYouTubeViewersCommand : AsyncCommandBase
    {

        private YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel;
        private YouTubeViewersStore youtubeViewersStore;


        public DeleteYouTubeViewersCommand(YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel, YouTubeViewersStore youtubeViewersStore)
        {
            this.youTubeViewersListingItemViewModel = youTubeViewersListingItemViewModel;
            this.youtubeViewersStore = youtubeViewersStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            YouTubeViewer _youTubeViewer = youTubeViewersListingItemViewModel._youTubeViewer;

            youTubeViewersListingItemViewModel.IsDeleting = true;
            youTubeViewersListingItemViewModel.ErrorMessage = null;

            try
            {
                await youtubeViewersStore.Delete(_youTubeViewer.Id);

            }
            catch (Exception)
            {
                youTubeViewersListingItemViewModel.ErrorMessage = "Failed to delete an existing YouTube viewer. Try again.";
            }
            finally
            {
                youTubeViewersListingItemViewModel.IsDeleting = false;

            }

        }
    }
}
