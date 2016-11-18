using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDATA.Data
{
    public class DataService : IDataService
    {
        xDbContext context;
        public DataService()
        {
            context = new xDbContext();
            context.Database.CreateIfNotExists();
        }
        public void GetMovies(Action<ObservableCollection<Movie>, Exception> callback)
        {
            var _movies = context.Movies;
            callback(new ObservableCollection<Movie>(_movies), null);
        }
        public void GetStars(Action<ObservableCollection<Star>, Exception> callback)
        {
            var _stars = context.Stars;
            callback(new ObservableCollection<Star>(_stars), null);
        }
    }
}
