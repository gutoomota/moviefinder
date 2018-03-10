# Movie Finder

## Written by Mário Augusto Mota Martins 

> Scroll through the list of upcoming movies - including movie name, poster or backdrop image, genre and release date. List should not be limited to show only the first 20 movies as returned by the API. 

> Select a specific movie to see details (name, poster image, genre, overview and release date). 

> (Optional) Search for movies by entering a partial or full movie name. 

## Build Details

>Target Android Version: 7.1 Nougat

>Minimum recommended Version: 4.4 KitKat

## Used platform

> Visual Studio 2017

## Used frameworks

> NETStandard.Library v2.0.1 - A set of standard .NET APIs, included in the project automatically after creation.

> Newtonsoft.Json v11.0.1 - Json framework for .NET, used to deserialize objects returned by API in Json.

> Xamarin.Forms v2.5.0.122203 - To build the native UIs for iOS and Android, included in the project automatically after creation.

## Get Started
> Run the code through the Visual Studio 2017 in an emulator or debug using a device.

## Details

> No MVVM framework was used propositely, all the needed functions to use the pattern were implemented on BaseViewModel abstract class.

> The Navigation between pages was made through NavigationPage class.

> The Movies that are presented by default are the upcoming movies, as what was asked, from current date in ascending order.

> LoadingView isn't a SplashScreen, it is just a Page to wait the API request for movie genres.

> Problem with loss of Internet connection is reported to user.

> Next page is requested to API once the user gets to the end of the list.

> The url for request Images was changed to decrease the size of the returned Images. The size used was "w200".

> Query requests made using search box runs for every character added or removed from the box, if the user delete all the characters the Placeholder reappears and the upcoming movies are requested again.

> To avoid problems with results from last requests bein shown on the list, it's generated a requestKey for every request, the requestKey is a random string, with a length of 10 unites. When the response of the request gets in the system the requestKey is checked to see if it is the last request made, if it is, the data are added to the list, if it is not, the data are discarted.

## API routes
> Genres
>> url:
>> https://api.themoviedb.org/3/genre/movie/list?api_key={api_key}&language=en-US

>> doc: 
>> https://developers.themoviedb.org/3/genres/get-movie-list

> Movies released from current date in ascending order
>> url:
>> https://api.themoviedb.org/3/discover/movie?api_key={api_key}&language=en-US&sort_by=primary_release_date.asc&include_adult=false&include_video=false&page={page}&primary_release_date.gte={current_date}

>> doc:
>> https://developers.themoviedb.org/3/discover/movie-discover

> Images
>> url:
>> https://image.tmdb.org/t/p/w200/{poster_path}

>> doc:
>> https://developers.themoviedb.org/3/getting-started/images

> Movie search by query
>> url:
>> https://api.themoviedb.org/3/search/movies?api_key={api_key}&query=a&page={page}
>> doc:
>> https://developers.themoviedb.org/3/discover/movie-discover
