using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDATA.Data;

namespace XDATA.Design
{
    class DesignDataService:IDataService
    {
        public void GetMovies(Action<ObservableCollection<Movie>, Exception> callback)
        {
            var DesignMovies = new ObservableCollection<Movie>();
            for (int index = 0; index < 15; index++)
            {
                var m = new Movie
                {
                    M_ReleaseID = $"DES-{index:000}",
                    M_ReleaseTitle = $"Description.... {index}",
                    M_ReleaseDate = new DateTime(2016, 12, index)
                };
                DesignMovies.Add(m);
            }
            callback(DesignMovies, null);
        }
        public void GetStars(Action<ObservableCollection<Star>, Exception> callback)
        {
            var DesignStars = new ObservableCollection<Star>();
            for (int index = 0; index < 15; index++)
            {
                var s = new Star
                {
                    S_JName = $"RNName{index}",
                    S_Birthday = new DateTime(1994, 5, 7),
                    S_Height = 155
                };
                DesignStars.Add(s);
            }
            callback(DesignStars, null);
        }
    }
}
