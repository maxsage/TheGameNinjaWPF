using System;
using System.Collections.ObjectModel;
using TheGameNinja.Data;
using TheGameNinja.Desktop.Services;

namespace TheGameNinja.Desktop.VideoGames
{
    class AddEditVideoGameViewModel : BindableBase
    {
        private IVideoGamesRepository _repo;
        private IGenresRepository _genresRepository;
        private IMediaTypesRepository _mediaTypesRepository;
        private IPlatformsRepository _platformsRepository;

        private ObservableCollection<Genre> _genres;
        public ObservableCollection<Genre> Genres
        {
            get { return _genres; }
            set { SetProperty(ref _genres, value); }
        }

        private ObservableCollection<MediaType> _mediaTypes;
        public ObservableCollection<MediaType> MediaTypes
        {
            get { return _mediaTypes; }
            set { SetProperty(ref _mediaTypes, value); }
        }

        private ObservableCollection<Platform> _platforms;
        public ObservableCollection<Platform> Platforms
        {
            get { return _platforms; }
            set { SetProperty(ref _platforms, value); }
        }

        public AddEditVideoGameViewModel(IVideoGamesRepository repo, IGenresRepository genresRepository, IMediaTypesRepository mediaTypesRepository, IPlatformsRepository platformsRepository)
        {
            _repo = repo;
            _genresRepository = genresRepository;
            _mediaTypesRepository = mediaTypesRepository;
            _platformsRepository = platformsRepository;
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave); 
        }
        private bool _EditMode;
        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }

        private SimpleEditableVideoGame _VideoGame;
        public SimpleEditableVideoGame VideoGame
        {
            get { return _VideoGame; }
            set { SetProperty(ref _VideoGame, value); }
        }

        private VideoGame _editingVideoGame = null;

        public void SetVideoGame(VideoGame videoGame)
        {
            _editingVideoGame = videoGame;
            if (VideoGame != null) VideoGame.ErrorsChanged -= RaiseCanExecuteChanged;
            VideoGame = new SimpleEditableVideoGame();
            VideoGame.ErrorsChanged += RaiseCanExecuteChanged; 
            CopyVideoGame(videoGame, VideoGame);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        public async void LoadGenres()
        {
            Genres = new ObservableCollection<Genre>(await _genresRepository.GetAllGenresAsync());
        }

        public async void LoadMediaTypes()
        {
            MediaTypes = new ObservableCollection<MediaType>(await _mediaTypesRepository.GetAllMediaTypesAsync());
        }

        public async void LoadPlatforms()
        {
            Platforms = new ObservableCollection<Platform>(await _platformsRepository.GetAllPlatformsAsync());
        }

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            UpdateVideoGame(VideoGame, _editingVideoGame);
            if (EditMode)
                await _repo.UpdateVideoGameAsync(_editingVideoGame);
            else
                await _repo.AddVideoGameAsync(_editingVideoGame);
            Done();
        }

        private bool CanSave()
        {
            return !VideoGame.HasErrors;
        }

        private void UpdateVideoGame(SimpleEditableVideoGame source, VideoGame target)
        {
            target.Name = source.Name;
            target.Description = source.Description;
            target.GenreId = source.GenreId;
            target.PlatformId = source.PlatformId;
            target.MediaTypeId = source.MediaTypeId;
            target.ImageUrl = source.ImageUrl;
            target.DatePurchased = source.DatePurchased;
            target.DateReleased = source.DateReleased;
            target.Notes = source.Notes;
            target.Rating = source.Rating;
            target.MultiplayerRating = source.MultiplayerRating;
            target.CurrentlyPlaying = source.CurrentlyPlaying;
            target.Completed = source.Completed;
        }


        private void CopyVideoGame(VideoGame source, SimpleEditableVideoGame target)
        {
            target.Id = source.Id;
            if (EditMode)
            {
                target.Name = source.Name;
                target.Description = source.Description;
                target.GenreId = source.GenreId;
                target.PlatformId = source.PlatformId;
                target.MediaTypeId = source.MediaTypeId;
                target.ImageUrl = source.ImageUrl;
                target.DatePurchased = source.DatePurchased;
                target.DateReleased = source.DateReleased;
                target.Notes = source.Notes;
                target.Rating = source.Rating;
                target.MultiplayerRating = source.MultiplayerRating;
                target.CurrentlyPlaying = source.CurrentlyPlaying;
                target.Completed = source.Completed;
            }
        }
    }
}