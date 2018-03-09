using MovieFinder.Models;
using MovieFinder.Service;
using MovieFinder.StaticData;
using MovieFinder.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieFinder.ViewModels
{
    public class MovieListViewModel : BaseViewModel
    {
        private int _page { get; set; }

        private const int requestKeySize = 10;
        private string requestKey;

        public MovieListViewModel(INavigation navigation)
        {
            Navigation = navigation;

            MovieList = new ObservableCollection<Movie>();

            _page = 1;
            IsLogVisible = IsLoading = false;
            Log = ListValues.Log[0];

            GetMovies();
        }

        private string _query;
        public string Query
        {
            get { return _query; }
            set {
                _query = value;

                MovieList = new ObservableCollection<Movie>();
                _page = 1;

                if (_query.Length == 0)
                {
                    GetMovies();
                }
                else
                {
                    GetMoviesByQuery();
                }
            }
        }

        public void ItemTapped(Movie item)
        {
            Log = item.title;
            DataService.selectedMovie = item;
            PushPage(new DetailsPage());
        }

        private ObservableCollection<Movie> _moviesList;
        public ObservableCollection<Movie> MovieList
        {
            get { return _moviesList; }
            set { _moviesList = value; RaisePropertyChanged();  }
        }

        public async void GetMovies()
        {
            requestKey = RandomString(requestKeySize);

            DataService.connected = false;
            IsLoading = true;

            while (!DataService.connected)
            {
            
                Cts = new CancellationTokenSource();
                try
                {
                    Cts.CancelAfter(15000);

                    string responseKey = await DataService.GetMovies(Cts.Token, _page, requestKey);

                    if (requestKey.Equals(responseKey))
                        foreach (Movie m in DataService.movies)
                            MovieList.Add(m);
                    
                    IsLogVisible = false;
                }
                catch (OperationCanceledException)
                {
                    DataService.connected = false;
                    IsLogVisible = true;
                }
                catch (Exception)
                {
                    DataService.connected = false;
                    IsLogVisible = true;
                }
            }
            Cts = null;
            
            _page++;
            IsLoading = false;
        }

        public async void GetMoviesByQuery()
        {
            requestKey = RandomString(requestKeySize);

            DataService.connected = false;
            IsLoading = true;

            while (!DataService.connected)
            {

                Cts = new CancellationTokenSource();
                try
                {
                    Cts.CancelAfter(15000);

                    string responseKey = await DataService.GetMoviesByQuery(Cts.Token, _page, Query, requestKey);

                    if (requestKey.Equals(responseKey))
                        foreach (Movie m in DataService.movies)
                            MovieList.Add(m);

                    IsLogVisible = false;
                }
                catch (OperationCanceledException)
                {
                    DataService.connected = false;
                    IsLogVisible = true;
                }
                catch (Exception)
                {
                    DataService.connected = false;
                    IsLogVisible = true;
                }
            }
            Cts = null;

            _page++;
            IsLoading = false;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
