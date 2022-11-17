﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.Domain.Commands;
using YouTubeWPF.Domain.Models;
using YouTubeWPF.Domain.Queries;

namespace YouTubeWPF.Stores
{
    public class YouTubeViewersStore
    {
        public event Action<YouTubeViewer> YouTubeViewerAdded;
        public event Action<YouTubeViewer> YouTubeViewerUpdated;
        public event Action<Guid> YouTubeViewersDeleted;
        public event Action YouTubeViewersLoaded;

        private readonly List<YouTubeViewer> _youTubeViewers;
        public IEnumerable<YouTubeViewer> YouTubeViewers => _youTubeViewers;


        private readonly IGetAllYouTubeViewersQuery _getAllYouTubeViewersQuery;
        private readonly ICreateYouTubeViewerCommand _createYouTubeViewerCommand;
        private readonly IUpdateYouTubeViewerCommand _updateYouTubeViewerCommand;
        private readonly IDeleteYouTubeViewerCommand _deleteYouTubeViewerCommand;

        public YouTubeViewersStore(IGetAllYouTubeViewersQuery getAllYouTubeViewersQuery, 
            ICreateYouTubeViewerCommand createYouTubeViewerCommand,
            IUpdateYouTubeViewerCommand updateYouTubeViewerCommand,
            IDeleteYouTubeViewerCommand deleteYouTubeViewerCommand)
        {
            _getAllYouTubeViewersQuery = getAllYouTubeViewersQuery;
            _createYouTubeViewerCommand = createYouTubeViewerCommand;
            _updateYouTubeViewerCommand = updateYouTubeViewerCommand;
            _deleteYouTubeViewerCommand = deleteYouTubeViewerCommand;

            _youTubeViewers = new List<YouTubeViewer>();
        }

        public async Task Load()
        {
            IEnumerable<YouTubeViewer> youTubeViewers = await _getAllYouTubeViewersQuery.Execute();

            _youTubeViewers.Clear();

            _youTubeViewers.AddRange(youTubeViewers);

            YouTubeViewersLoaded?.Invoke();
        }

        public async Task Add(YouTubeViewer youTubeViewer)
        {
            await _createYouTubeViewerCommand.Execute(youTubeViewer);

            _youTubeViewers.Add(youTubeViewer);

            YouTubeViewerAdded?.Invoke(youTubeViewer);
        }

        public async Task Update(YouTubeViewer youTubeViewer)
        {
            await _updateYouTubeViewerCommand.Execute(youTubeViewer);

            int currentIndex = _youTubeViewers.FindIndex(y => y.Id == youTubeViewer.Id);

            if(currentIndex != -1)
            {
                _youTubeViewers[currentIndex] = youTubeViewer;
            }
            else
            {
                _youTubeViewers.Add(youTubeViewer);
            }

            YouTubeViewerUpdated?.Invoke(youTubeViewer);
        }

        public async Task Delete(Guid id)
        {
            await _deleteYouTubeViewerCommand.Execute(id);

            _youTubeViewers.RemoveAll(x=>x.Id == id);

            YouTubeViewersDeleted?.Invoke(id);
        }
    }
}
