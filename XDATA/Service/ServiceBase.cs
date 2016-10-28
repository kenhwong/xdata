using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDATA.Service
{
    public interface IServiceBase
    {

    }

    public abstract class ServiceBase
    {
        protected xDbContext NewDB()
        {
            return new xDbContext();
        }

        protected void Try(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Logger.Error("ServiceBase.Try", ex);
            }
        }
    }
}
