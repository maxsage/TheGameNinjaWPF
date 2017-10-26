using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameNinja.Desktop.Accolades
{
    public class SimpleEditableAccolade : ValidatableBindableBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private int _videoGameId;
        public int VideoGameId
        {
            get { return _videoGameId; }
            set { SetProperty(ref _videoGameId, value); }
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

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { SetProperty(ref _imageUrl, value); }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value); }
        }

        private DateTime? _dateEarned;
        public DateTime? DateEarned
        {
            get { return _dateEarned; }
            set { SetProperty(ref _dateEarned, value); }
        }

        private bool? _onlineOnly;
        public bool? OnlineOnly
        {
            get { return _onlineOnly; }
            set { SetProperty(ref _onlineOnly, value); }
        }
    }
}
