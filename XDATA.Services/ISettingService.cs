using System.Collections.Generic;
using XDATA.Data;

namespace XDATA.Services
{
    public interface ISettingService
    {
        void Init(List<Setting> settings);
        List<Setting> GetAll();
        void Update(string key, string value);
    }
}
