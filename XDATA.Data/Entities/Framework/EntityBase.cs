using System;

namespace XDATA.Data
{
    public abstract class EntityBase
    {
        public Guid UID { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public bool IsNew => this.UID  == Guid.Empty;

        public void NewId()
        {
            this.UID = Guid.NewGuid();
        }

        protected EntityBase()
        {
            CreatedTime = DateTime.Now;
        }
    }
}
