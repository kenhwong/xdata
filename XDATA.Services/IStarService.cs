using System;
using XDATA.Data;

namespace XDATA.Services
{
    public interface IStarService
    {
        Star Get(Guid uid);
        Star Get(string jname);
    }
}
