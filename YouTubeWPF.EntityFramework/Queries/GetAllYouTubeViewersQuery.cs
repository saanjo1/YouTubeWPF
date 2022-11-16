using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.Domain.Models;
using YouTubeWPF.Domain.Queries;
using YouTubeWPF.EntityFramework.DTOs;

namespace YouTubeWPF.EntityFramework.Queries
{
    public class GetAllYouTubeViewersQuery : IGetAllYouTubeViewersQuery
    {
        private readonly YouTubeViewersDbContextFactory _contextFactory;

        public GetAllYouTubeViewersQuery(YouTubeViewersDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<YouTubeViewer>> Execute()
        {
            using (YouTubeViewersDbContext context = _contextFactory.Create())
            {
                IEnumerable<YouTubeViewerDto> youTubeViewersDtos = await context.YouTubeViewers.ToListAsync();
                return youTubeViewersDtos.Select(y => new YouTubeViewer(y.Id, y.Username, y.IsSubscribed, y.IsMember));
            }
        }
    }
}
