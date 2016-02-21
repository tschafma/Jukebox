using Jukebox.Data;
using Jukebox.Helpers;
using Jukebox.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Jukebox
{
    public class SongListViewModel : ViewModelBase
    {
        private ObservableCollection<Song> _songs;
        private SongRepository _songRepository;
        private Song _selectedItem;
        private User _user;

        private ICommand _sendMediaControlMessage;

        public SongListViewModel()
        {
            _songRepository = new SongRepository();
            _songs = new ObservableCollection<Song>();
        }

        public SongListViewModel(int playlistid)
        {
            _songRepository = new SongRepository(playlistid);
            _songs = new ObservableCollection<Song>(_songRepository.GetSongs());
        }

        public SongListViewModel(SongRepository repo)
        {
            _songRepository = repo;
            _songs = new ObservableCollection<Song>(_songRepository.GetSongs());
            _songRepository.Dispose();
            MediaControl = new RelayCommand(new Action<object>(SendMediaControlMessage));

            // Listens for PlaylistListViewModel.cs to select a playlist
            Messenger.Default.Register<Playlist>(this, UpdateSongsList, "PlaylistSelected");

            Messenger.Default.Register<bool>(this, RefreshSongList, "SongUpdated");

            Messenger.Default.Register<bool>(this, CanPlaySongUpdate, "NoCredits");
        }

        private void UpdateSongsList(Playlist obj)
        {
            Songs = new ObservableCollection<Song>(_songRepository.GetSongsFromPlaylist(obj.ID));
            ObservableCollection<Song> tempSongs = new ObservableCollection<Song>();
            foreach(Song song in Songs)
            {
                tempSongs.Add(song);
                song.ParentPlaylist = obj;
            }
            obj.Songs = tempSongs;
            ClearRepository(_songRepository);
            OnPropertyChanged("Songs");
            OnPropertyChanged("SongListTitle");
        }

        private void RefreshSongList(bool truth)
        {
            if (Songs != null && Songs.Count > 0)
                UpdateSongsList(Songs[0].ParentPlaylist);
            else
                Songs = null;
        }

        private void ClearRepository(SongRepository repo)
        {
            repo.Dispose();
        }

        private void SendMediaControlMessage(object obj)
        {
            // SongViewModel.cs listens to this now
            Messenger.Default.Send<Song>((Song)obj, "UpdateCurrentSong");

            OnPropertyChanged("CanPlaySong");
        }

        private void CanPlaySongUpdate(bool truth)
        {
            OnPropertyChanged("CanPlaySong");
        }

        protected override void OnRefresh()
        {
            RefreshSongList(true);
        }

        #region Properties
        public string SongListTitle
        {
            get
            {
                if (Songs.Count <= 0)
                    return "Playlist";
                return Songs[0].ParentPlaylist.Title;
            }
        }

        public ObservableCollection<Song> Songs
        {
            get
            {
                if (_songs == null)
                    return new ObservableCollection<Song>();
                else
                    return _songs;
            }
            set
            {
                _songs = value;
                OnPropertyChanged("Songs");
            }
        }

        /// <summary>
        /// Currently selected item in the list. This property updates when a new item is selected
        /// </summary>
        public Song SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value == _selectedItem)
                    return;

                _selectedItem = (Song)value;

                // menuViewModel looks for this
                Messenger.Default.Send<Song>(_selectedItem, "SongSelected");
            }
        }

        public User User
        {
            get
            {
                if (_user == null)
                    _user = new User();
                return _user;
            }
            set
            {
                _user = value;
                //Songs = new ObservableCollection<Song>();
                OnPropertyChanged("User");
            }
        }

        public bool CanPlaySong
        {
            get
            {
                if (User.Credits > 0)
                    return true;
                return false;
            }
        }

        // Bound to listBoxItems
        public ICommand MediaControl
        {
            get { return _sendMediaControlMessage; }
            private set { _sendMediaControlMessage = value; }
        } 
        #endregion
    }
}