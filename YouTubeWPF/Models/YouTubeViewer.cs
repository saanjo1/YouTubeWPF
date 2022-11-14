using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeWPF.Models
{
    public class YouTubeViewer
    {
        public string Username { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }

        public YouTubeViewer(string _username, bool _subscribed, bool _member)
        {
            Username = _username;
            IsSubscribed = _subscribed;
            IsMember = _member;
        }
    }
}
