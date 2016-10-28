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

namespace XDATA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitDatabase();
        }

        List<Model.Movie> _m_list;
        void InitDatabase()
        {
            using (var xcontext = new xDbContext())
            {
                xcontext.Database.Initialize(true);
                Model.Movie _m = new Model.Movie()
                {
                    //M_UID = Guid.NewGuid(),
                    M_ReleaseID = "AAA-021",
                    M_ReleaseTitle = "SAMPLE TITLE",
                    M_ReleaseDate = new DateTime(2016, 5, 15)
                };
                xcontext.Movies.Add(_m);
                xcontext.SaveChanges();

                _m_list = (from m in xcontext.Movies
                          orderby m.M_ReleaseID
                          select m).ToList<Model.Movie>();

            }
        }

    }
}
