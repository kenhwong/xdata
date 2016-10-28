using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDATA
{
    public interface ISimpleEntity
    {
        Guid UID { get; set; }
        string Name { get; set; }
    }

    public class SimpleEntity : ISimpleEntity
    {
        public Guid UID { get; set; }
        public string Name { get; set; }

        public SimpleEntity()
        {
            
        }

        public SimpleEntity(Guid id, string name)
        {
            this.UID = id;
            this.Name = name;
        }
    }
}
