using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeWPF.EntityFramework
{
    public class YouTubeViewersDbContextFactory
    {
        public YouTubeViewersDbContextFactory()
        {
        }

        public YouTubeViewersDbContext Create()
        {
            return new YouTubeViewersDbContext();
        }
    }
}
