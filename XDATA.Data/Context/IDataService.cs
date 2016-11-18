using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDATA.Data
{
    public interface IDataService
    {
        void GetMovies(Action<ObservableCollection<Movie>, Exception> callback);
        void GetStars(Action<ObservableCollection<Star>, Exception> callback);
    }
}
