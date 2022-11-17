﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeWPF.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        private bool _IsExecuting;

        public bool IsExecuting
        {
            get { return _IsExecuting; }
            set { _IsExecuting = value; OnCanExecuteChanged(); }
        }


        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }

        public override async void Execute(object parameter)
        {
            IsExecuting = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception) { }
            finally
            {
                IsExecuting = false;
            }
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}
