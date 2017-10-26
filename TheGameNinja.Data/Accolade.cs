using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TheGameNinja.Data
{
    public class Accolade : INotifyPropertyChanged
    {
        public Accolade()
        {

        }

        [Key]
        public int Id { get; set; }

        private int _videoGameId;
        public int VideoGameId
        {
            get
            {
                return _videoGameId;
            }
            set
            {
                if (_videoGameId != value)
                {
                    _videoGameId = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("VideoGameId"));
                }
            }
        }

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

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Description"));
                }
            }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                if (_imageUrl != value)
                {
                    _imageUrl = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ImageUrl"));
                }
            }
        }

        private string _notes;
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Notes"));
                }
            }
        }

        private DateTime? _dateEarned;
        public DateTime? DateEarned
        {
            get
            {
                return _dateEarned;
            }
            set
            {
                if (_dateEarned != value)
                {
                    _dateEarned = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DateEarned"));
                }
            }
        }

        private bool? _onlineOnly;
        public bool? OnlineOnly
        {
            get
            {
                return _onlineOnly;
            }
            set
            {
                if (_onlineOnly != value)
                {
                    _onlineOnly = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("OnlineOnly"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
