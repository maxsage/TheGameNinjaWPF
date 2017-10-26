using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameNinja.Data
{
    public class VideoGameSummary : INotifyPropertyChanged
    {

        public VideoGameSummary()
        {
        }

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

        private Genre _genre;
        public Genre Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                if (_genre != value)
                {
                    _genre = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Genre"));
                }
            }
        }

        private Platform _platform;
        public Platform Platform
        {
            get
            {
                return _platform;
            }
            set
            {
                if (_platform != value)
                {
                    _platform = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Platform"));
                }
            }
        }


        private MediaType _mediaType;
        public MediaType MediaType
        {
            get
            {
                return _mediaType;
            }
            set
            {
                if (_mediaType != value)
                {
                    _mediaType = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("MediaType"));
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

        private DateTime? _datePurchased;
        public DateTime? DatePurchased
        {
            get
            {
                return _datePurchased;
            }
            set
            {
                if (_datePurchased != value)
                {
                    _datePurchased = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DatePurchased"));
                }
            }
        }

        private DateTime? _dateReleased;
        public DateTime? DateReleased
        {
            get
            {
                return _dateReleased;
            }
            set
            {
                if (_dateReleased != value)
                {
                    _dateReleased = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DateReleased"));
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

        private int _rating;
        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                if (_rating != value)
                {
                    _rating = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Rating"));
                }
            }
        }

        private int? _multiplayerRating;
        public int? MultiplayerRating
        {
            get
            {
                return _multiplayerRating;
            }
            set
            {
                if (_multiplayerRating != value)
                {
                    _multiplayerRating = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("MultiplayerRating"));
                }
            }
        }

        private bool? _currentlyPlaying;
        public bool? CurrentlyPlaying
        {
            get
            {
                return _currentlyPlaying;
            }
            set
            {
                if (_currentlyPlaying != value)
                {
                    _currentlyPlaying = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentlyPlaying"));
                }
            }
        }

        private bool? _completed;
        public bool? Completed
        {
            get
            {
                return _completed;
            }
            set
            {
                if (_completed != value)
                {
                    _completed = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Completed"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
