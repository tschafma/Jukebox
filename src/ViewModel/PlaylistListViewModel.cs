using Jukebox.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Jukebox
{
    public class PlaylistListViewModel : ViewModel.ViewModelBase
    {
        private ObservableCollection<Playlist> _playlists;
        private PlaylistRepository _playlistRepository;
        private Playlist _selectedItem;

        private User _user;

        #region Constructors
        public PlaylistListViewModel()
        {
            _playlistRepository = new PlaylistRepository();
            _playlists = new ObservableCollection<Playlist>(_playlistRepository.GetStoredPlaylists());
            _playlistRepository.Dispose();
        }

        public PlaylistListViewModel(PlaylistRepository repo)
        {
            _playlistRepository = repo;
            _playlists = new ObservableCollection<Playlist>(_playlistRepository.GetStoredPlaylists());
            _playlistRepository.Dispose();

            // Listens for main view model, if a playlist is successfully added to database
            Messenger.Default.Register<bool>(this, UpdatePlaylistList, "UpdatePlaylistListView");
        } 
        #endregion

        private void UpdatePlaylistList(bool truth)
        {
            if (truth)
            {
                //_playlistRepository.Dispose();
                _playlistRepository.StoreAllPlaylists();
                if (User != null)
                    _playlistRepository.StoreUserPlaylists(User.ID);
                Playlists = new ObservableCollection<Playlist>(_playlistRepository.GetStoredPlaylists());
                _playlistRepository.Dispose();
                OnPropertyChanged("Playlists");
            }
        }

        protected override void OnDispose()
        {
            _playlists.Clear();
        }

        protected override void OnRefresh()
        {
            UpdatePlaylistList(true);
        }

        #region Commands

        #endregion

        #region Properties
        public ObservableCollection<Playlist> Playlists
        {
            get
            {
                return _playlists;
            }

            set
            {
                _playlists = value;
            }
        }

        public string PlaylistCount
        {
            get
            {
                return _playlists.Count.ToString();
            }
        } 

        public Playlist SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value == _selectedItem)
                    return;

                _selectedItem = (Playlist)value;

                // SongListViewModel.cs listens for this
                if(_selectedItem != null)
                    Messenger.Default.Send<Playlist>(_selectedItem, "PlaylistSelected");
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                if (_user == value)
                {
                    return;
                }
                _user = value;
                UpdatePlaylistList(true);
                OnPropertyChanged("User");
            }
        }
        #endregion
    }
}