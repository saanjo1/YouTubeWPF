﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.Stores;
using YouTubeWPF.ViewModels;

namespace YouTubeWPF.Commands
{
    public class LoadYouTubeViewersCommand : AsyncCommandBase
    {
        private readonly YouTubeViewersViewModel _youTubeViewersViewModel;
        private readonly YouTubeViewersStore _youTubeViewersStore;

        public LoadYouTubeViewersCommand(YouTubeViewersViewModel youTubeViewersViewModel, YouTubeViewersStore youTubeViewersStore)
        {
            _youTubeViewersViewModel = youTubeViewersViewModel;
            _youTubeViewersStore = youTubeViewersStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _youTubeViewersViewModel.IsLoading = true;
            _youTubeViewersViewModel.ErrorMessage = null;

            try
            {
              await _youTubeViewersStore.Load();

            }
            catch (Exception)
            {
                _youTubeViewersViewModel.ErrorMessage = "Failed to load YouTube Viewers. Please restart the application";
                
            }
            finally
            {
                _youTubeViewersViewModel.IsLoading = false;
            }
        }
    }
}
