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
    public class EditPlaylistViewModel : ViewModelBase
    {
        private Playlist _playlist;
        private User _user;

        private string _title;
        private string _currentImage;
        private string _selectedImage;

        private Song _selectedOldSong;
        private Song _selectedNewSong;

        private int _playlistUserID;

        private ObservableCollection<Song> _allSongs;
        private ObservableCollection<Song> _placeholderSongs;

        private ObservableCollection<string> _artSelection;

        private SongRepository _songRepo;
        private ArtRepository _artRepo;
        private PlaylistRepository _playlistRepo;

        private ICommand _savePlaylistChangesCommand;
        private ICommand _closeEditPlaylistViewCommand;
        private ICommand _addSongToPlaylistCommand;
        private ICommand _removeSongFromPlaylistCommand;

        public EditPlaylistViewModel(Playlist playlist, User user)
        {
            Playlist = playlist;
            User = user;

            _songRepo = new SongRepository();
            _artRepo = new ArtRepository();
            _playlistRepo = new PlaylistRepository();
            _playlistRepo.Dispose();

            Art = new ObservableCollection<string>(_artRepo.GetPlaylistArt());
            AllSongs = new ObservableCollection<Song>(_songRepo.GetAllSongs());
            PlaceholderSongs = CurrentSongs;

            Title = Playlist.Title;
            Image = Playlist.Image;
            PlaylistUserID = Playlist.UserID;
            SelectedImage = Playlist.Image;

            // COMMANDS
            AddSongToPlaylistCommand = new RelayCommand(new Action<object>(AddSongToPlaylist));
            RemoveSongFromPlaylistCommand = new RelayCommand(new Action<object>(RemoveSongFromPlaylist));
            CloseEditPlaylistViewCommand = new RelayCommand(new Action<object>(CloseEditPlaylistView));
            SavePlaylistChangesCommand = new RelayCommand(new Action<object>(SavePlaylistChanges), Predicate => {
                if (TitleRule.TitleRegex.IsMatch(Title))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }

        #region Private Functions
        private void AddSongToPlaylist(object obj)
        {
            if (SelectedNewSong == null || PlaceholderSongs.IndexOf(SelectedNewSong) != -1)
                return;
            PlaceholderSongs.Add(SelectedNewSong);
            OnPropertyChanged("PlaceholderSongs");
        }

        private void RemoveSongFromPlaylist(object obj)
        {
            if (SelectedOldSong == null)
                return;
            PlaceholderSongs.Remove(SelectedOldSong);
            OnPropertyChanged("PlaceholderSongs");
        }

        private void CloseEditPlaylistView(object obj = null)
        {
            Messenger.Default.Send<bool>(true, "CloseEditPlaylistView");
        }

        private void SavePlaylistChanges(object obj)
        {
            Playlist.Title = Title;
            Playlist.Image = SelectedImage;
            Playlist.UserID = PlaylistUserID;
            Playlist.Songs = PlaceholderSongs;

            _playlistRepo.SavePlaylist(Playlist);
            Messenger.Default.Send<bool>(true, "UpdatePlaylistListView");
            Messenger.Default.Send<Playlist>(Playlist, "PlaylistSelected");
            CloseEditPlaylistView();
        }
        #endregion

        #region Properties
        public string Header
        {
            get { return "Edit Playlist: " + Playlist.Title; }
        }

        public Playlist Playlist
        {
            get { return _playlist; }
            set { _playlist = value; }
        }

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public bool IsAdmin
        {
            get { return User.IsAdmin; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Image
        {
            get { return _currentImage; }
            set { _currentImage = value; }
        }

        public string SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                if (_selectedImage == value)
                    return;
                _selectedImage = value;
            }
        }

        public Song SelectedOldSong
        {
            get { return _selectedOldSong; }
            set
            {
                if (_selectedOldSong == value)
                    return;
                _selectedOldSong = value;
            }
        }

        public Song SelectedNewSong
        {
            get { return _selectedNewSong; }
            set
            {
                if (_selectedNewSong == value)
                    return;
                _selectedNewSong = value;
            }
        }

        public int PlaylistUserID
        {
            get { return _playlistUserID; }
            set { _playlistUserID = value; }
        }

        public bool PlaylistForAll
        {
            get
            {
                if (PlaylistUserID == 0)
                    return true;
                return false;
            }
            set
            {
                if(PlaylistUserID == User.ID)
                {
                    PlaylistUserID = 0;
                } else
                {
                    PlaylistUserID = User.ID;
                }
                OnPropertyChanged("PlaylistForAll");
            }
        }

        public ObservableCollection<Song> CurrentSongs
        {
            get { return new ObservableCollection<Song>(Playlist.Songs); }
        }

        public ObservableCollection<Song> AllSongs
        {
            get { return _allSongs; }
            set { _allSongs = value; }
        }

        public ObservableCollection<Song> PlaceholderSongs
        {
            get { return _placeholderSongs; }
            set { _placeholderSongs = value; }
        }

        public ObservableCollection<string> Art
        {
            get { return _artSelection; }
            set { _artSelection = value; }
        }

        public ICommand AddSongToPlaylistCommand
        {
            get { return _addSongToPlaylistCommand; }
            set { _addSongToPlaylistCommand = value; }
        }

        public ICommand RemoveSongFromPlaylistCommand
        {
            get { return _removeSongFromPlaylistCommand; }
            set { _removeSongFromPlaylistCommand = value; }
        }

        public ICommand CloseEditPlaylistViewCommand
        {
            get { return _closeEditPlaylistViewCommand; }
            set { _closeEditPlaylistViewCommand = value; }
        }

        public ICommand SavePlaylistChangesCommand
        {
            get { return _savePlaylistChangesCommand; }
            set { _savePlaylistChangesCommand = value; }
        }
        #endregion
    }
}
