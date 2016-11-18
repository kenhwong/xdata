using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace XDATA
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            //InitDatabase();
        }

        public ObservableCollection<Data.Movie> _m_list;
        void InitDatabase()
        {
            using (var xcontext = new Data.xDbContext())
            {
                xcontext.Database.Initialize(true);
                Data.Movie _m = new Data.Movie()
                {
                    //M_UID = Guid.NewGuid(),
                    M_ReleaseID = "AAA-021",
                    M_ReleaseTitle = "SAMPLE TITLE",
                    M_ReleaseDate = new DateTime(2016, 5, 15)
                };
                xcontext.Movies.Add(_m);
                xcontext.SaveChanges();

                _m_list = new ObservableCollection<Data.Movie>((from m in xcontext.Movies
                                                           orderby m.M_ReleaseID
                                                           select m).ToList<Data.Movie>());
                //DataContext = _m_list;
                //SampleList.ItemsSource = _m_list;
                //_m_list.ForEach(m => SampleList.Items.Add(m));
            }
        }

    }
}
