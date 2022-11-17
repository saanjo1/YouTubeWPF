using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YouTubeWPF.ViewModels
{
    public class YouTubeViewerDetailsFormViewModel : ViewModelBase
    {
        public YouTubeViewerDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { 
                _username = value; 
                OnPropertyChanged(nameof(Username)); 
                OnPropertyChanged(nameof(CanSubmit)); 
            }
        }

        private bool _isSubscribed;

        public bool IsSubscribed
        {
            get { return _isSubscribed; }
            set { _isSubscribed = value; 
                OnPropertyChanged(nameof(IsSubscribed)); 
            }
        }

        private bool _isMember;
        public bool IsMember
        {
            get { return _isMember; }
            set { _isMember = value; 
                OnPropertyChanged(nameof(IsMember));
            }
        }
        
        private bool _IsSubmitting;
        public bool IsSubmitting
        {
            get { return _IsSubmitting; }
            set {
                _IsSubmitting = value; 
                OnPropertyChanged(nameof(IsSubmitting));
            }
        }

        public bool CanSubmit => !string.IsNullOrEmpty(Username);

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }




    }
}
