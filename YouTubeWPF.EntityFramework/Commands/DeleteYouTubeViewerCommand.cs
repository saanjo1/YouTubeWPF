using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.Domain.Commands;
using YouTubeWPF.EntityFramework.DTOs;

namespace YouTubeWPF.EntityFramework.Commands
{
    public class DeleteYouTubeViewerCommand : IDeleteYouTubeViewerCommand
    {
        private readonly YouTubeViewersDbContextFactory _contextFactory;

        public DeleteYouTubeViewerCommand(YouTubeViewersDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid Id)
        {
            using (YouTubeViewersDbContext context = _contextFactory.Create())
            {
                await Task.Delay(2000);
                YouTubeViewerDto youTubeViewerDto = new YouTubeViewerDto()
                {
                    Id = Id
                };

                context.YouTubeViewers.Attach(youTubeViewerDto);
                context.YouTubeViewers.Remove(youTubeViewerDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
