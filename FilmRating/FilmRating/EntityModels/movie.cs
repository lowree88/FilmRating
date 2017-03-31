using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FilmRating.EntityModels
{
    public class movie : BindableObject
    {

        public string id { get; set; }
        public string MovieName { get; set; }
        public static readonly BindableProperty MyProperty =
      BindableProperty.Create("MovieName",typeof(string),typeof(movie));
        public string Year { get; set; }
        public string Director { get; set; }
        public string RatingSum { get; set; }
        public string RatingCount { get; set; }
        public string Url { get; set; }
        public string Picture { get; set; }
        public decimal Rating { get { return Int32.Parse(RatingSum) / Int32.Parse(RatingCount); } }
    }

}
