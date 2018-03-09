using MovieFinder.Models;
using MovieFinder.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace MovieFinder.ViewModels
{
    public class DetailsPageViewModel : BaseViewModel
    {
        public DetailsPageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            ImageLink = DataService.selectedMovie.ImageLink;
            Title = DataService.selectedMovie.title;
            Release_date = DataService.selectedMovie.release_date;
            Genres = DataService.selectedMovie.Genres;
            Overview = DataService.selectedMovie.overview;
        }

        private string _imageLink;
        public string ImageLink
        {
            get { return _imageLink; }
            set
            {
                _imageLink = value;
                RaisePropertyChanged();
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }

        private string _release_date;
        public string Release_date
        {
            get { return _release_date; }
            set
            {
                _release_date = value;
                RaisePropertyChanged();
            }
        }

        private string _genres;
        public string Genres
        {
            get { return _genres; }
            set
            {
                _genres = value;
                RaisePropertyChanged();
            }
        }

        private string _overview;
        public string Overview
        {
            get { return _overview; }
            set
            {
                _overview = value;
                RaisePropertyChanged();
            }
        }

    }
}