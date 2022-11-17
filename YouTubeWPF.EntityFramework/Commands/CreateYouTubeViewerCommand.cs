using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.Domain.Commands;
using YouTubeWPF.Domain.Models;
using YouTubeWPF.EntityFramework.DTOs;

namespace YouTubeWPF.EntityFramework.Commands
{
    public class CreateYouTubeViewerCommand : ICreateYouTubeViewerCommand
    {
        private readonly YouTubeViewersDbContextFactory _contextFactory;

        public CreateYouTubeViewerCommand(YouTubeViewersDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(YouTubeViewer youTubeViewer)
        {
            using(YouTubeViewersDbContext context = _contextFactory.Create())
            {
                YouTubeViewerDto youTubeViewerDto = new YouTubeViewerDto()
                {
                    Id = youTubeViewer.Id,
                    Username = youTubeViewer.Username,
                    IsMember = youTubeViewer.IsMember,
                    IsSubscribed = youTubeViewer.IsSubscribed
                };


                 context.YouTubeViewers.Add(youTubeViewerDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
