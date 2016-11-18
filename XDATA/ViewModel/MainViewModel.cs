using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using XDATA.Data;

namespace XDATA.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";
        private string _welcomeTitle = string.Empty;

        public ViewModelBase CurrentView { get; set; }      //manage current view
        public RelayCommand MovieEditCommand { get; set; }

        private void ExecuteMovieEditCommand()
        {
        }

        ObservableCollection<Movie> _Movies;
        public ObservableCollection<Movie> Movies
        {
            get { return _Movies; }
            set { Set(ref _Movies, value); }
        }

        ObservableCollection<Star> _Stars;
        public ObservableCollection<Star> Stars
        {
            get { return _Stars; }
            set { Set(ref _Stars, value); }
        }

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Movies = new ObservableCollection<Movie>();
            _dataService.GetMovies(
                (items, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    Movies = items;
                });
            Stars = new ObservableCollection<Star>();
            _dataService.GetStars(
                (items, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    Stars = items;
                });

            MovieEditCommand = new RelayCommand(ExecuteMovieEditCommand);
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        ////if (IsInDesignMode)
        ////{
        ////    // Code runs in Blend --> create design time data.
        ////}
        ////else
        ////{
        ////    // Code runs "for real"
        ////}
    }
}
