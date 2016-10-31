using System;
using XDATA.Data;

namespace XDATA.Services
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
