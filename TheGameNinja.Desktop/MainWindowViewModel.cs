using System;
using TheGameNinja.Desktop.VideoGames;
using TheGameNinja.Desktop.AccoladePrep;
using TheGameNinja.Desktop.Accolades;
using Microsoft.Practices.Unity;
using TheGameNinja.Desktop;
using TheGameNinja.Data;
using System.Security.Principal;
using System.Windows.Input;
using Prism.Interactivity.InteractionRequest;
using Prism.Commands;

namespace TheGameNinja.Desktop
{
    public class MainWindowViewModel : BindableBase
    {
        private AccoladeViewModel _accoladeViewModel = new AccoladeViewModel();
        private AccoladePrepViewModel _accoladePrepViewModel = new AccoladePrepViewModel();
        private VideoGameListViewModel _videoGameListViewModel;
        private AddEditVideoGameViewModel _addEditViewModel;

        private AddEditAccoladeViewModel _addEditAccoladeViewModel;

        private BindableBase _CurrentViewModel;

        public MainWindowViewModel()
        {
            _videoGameListViewModel = ContainerHelper.Container.Resolve<VideoGameListViewModel>();
            _addEditViewModel = ContainerHelper.Container.Resolve<AddEditVideoGameViewModel>();
            _addEditAccoladeViewModel = ContainerHelper.Container.Resolve<AddEditAccoladeViewModel>();

            NavCommand = new RelayCommand<string>(OnNav);

            _videoGameListViewModel.AddVideoGameRequested += NavToAddVideoGame;
            _videoGameListViewModel.EditVideoGameRequested += NavToEditVideoGame;
            _addEditViewModel.Done += NavToVideoGameList;

            _videoGameListViewModel.EditAccoladeRequested += NavToEditAccolade;
            _addEditAccoladeViewModel.Done += NavToVideoGameList;

            NotificationRequest = new InteractionRequest<INotification>();
            NotificationCommand = new DelegateCommand(RaiseNotification);

        }

        public InteractionRequest<INotification> NotificationRequest { get; set; }
        public ICommand NotificationCommand { get; set; }

        void RaiseNotification()
        {
            NotificationRequest.Raise(
                new Notification {
                    Title = "Notification",
                    Content = "Notification Message " },
                    r => Status = "Notified");
        }

        public string CurrentUser
        {
            get
            {
                return WindowsIdentity.GetCurrent().Name;
            }
        }

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public RelayCommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "accoladePrep":
                    CurrentViewModel = _accoladePrepViewModel;
                    break;
                case "videoGames":
                default:
                    CurrentViewModel = _videoGameListViewModel;
                    break;
            }
        }

        private string _status;

        public string Status
        {
            get { return _status; }
            set { SetProperty<string>(ref _status, value); }
        }

 

        private void NavToEditAccolade(Accolade accolade)
        {
            _addEditAccoladeViewModel.EditMode = true;
            _addEditAccoladeViewModel.SetAccolade(accolade);
            CurrentViewModel = _addEditAccoladeViewModel;
        }

        private void NavToAddVideoGame(VideoGame videoGame)
        {
            _addEditViewModel.EditMode = false;
            _addEditViewModel.SetVideoGame(videoGame);
            CurrentViewModel = _addEditViewModel;
        }

        private void NavToEditVideoGame(VideoGame videoGame)
        {
            _addEditViewModel.EditMode = true;
            _addEditViewModel.SetVideoGame(videoGame);
            CurrentViewModel = _addEditViewModel;
        }

        private void NavToVideoGameList()
        {
            CurrentViewModel = _videoGameListViewModel;
        }
    }
}
