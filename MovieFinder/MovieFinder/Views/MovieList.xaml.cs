using MovieFinder.Models;
using MovieFinder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieFinder.Views
{
    public partial class MovieList : ContentPage
    {
        readonly MovieListViewModel _viewModel;

        public MovieList()
        {
            InitializeComponent();
            _viewModel = new MovieListViewModel(Navigation);

            this.BindingContext = _viewModel;
        
            this.movieList.ItemAppearing += OnItemAppearing;
        }

        private void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Movie item = (Movie)e.Item;
            if (e.Item != null)
            {
                _viewModel.ItemTapped(item);
            }
        }

        private void OnItemAppearing(object Sender, ItemVisibilityEventArgs e)
        {
            Movie item = (Movie)e.Item;
            if (!_viewModel.IsLoading && item == _viewModel.MovieList.Last())
                _viewModel.GetMovies();
        }

    }
}