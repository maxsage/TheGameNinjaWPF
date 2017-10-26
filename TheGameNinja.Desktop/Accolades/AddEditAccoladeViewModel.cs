using System;
using System.Collections.ObjectModel;
using TheGameNinja.Data;
using TheGameNinja.Desktop.Services;

namespace TheGameNinja.Desktop.Accolades
{
    class AddEditAccoladeViewModel : BindableBase
    {
        private IAccoladesRepository _repo;

        public AddEditAccoladeViewModel(IAccoladesRepository repo)
        {
            _repo = repo;
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave); 
        }

        private bool _EditMode;
        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }

        private SimpleEditableAccolade _Accolade;
        public SimpleEditableAccolade Accolade
        {
            get { return _Accolade; }
            set { SetProperty(ref _Accolade, value); }
        }

        private Accolade _editingAccolade = null;

        public void SetAccolade(Accolade accolade)
        {
            _editingAccolade = accolade;
            if (Accolade != null) Accolade.ErrorsChanged -= RaiseCanExecuteChanged;
            Accolade = new SimpleEditableAccolade();
            Accolade.ErrorsChanged += RaiseCanExecuteChanged; 
            CopyAccolade(accolade, Accolade);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            UpdateAccolade(Accolade, _editingAccolade);
            if (EditMode)
                await _repo.UpdateAccoladeAsync(_editingAccolade);
            else
                await _repo.AddAccoladeAsync(_editingAccolade);
            Done();
        }

        private void UpdateAccolade(SimpleEditableAccolade source, Accolade target)
        {
            target.VideoGameId = source.VideoGameId;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ImageUrl = source.ImageUrl;
            target.Notes = source.Notes;
            target.DateEarned = source.DateEarned;
            target.OnlineOnly = source.OnlineOnly;
        }

        private bool CanSave()
        {
            return !Accolade.HasErrors;
        }

        private void CopyAccolade(Accolade source, SimpleEditableAccolade target)
        {
            target.Id = source.Id;
            if (EditMode)
            {
                target.VideoGameId = source.VideoGameId;
                target.Name = source.Name;
                target.Description = source.Description;
                target.ImageUrl = source.ImageUrl;
                target.Notes = source.Notes;
                target.DateEarned = source.DateEarned;
                target.OnlineOnly = source.OnlineOnly;
            }
        }
    }
}