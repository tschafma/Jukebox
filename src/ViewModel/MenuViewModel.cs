using Jukebox.Data;
using Jukebox.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Jukebox.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        private User _user;
        private Playlist _playlist;
        private Song _song;

        private ICommand _deletePlaylistCommand;
        private ICommand _deleteSongCommand;

        private ICommand _createPlaylistCommand;
        private ICommand _createLoginViewCommand;
        private ICommand _createRegisterViewCommand;
        private ICommand _createAddNewSongViewCommand;
        private ICommand _createEditPlaylistViewCommand;
        private ICommand _createEditSongViewCommand;
        private ICommand _createCreditTransactionViewCommand;
        private ICommand _closeLoginView_logout;

        public MenuViewModel()
        {
            DeletePlaylistCommand = new RelayCommand(new Action<object>(DeletePlaylist));
            DeleteSongCommand = new RelayCommand(new Action<object>(DeleteSong));

            CreatePlaylistViewCommand = new RelayCommand(new Action<object>(CreatePlaylistView));
            CreateLoginViewCommand = new RelayCommand(new Action<object>(CreateLoginView));
            CreateRegisterViewCommand = new RelayCommand(new Action<object>(CreateRegisterView));
            CreateAddNewSongViewCommand = new RelayCommand(new Action<object>(CreateAddNewSongView));
            CreateEditPlaylistViewCommand = new RelayCommand(new Action<object>(CreateEditPlaylistView));
            CreateEditSongViewCommand = new RelayCommand(new Action<object>(CreateEditSongView));
            CreateCreditTransactionViewCommand = new RelayCommand(new Action<object>(CreateCreditTransactionView));
            LogoutUserCommand = new RelayCommand(new Action<object>(CloseLoginView));

            Messenger.Default.Register<Playlist>(this,UpdatePlaylist,"PlaylistSelected");
            Messenger.Default.Register<Song>(this, UpdateSong, "SongSelected");
        }

        private void UpdatePlaylist(Playlist playlist)
        {
            Playlist = playlist;
        }

        private void UpdateSong(Song song)
        {
            Song = song;
        }

        private void DeletePlaylist(object obj)
        {
            // MainViewModel Listens
            Messenger.Default.Send<Playlist>(Playlist, "DeletePlaylist");
            Playlist = null;
        }

        private void DeleteSong(object obj)
        {
            // MainViewModel listens
            Messenger.Default.Send<Song>(Song, "DeleteSong");
            Song = null;
        }

        private void CreatePlaylistView(object obj)
        {
            // Listened to by MainViewModel.cs
            Messenger.Default.Send<bool>(true, "CreatePlaylistView");
        }

        private void CreateLoginView(object obj)
        {
            // Listened to by mainViewModel.cs
            Messenger.Default.Send<bool>(true, "CreateLoginView");
        }

        private void CreateRegisterView(object obj)
        {
            // Listened to by MainViewModel.cs
            Messenger.Default.Send<bool>(true, "CreateRegisterView");
        }

        private void CreateAddNewSongView(object obj)
        {
            // Listened to by MainViewModel.cs
            Messenger.Default.Send<bool>(true, "CreateAddNewSongView");
        }

        private void CreateEditPlaylistView(object obj)
        {
            if (Playlist == null)
                return;
            // Listened t by MainViewModel.cs
            Messenger.Default.Send<Playlist>(Playlist, "CreateEditPlaylistView");
        }

        private void CreateEditSongView(object obj)
        {
            if (Song == null)
                return;
            Messenger.Default.Send<Song>(Song, "CreateEditSongView");
        }

        private void CreateCreditTransactionView(object obj)
        {
            Messenger.Default.Send<bool>(true, "CreateCreditTransactionView");
        }

        private void CloseLoginView(object obj)
        {
            // MainviewModel listens
            Messenger.Default.Send<bool>(true, "LogoutUser");
        }

        #region Properties
        public User User
        {
            get
            {
                if (_user == null)
                    return null;
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged("User");
                OnPropertyChanged("IsLoggedIn");
                OnPropertyChanged("IsLoggedOut");
                OnPropertyChanged("IsAdmin");
                OnPropertyChanged("Username");
                OnPropertyChanged("Credits");
                OnPropertyChanged("IsPlaylistSelected");
                OnPropertyChanged("IsSongSelected");
                OnPropertyChanged("UserInfo");
            }
        }

        public string UserInfo
        {
            get { return Username + ": " + Credits.ToString() + " Credits"; }
        }

        public Playlist Playlist
        {
            get
            {
                return _playlist;
            }
            set
            {
                _playlist = value;
                OnPropertyChanged("IsPlaylistSelected");
            }
        }

        public Song Song
        {
            get
            {
                return _song;
            }
            set
            {
                _song = value;
                OnPropertyChanged("IsSongSelected");
            }
        }

        public string Username
        {
            get
            {
                if (User != null)
                    return User.Username;
                return "";
            }
            set
            {
                User.Username = value;
            }
        }

        public bool IsAdmin
        {
            get
            {
                if (User != null)
                    return User.IsAdmin;
                return false;
            }
        }

        public int Credits
        {
            get
            {
                if (User == null)
                    return 0;
                return User.Credits;
            }
            set
            {
                User.Credits = value;
            }
        }
 
        public bool IsLoggedIn
        {
            get
            {
                if (User != null && User.ID != -1 && User.Username != "Guest")
                    return true;
                return false;
            }
        }

        public bool IsLoggedOut
        {
            get
            {
                return !IsLoggedIn;
            }
        }

        public bool IsPlaylistSelected
        {
            get
            {
                if(Playlist != null && User != null)
                {
                    if(Playlist.UserID == User.ID || IsAdmin)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool IsSongSelected
        {
            get
            {
                if(Song != null && User != null)
                {
                    if (User.IsAdmin)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public ICommand DeletePlaylistCommand
        {
            get { return _deletePlaylistCommand; }
            set { _deletePlaylistCommand = value; }
        }

        public ICommand DeleteSongCommand
        {
            get { return _deleteSongCommand; }
            set { _deleteSongCommand = value; }
        }

        public ICommand CreatePlaylistViewCommand
        {
            get { return _createPlaylistCommand; }
            set { _createPlaylistCommand = value; }
        }

        public ICommand CreateLoginViewCommand
        {
            get { return _createLoginViewCommand; }
            set { _createLoginViewCommand = value; }
        }

        public ICommand CreateRegisterViewCommand
        {
            get { return _createRegisterViewCommand; }
            set { _createRegisterViewCommand = value; }
        }

        public ICommand CreateAddNewSongViewCommand
        {
            get { return _createAddNewSongViewCommand; }
            set { _createAddNewSongViewCommand = value; }
        }

        public ICommand CreateEditPlaylistViewCommand
        {
            get { return _createEditPlaylistViewCommand; }
            set { _createEditPlaylistViewCommand = value; }
        }

        public ICommand CreateEditSongViewCommand
        {
            get { return _createEditSongViewCommand; }
            set { _createEditSongViewCommand = value; }
        }

        public ICommand CreateCreditTransactionViewCommand
        {
            get { return _createCreditTransactionViewCommand; }
            set { _createCreditTransactionViewCommand = value; }
        }

        public ICommand LogoutUserCommand
        {
            get { return _closeLoginView_logout; }
            set { _closeLoginView_logout = value; }
        }
        #endregion
    }
}
