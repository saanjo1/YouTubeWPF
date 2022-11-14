using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeWPF.ViewModels
{
    public class YouTubeViewersDetailsViewModel : ViewModelBase
    {
        public string Username { get; }
        public string IsSubscribedDisplay  { get; }
        public string IsMemberDisplayed { get; }

        public YouTubeViewersDetailsViewModel()
        {
            Username = "Singleton Sean";
            IsSubscribedDisplay = "Yes";
            IsMemberDisplayed = "Yes";
        }
    }
}
