using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TheGameNinja.Data
{
    public class Platform : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }
}
