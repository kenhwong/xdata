using System.ComponentModel;

namespace XDATA.Data
{
    public class Setting : EntityBase, INotifyPropertyChanged
    {
        public string Key { get; set; }
        public string Notes { get; set; }
        public string Value { get; set; }

        public Setting()
        {

        }

        public Setting(string key, string value, string notes)
        {
            this.Key = key;
            this.Value = value;
            this.Notes = notes;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}