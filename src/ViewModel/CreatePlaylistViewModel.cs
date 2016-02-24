using Jukebox.Data;
using Jukebox.Database.Respositories;
using Jukebox.Helpers;
using Jukebox.Helpers.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Jukebox.ViewModel
{
    public class CreatePlaylistViewModel : ViewModelBase
    {
        private SongRepository _songRepo;
        private ArtRepository _artRepo;

        private string _newPlaylistName;
        private ObservableCollection<Song> _songSelection;
        private ObservableCollection<string> _artSelection;
        private bool _playlistForAll;
        private string _selectedImage;
        private User _user;

        private ICommand _createNewPlaylistCommand;
        private ICommand _closeCreatePlaylistViewCommand;

        public CreatePlaylistViewModel(User user = null)
        {
            User = user;

            _songRepo = new SongRepository();
            _artRepo = new ArtRepository();
            _songSelection = new ObservableCollection<Song>(_songRepo.GetAllSongs());
            _artSelection = new ObservableCollection<string>(_artRepo.GetPlaylistArt());
            _songRepo.Dispose();

            CreateNewPlaylistCommand = new RelayCommand(new Action<object>(CreatePlaylist), Predicate => {
                if (TitleRule.TitleRegex.IsMatch(Name))
                {
                    return true;
                } else
                {
                    return false;
                }
            });

            CloseCreatePlaylistViewCommand = new RelayCommand(new Action<object>(CloseCreatePlaylistView));
        }

        private void CreatePlaylist(Object obj)
        {
            PlaylistRepository tempRepo = new PlaylistRepository();
            tempRepo.Dispose();

            ObservableCollection<Song> tempSongs = new ObservableCollection<Song>(SelectedSongs);
            Playlist newPlaylist = new Playlist();
            newPlaylist.Title = Name;
            newPlaylist.Image = PathHelper.GetRelativePath(SelectedImage, Directory.GetCurrentDirectory() + "\\");
            newPlaylist.Songs = tempSongs;
            newPlaylist.UserID = PlaylistForAll ? 0 : User.ID;

            tempRepo.AddNewPlaylist(newPlaylist, newPlaylist.UserID);

            //Listened to by mainviewmodel
            Messenger.Default.Send<bool>(true, "CloseCreatePlaylistView");
        }

        private void CloseCreatePlaylistView(object obj)
        {
            //Listened to by main view model
            Messenger.Default.Send<bool>(false, "CloseCreatePlaylistView");
        }

        #region Properties
        public string Name
        {
            get
            {
                if (_newPlaylistName == null)
                    return "";
                return _newPlaylistName;
            }
            set
            {
                _newPlaylistName = value;
            }
        }

        public ObservableCollection<Song> Songs
        {
            get
            {
                if (_songSelection == null)
                    return new ObservableCollection<Song>();
                return _songSelection;
            }
            set
            {
                _songSelection = value;
            }
        }

        public ObservableCollection<string> Art
        {
            get
            {
                if (_artSelection == null)
                    return new ObservableCollection<string>();
                return _artSelection;
            }
            set
            {
                _artSelection = value;
            }
        }

        public bool PlaylistForAll
        {
            get
            {
                return _playlistForAll;
            }
            set
            {
                _playlistForAll = value;
            }
        }

        public string SelectedImage
        {
            get
            {
                if (_selectedImage == null)
                    _selectedImage = Art[0];
                return _selectedImage;
            }
            set
            {
                if (_selectedImage == value)
                    return;
                _selectedImage = value;
                OnPropertyChanged("SelectedImage");
            }
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

        public IEnumerable<Song> SelectedSongs
        {
            get
            {
                return Songs.Where(s => s.IsSelected);
            }
        }

        public ICommand CreateNewPlaylistCommand
        {
            get { return _createNewPlaylistCommand; }
            set { _createNewPlaylistCommand = value; }
        }

        public ICommand CloseCreatePlaylistViewCommand
        {
            get { return _closeCreatePlaylistViewCommand; }
            set { _closeCreatePlaylistViewCommand = value; }
        }
        #endregion
    }
}
