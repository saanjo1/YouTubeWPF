using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeWPF.Stores;

namespace YouTubeWPF.Commands
{
    public class CloseModalCommand : CommandBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;

        public CloseModalCommand(ModelNavigationStore modelNavigationStore)
        {
            _modelNavigationStore = modelNavigationStore;
        }

        public override void Execute(object parameter)
        {
            _modelNavigationStore.Close();
        }
    }
}
