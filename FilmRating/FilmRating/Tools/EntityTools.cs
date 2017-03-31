using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmRating.EntityModels;
namespace FilmRating.Tools
{
    public class EntityTools
    {
        public List<movie> items;
        async void ProcessDataAsync(List<movie> items)
        {
            var client = new MobileServiceClient("http://filmrating.azurewebsites.net");
            IMobileServiceTable<movie> todoTable = client.GetTable<movie>();

            // This query filters out completed TodoItems and items without a timestamp.
            items = await todoTable
                .Where(todoItem => todoItem.Year != "")
                .ToListAsync();

        }
    }
}
