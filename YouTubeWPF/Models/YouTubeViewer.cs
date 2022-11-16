using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeWPF.Models
{
    public class YouTubeViewer
    {
        public Guid Id { get; }
        public string Username { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }

        public YouTubeViewer(Guid id, string _username, bool _subscribed, bool _member)
        {
            Id = id;
            Username = _username;
            IsSubscribed = _subscribed;
            IsMember = _member;
        }
    }
}
