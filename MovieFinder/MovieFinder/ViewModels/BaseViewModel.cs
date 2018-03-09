using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace MovieFinder.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged ([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private CancellationTokenSource _cts;
        public CancellationTokenSource Cts
        {
            get { return _cts; }
            set { _cts = value; }
        }
        
        private string _log;
        public string Log
        {
            get { return _log; }
            set
            {
                _log = value;
                RaisePropertyChanged();
            }
        }

        private bool _isLogVisible;
        public bool IsLogVisible
        {
            get { return _isLogVisible; }
            set
            {
                _isLogVisible = value;
                RaisePropertyChanged();
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                RaisePropertyChanged();
            }
        }

        public void ChangeMainPage (ContentPage view)
        {
            App.Current.MainPage = new NavigationPage(view);
        }

        public INavigation Navigation;

        public void PushPage(ContentPage view)
        {
            Navigation.PushAsync(view);
        }

        public void PopPage()
        {
            Navigation.PopAsync();
        }
    }
}
