using Jukebox.Data;
using Jukebox.Database.Respositories;
using Jukebox.Helpers;
using Jukebox.Helpers.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Jukebox.ViewModel
{
    public class EditSongViewModel : ViewModelBase
    {
        private string _title;
        private string _artist;
        private string _duration;
        private string _art;
        private string _selectedArt;

        private ObservableCollection<string> _artSelection;

        private Song _song;

        private ArtRepository _artRepo;
        private SongRepository _songRepo;

        private ICommand _closeEditSongViewCommand;
        private ICommand _saveChangesToSongCommand;

        public EditSongViewModel(Song song)
        {
            Song = song;
            Title = Song.Title;
            Artist = Song.Artist;
            Duration = Song.Duration;
            Art = Song.Image;
            SelectedArt = Song.Image;
            _artRepo = new ArtRepository();
            ArtSelection = new ObservableCollection<string>(_artRepo.GetAlbumArt());
            _songRepo = new SongRepository();

            CloseEditSongViewCommand = new RelayCommand(new Action<object>(CloseEditSongView));
            SaveChangesToSongCommand = new RelayCommand(new Action<object>(SaveChanges), Predicate => {
                if (TitleRule.TitleRegex.IsMatch(Title) &&
                    TitleRule.TitleRegex.IsMatch(Artist) &&
                    DurationRule.DurationRegex.IsMatch(Duration))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }

        private void SaveChanges(object obj)
        {
            Song.Title = Title;
            Song.Artist = Artist;
            Song.Duration = Duration;
            Song.Image = SelectedArt;
            _songRepo.SaveSong(Song);
            Messenger.Default.Send<bool>(true, "SongUpdated");
            CloseEditSongView();
        }

        private void CloseEditSongView(object obj = null)
        {
            Messenger.Default.Send<bool>(true, "CloseEditSongView");
        }

        #region Properties
        public string Header
        {
            get { return "Edit Song: " + Song.Title + " by " + Song.Artist; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }

        public string Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public string Art
        {
            get { return _art; }
            set { _art = value; }
        }

        public string SelectedArt
        {
            get { return _selectedArt; }
            set
            {
                if (_selectedArt == value)
                    return;
                _selectedArt = value;
                OnPropertyChanged("SelectedArt");
            }
        }

        public ObservableCollection<string> ArtSelection
        {
            get { return _artSelection; }
            set { _artSelection = value; }
        }

        public Song Song
        {
            get { return _song; }
            set { _song = value; }
        }

        public ICommand SaveChangesToSongCommand
        {
            get { return _saveChangesToSongCommand; }
            set { _saveChangesToSongCommand = value; }
        }

        public ICommand CloseEditSongViewCommand
        {
            get { return _closeEditSongViewCommand; }
            set { _closeEditSongViewCommand = value; }
        }
        #endregion
    }
}
