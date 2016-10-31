using System;
using System.Linq;
using System.Web;
using XDATA.Data;

namespace XDATA.Services
{
    public class StarService : ServiceBase, IStarService
    {
        public Star Get(Guid id)
        {
            using (var db = base.NewDB())
            {
                return db.Stars.Get(id);
            }
        }

        public Star Get(string jname)
        {
            using (var db = base.NewDB())
            {
                return db.Stars.FirstOrDefault(x => x.S_JName == jname);
            }
        }
    }
}
