using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameNinja.Desktop.VideoGames
{
    public class SimpleEditableVideoGame : ValidatableBindableBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;
        [Required]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _description;
        [Required]
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private int _genreId;
        [Required]
        public int GenreId
        {
            get { return _genreId; }
            set { SetProperty(ref _genreId, value); }
        }

        private int _platformId;
        [Required]
        public int PlatformId
        {
            get { return _platformId; }
            set { SetProperty(ref _platformId, value); }
        }

        private int _mediaTypeId;
        [Required]
        public int MediaTypeId
        {
            get { return _mediaTypeId; }
            set { SetProperty(ref _mediaTypeId, value); }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { SetProperty(ref _imageUrl, value); }
        }

        private DateTime? _datePurchased;
        [Required]
        public DateTime? DatePurchased
        {
            get { return _datePurchased; }
            set { SetProperty(ref _datePurchased, value); }
        }

        private DateTime? _dateReleased;
        [Required]
        public DateTime? DateReleased
        {
            get { return _dateReleased; }
            set { SetProperty(ref _dateReleased, value); }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value); }
        }

        private int _rating;
        public int Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }

        private int? _multiplayerRating;
        public int? MultiplayerRating
        {
            get { return _multiplayerRating; }
            set { SetProperty(ref _multiplayerRating, value); }
        }

        private bool? _currentlyPlaying;
        public bool? CurrentlyPlaying
        {
            get { return _currentlyPlaying; }
            set { SetProperty(ref _currentlyPlaying, value); }
        }

        private bool? _completed;
        public bool? Completed
        {
            get { return _completed; }
            set { SetProperty(ref _completed, value); }
        }



    }
}
