using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheGameNinja.Data
{
    public class VideoGame : INotifyPropertyChanged
    {

        public VideoGame()
        {
            //Accolades = new List<Accolade>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        private int _genreId;
        public int GenreId
        {
            get
            {
                return _genreId;
            }
            set
            {
                if (_genreId != value)
                {
                    _genreId = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("GenreId"));
                }
            }
        }

        private int _platformId;
        public int PlatformId
        {
            get
            {
                return _platformId;
            }
            set
            {
                if (_platformId != value)
                {
                    _platformId = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PlatformId"));
                }
            }
        }

        private int _mediaTypeId;
        public int MediaTypeId
        {
            get
            {
                return _mediaTypeId;
            }
            set
            {
                if (_mediaTypeId != value)
                {
                    _mediaTypeId = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("MediaTypeId"));
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
                if(_datePurchased != value)
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

        public List<Accolade> Accolades { get; set; }

        [ForeignKey("PlatformId")]
        public virtual Platform Platform { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }

        [ForeignKey("MediaTypeId")]
        public virtual MediaType MediaType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
