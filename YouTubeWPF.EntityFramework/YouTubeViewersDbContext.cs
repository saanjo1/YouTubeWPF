using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.EntityFramework.DTOs;

namespace YouTubeWPF.EntityFramework
{
    public class YouTubeViewersDbContext : DbContext
    {
        public YouTubeViewersDbContext() : base("name=ConfigurationModel")
        {
        }

        public DbSet<YouTubeViewerDto> YouTubeViewers { get; set; }
    }
}
