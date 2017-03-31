using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FilmRating.Tools;
using Microsoft.WindowsAzure.MobileServices;
using FilmRating.EntityModels;
using System.Collections.ObjectModel;

namespace FilmRating
{
    public partial class MainPage : ContentPage
    {
        public List<movie> items;
        public ObservableCollection<movie> Movies = new ObservableCollection<movie>();
        public movie Selected = new movie();

        public async void GetMovieForName(string MovieName)
        {
            var client = new MobileServiceClient("http://filmrating.azurewebsites.net");
            IMobileServiceTable<movie> todoTable = client.GetTable<movie>();

            if (MovieName == "" || String.IsNullOrEmpty(MovieName))
            {
                items = await todoTable
                    .Where(todoItem => todoItem.Year != "")
                    .ToListAsync();
            }
            else
            {
                items = await todoTable
                    .Where(todoItem => todoItem.MovieName.Contains(MovieName))
                    .ToListAsync();
            }
            foreach (var item in items)
            {
                Movies.Add(item);
            }
        }

        private void ListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListPage.IsVisible = false;
            DetailsPage.IsVisible = true;
            var tapped = (movie)e.Item;
            Selected.MovieName = tapped.MovieName;
        }

        public MainPage()
        {
            GetMovieForName("");

            InitializeComponent();
            SearchBar.SearchButtonPressed += searchMovie;
            //Movies = new ObservableCollection<movie>();
            MoviesView.ItemsSource = this.Movies;
        }

        protected override bool OnBackButtonPressed()
        {
            ListPage.IsVisible = true;
            DetailsPage.IsVisible = false;
            return true;
        }

        private void searchMovie(object sender, EventArgs e)
        {
            Movies.Clear();
            GetMovieForName(((SearchBar)sender).Text);
        }
    }
}
