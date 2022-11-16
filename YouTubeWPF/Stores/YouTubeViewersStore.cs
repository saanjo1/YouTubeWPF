﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.Models;

namespace YouTubeWPF.Stores
{
    public class YouTubeViewersStore
    {
        public event Action<YouTubeViewer> YouTubeViewerAdded;
        public event Action<YouTubeViewer> YouTubeViewerUpdated;

        public async Task Add(YouTubeViewer youTubeViewer)
        {
            YouTubeViewerAdded?.Invoke(youTubeViewer);
        }

        public async Task Update(YouTubeViewer youTubeViewer)
        {
            YouTubeViewerUpdated?.Invoke(youTubeViewer);
        }
    }
}