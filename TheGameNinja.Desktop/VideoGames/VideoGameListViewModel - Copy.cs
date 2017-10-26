using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Windows.Data;
using TheGameNinja.Data;
using TheGameNinja.Desktop.Services;

namespace TheGameNinja.Desktop.VideoGames
{
    class VideoGameListViewModel : BindableBase
    {
        private IVideoGamesRepository _repo;
        private IAccoladesRepository _accoladeRepo;
        //private List<VideoGame> _allVideoGames;

        public VideoGameListViewModel(IVideoGamesRepository repo, IAccoladesRepository accoladeRepo)
        {
            _repo = repo;
            _accoladeRepo = accoladeRepo;

            AddVideoGameCommand = new RelayCommand(OnAddVideoGame);
            EditVideoGameCommand = new RelayCommand<VideoGame>(OnEditVideoGame);
            ClearSearchCommand = new RelayCommand(OnClearSearch);

            EditAccoladeCommand = new RelayCommand<Accolade>(OnEditAccolade);
            //GridSortCommand = new RelayCommand<string>(OnGridSort);

            this.PropertyChanged += MyViewModel_PropertyChanged;
        }

        public async void LoadVideoGames()
        {
            //_allVideoGames = await _repo.GetVideoGamesAsync();

            IList<VideoGame> videogames = await _repo.GetVideoGamesAsync();
            //Set the VideoGames property to read/write and used VideoGames instead of 
            // _videoGameView so I could respond to PropertyChanged events. Otherwise
            // the VideoGames dont get displayed because the above method is still 
            // executing.
            VideoGames = CollectionViewSource.GetDefaultView(videogames);

            if (_searchInput == null)
            {
                _searchInput = "";
            }


            VideoGames.Filter = VideoGameFilter;

            //VideoGames = new ObservableCollection<VideoGame>(_allVideoGames);

            //if ((!String.IsNullOrEmpty(SearchInput)) || ShowCurrentlyPlaying || HideDLC )
            //{
            //    FilterVideoGames();
            //}

            //this.VideoGamesViewSource = new CollectionViewSource();
            //VideoGamesViewSource.Source = this.VideoGames;

            //if (!string.IsNullOrWhiteSpace(SortColumn))
            //{
            //    SortGrid(SortColumn);
            //}
        }

        private bool VideoGameFilter(object item)
        {
            VideoGame videoGame = item as VideoGame;

            bool match = true; ;
            // Search
            match = videoGame.Name.ToUpper().Contains(_searchInput.ToUpper());
            // Currently Playing - only checjk if match is still true
            if (ShowCurrentlyPlaying && match)
            {
                match = videoGame.CurrentlyPlaying == ShowCurrentlyPlaying;
            }

            // Hide DLC - only checjk if match is still true
            if (HideDLC && match)
            {
                match = videoGame.MediaType.Name != "DLC";
            }


            return match;
        }

        async void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedVideoGame":
                    // Doing this here because cant seem to call async method from SelectedVideoGame property setter
                    // still just as slow though. Adding a delay of 500ms on the SelectedVideoGame seems to have 
                    // resolved the issue of scrolling through the VideoGame list and it hanging the ui whilst 
                    // retrieving the Accolade list and rendering the associated images. Filtering the videogames
                    // is still slow though. Maybe I will try a delay on SearchInput as well.
                    if (SelectedVideoGame != null)
                    {
                        Accolades =
                            new ObservableCollection<Accolade>(
                                await _accoladeRepo.GetAccoladesForVideoGamesAsync(SelectedVideoGame.Id));
                    }
                    break;
            }
        }
        //private CollectionViewSource _videoGamesViewSource;
        //public CollectionViewSource VideoGamesViewSource
        //{
        //    get { return _videoGamesViewSource; }
        //    set { SetProperty(ref _videoGamesViewSource, value); }
        //}

        //private ObservableCollection<VideoGame> _videoGames;
        //public ObservableCollection<VideoGame> VideoGames
        //{
        //    get { return _videoGames; }
        //    set { SetProperty(ref _videoGames, value); }
        //}

        private ICollectionView _videoGameView;

        public ICollectionView VideoGames
        {
            get { return _videoGameView; }
            set { SetProperty(ref _videoGameView, value);  }
        }


        private ObservableCollection<Accolade> _accolades;
        public ObservableCollection<Accolade> Accolades
        {
            get { return _accolades; }
            set { SetProperty(ref _accolades, value); }
        }

        private VideoGame _selectedVideoGame;
        public VideoGame SelectedVideoGame
        {
            get
            {
                return _selectedVideoGame;
            }
            set
            {
                SetProperty(ref _selectedVideoGame, value);
                
                //if (_selectedVideoGame != null)
                //{
                //    LoadAccolades(_selectedVideoGame.Id);
                //}
                //else
                //{
                //    Accolades.Clear();
                //}
            }
        }

        private Accolade _selectedAccolade;
        public Accolade SelectedAccolade
        {
            get
            {
                return _selectedAccolade;
            }
            set
            {
                SetProperty(ref _selectedAccolade, value);
            }
        }

        private string _searchInput;
        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                _videoGameView.Refresh();
            }
        }

        private string _lastSearchInput;
        public string LastSearchInput
        {
            get { return _lastSearchInput; }
            set
            {
                SetProperty(ref _lastSearchInput, value);
            }
        }

        //private string _sortColumn;
        //public string SortColumn
        //{
        //    get { return _sortColumn; }
        //    set
        //    {
        //        SetProperty(ref _sortColumn, value);
        //    }
        //}

        //private ListSortDirection _sortDirection;
        //public ListSortDirection SortDirection
        //{
        //    get { return _sortDirection; }
        //    set
        //    {
        //        SetProperty(ref _sortDirection, value);
        //    }
        //}

        private bool _showCurrentlyPlaying;
        public bool ShowCurrentlyPlaying
        {
            get { return _showCurrentlyPlaying; }
            set
            {
                SetProperty(ref _showCurrentlyPlaying, value);
                _videoGameView.Refresh();
            }
        }

        private bool _hideDLC;
        

        public bool HideDLC
        {
            get { return _hideDLC; }
            set
            {
                SetProperty(ref _hideDLC, value);
                _videoGameView.Refresh();
            }
        }

        //private void FilterVideoGames()
        //{
        //    bool doFiltering = false;
        //    // Watermark
        //    // http://www.codeproject.com/Articles/26977/A-WatermarkTextBox-in-3-lines-of-XAML
        //    if (string.IsNullOrWhiteSpace(SearchInput) || SearchInput.Length < 3)
        //    {
        //        VideoGames = new ObservableCollection<VideoGame>(_allVideoGames);

        //        if (!string.IsNullOrWhiteSpace(LastSearchInput))
        //        {
        //            LastSearchInput = null;
        //            SearchInput = null;
        //            doFiltering = true;
        //        }
        //        else
        //        {
        //            doFiltering = false;
        //        }
                 
        //    }
        //    else
        //    {
        //        LastSearchInput = SearchInput;

        //        VideoGames = new ObservableCollection<VideoGame>(_allVideoGames.Where(
        //            v => v.Name.ToLower().Contains(SearchInput.ToLower())));

        //        doFiltering = true;
        //    }
        //    if(ShowCurrentlyPlaying)
        //    {
        //        VideoGames = new ObservableCollection<VideoGame>(VideoGames.Where(
        //            v => v.CurrentlyPlaying == _showCurrentlyPlaying));

        //        doFiltering = true;
        //    }
        //    if (HideDLC)
        //    {
        //        VideoGames = new ObservableCollection<VideoGame>(VideoGames.Where(
        //            v => v.MediaType.Id != 3));

        //        doFiltering = true;
        //    }


        //    if (doFiltering)
        //    {
        //        VideoGamesViewSource.Source = this.VideoGames;
        //    }

        //    if (!string.IsNullOrWhiteSpace(SortColumn))
        //    {
        //        //http://stackoverflow.com/questions/15388230/linq-to-sql-sort-query-by-arbitrary-propertycolumn-name
        //        //https://www.nuget.org/packages/System.Linq.Dynamic/

        //        SortGrid(SortColumn);
        //    }
        //}

        private void FilterVideoGames()
        {
            if (string.IsNullOrWhiteSpace(SearchInput) || SearchInput.Length < 3)
            {
                //VideoGames = new ObservableCollection<VideoGame>(_allVideoGames);

                if (!string.IsNullOrWhiteSpace(LastSearchInput))
                {
                    LastSearchInput = null;
                    SearchInput = null;
                }
                else
                {
                }

            }
            else
            {
                LastSearchInput = SearchInput;

                //VideoGames = new ObservableCollection<VideoGame>(_allVideoGames.Where(v => v.Name.ToLower().Contains(SearchInput.ToLower())));

            }
            if (ShowCurrentlyPlaying)
            {
                //VideoGames = new ObservableCollection<VideoGame>(VideoGames.Where(v => v.CurrentlyPlaying == _showCurrentlyPlaying));

            }
            if (HideDLC)
            {
                //VideoGames = new ObservableCollection<VideoGame>(VideoGames.Where(v => v.MediaType.Id != 3));
            }

            //VideoGamesViewSource.Source = this.VideoGames;

            //if (!string.IsNullOrWhiteSpace(SortColumn))
            //{
            //    //http://stackoverflow.com/questions/15388230/linq-to-sql-sort-query-by-arbitrary-propertycolumn-name
            //    //https://www.nuget.org/packages/System.Linq.Dynamic/

            //    SortGrid(SortColumn);
            //}
        }


        //public RelayCommand<VideoGame> PlaceAccoladeCommand { get; private set; }
        public RelayCommand AddVideoGameCommand { get; private set; }
        public RelayCommand<VideoGame> EditVideoGameCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }

        public RelayCommand<Accolade> EditAccoladeCommand { get; private set; }
        public RelayCommand<string> GridSortCommand { get; private set; }

        public event Action<int> PlaceAccoladeRequested = delegate { };
        public event Action<VideoGame> AddVideoGameRequested = delegate { };
        public event Action<VideoGame> EditVideoGameRequested = delegate { };
        public event Action<Accolade> EditAccoladeRequested = delegate { };




        private void OnAddVideoGame()
        {
            AddVideoGameRequested(new VideoGame());

        }

        private void OnEditVideoGame(VideoGame videoGame)
        {
            EditVideoGameRequested(videoGame);
        }

        private void OnEditAccolade(Accolade accolade)
        {
            EditAccoladeRequested(accolade);
        }

        //private void OnGridSort(string columnName)
        //{
        //    //http://stackoverflow.com/questions/15572666/binding-to-datagridcolumnheader-command
        //    if (!string.IsNullOrWhiteSpace(columnName))
        //    {
        //        SortDescription sortDescription = new SortDescription(columnName, SortDirection);

        //        // If there is already a SortDescription like the one we just created in the ViewSource
        //        //if (VideoGamesViewSource.SortDescriptions.Contains(sortDescription))
        //        //{
        //            // Switcharoo the SortDirection I think
        //        //    SortDirection = SortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
        //        //}

        //        SortGrid(columnName);
        //    }
        //}

        //private void SortGrid(string columnName)
        //{
        //    // We want remember this value after we come back from a different View like editing a VideoGame, hence the 
        //    // ViewModelProperty that persists over the columnName;
        //    SortColumn = columnName;

        //    SortDescription sortDescription = new SortDescription(columnName, SortDirection);

        //    //VideoGamesViewSource.SortDescriptions.Clear();
        //    //http://stackoverflow.com/questions/11505283/re-sort-wpf-datagrid-after-bounded-data-has-changed
        //    //VideoGamesViewSource.SortDescriptions.Add(sortDescription);

        //    //VideoGamesViewSource.View.Refresh();
        //}

        private void OnClearSearch()
        {
            SearchInput = null;
        }

    }
}
