using MovieFinder.Service;
using MovieFinder.StaticData;
using MovieFinder.Views;
using System;
using System.Threading;

namespace MovieFinder.ViewModels
{
    public class LoadingViewModel : BaseViewModel
    {
        public LoadingViewModel()
        {
            IsLogVisible = false;

            DataService.Init();

            Log = ListValues.Log[0];
            GetGenres();
        }

        public async void GetGenres()
        {
            DataService.connected = false;
            IsLoading = true;

            while (!DataService.connected)
            {
                Cts = new CancellationTokenSource();
                try
                {
                    Cts.CancelAfter(15000);
                    await DataService.GetGenres(Cts.Token);
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
            IsLoading = false;

            ChangeMainPage(new MovieList());

        }
    }
}