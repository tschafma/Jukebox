using Jukebox.Data;
using Jukebox.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Jukebox.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        PlaylistRepository _playlistRepository;
        SongRepository _songRepository;
        UserRepository _userRepo;

        ObservableCollection<ViewModelBase> _viewModels;
        User _user;

        PlaylistListViewModel _playlistListViewModel;
        SongListViewModel _songListViewModel;
        SongViewModel _songViewModel;
        MenuViewModel _menuViewModel;
        ViewModelBase _variableViewModel;

        public MainViewModel()
        {
            _viewModels = new ObservableCollection<ViewModelBase>();
            _playlistRepository = new PlaylistRepository();
            _songRepository = new SongRepository();
            _userRepo = new UserRepository();
            _playlistListViewModel = new PlaylistListViewModel(_playlistRepository);
            _songListViewModel = new SongListViewModel(_songRepository);
            _songViewModel = new SongViewModel();
            _menuViewModel = new MenuViewModel();

            _viewModels.Add(_playlistListViewModel);
            _viewModels.Add(_songListViewModel);
            _viewModels.Add(_songViewModel);
            _viewModels.Add(_menuViewModel);

            // Listens for a click in menuViewModel
            Messenger.Default.Register<bool>(this, SetCreatePlaylistViewModel, "CreatePlaylistView");
            Messenger.Default.Register<bool>(this, CloseCreatePlaylistView, "CloseCreatePlaylistView");

            // Listens for click in menuViewModel
            Messenger.Default.Register<bool>(this, SetLoginViewModel, "CreateLoginView");
            // Listens for LoginUserViewModel to send this message
            Messenger.Default.Register<bool>(this, CloseLoginViewModel, "CloseLoginView");
            // Listens for menuViewModel logout button click
            Messenger.Default.Register<bool>(this, LogoutUser, "LogoutUser");

            // Listens for register button click in MenuViewModel
            Messenger.Default.Register<bool>(this, SetRegisterViewModel, "CreateRegisterView");
            Messenger.Default.Register<bool>(this, CloseRegisterViewModel, "CloseRegisterView");

            // Listens for menuviewModel AddNewSong button click
            Messenger.Default.Register<bool>(this, SetAddNewSongViewModel, "CreateAddNewSongView");
            Messenger.Default.Register<bool>(this, CloseAddNewSongViewModel, "CloseAddNewSongView");

            // Listenes for menuviewModel EditPlaylist button click
            Messenger.Default.Register<Playlist>(this, SetEditPlaylistViewModel, "CreateEditPlaylistView");
            Messenger.Default.Register<bool>(this, CloseEditPlaylistView, "CloseEditPlaylistView");

            // listens for menuviewmodel Edit Song button click
            Messenger.Default.Register<Song>(this, SetEditSongViewModel, "CreateEditSongView");
            Messenger.Default.Register<bool>(this, CloseEditSongView, "CloseEditSongView");

            // Listenes for menuvireModel Credits button
            Messenger.Default.Register<bool>(this, SetCreditTransactionViewModel, "CreateCreditTransactionView");
            Messenger.Default.Register<bool>(this, CloseCreditTransactionView, "CloseCreditTransactionView");

            // Listens for LoginViewModel successful login, or a RegisterViewModel sucessful registration
            Messenger.Default.Register<User>(this, LoginUser,"UserLogin");

            // Listens for when song is selected, changed, etc
            Messenger.Default.Register<bool>(this, UserPlayedSong, "UserCreditCheck");

            // Listens from MenuViewModel for delete commands
            Messenger.Default.Register<Playlist>(this, DeletePlaylist, "DeletePlaylist");
            Messenger.Default.Register<Song>(this, DeleteSong, "DeleteSong");

            User = new User();
        }

        private void LoginUser(User user)
        {
            User = user;
            UpdateViewModelsUser(user);
        }

        private void LogoutUser(bool truth)
        {
            User = new User();
            UpdateViewModelsUser(User);
            VariableViewModel = null;
        }

        private void UpdateViewModelsUser(User user)
        {
            foreach(ViewModelBase vm in ViewModels)
            {
                var type = vm.GetType();
                type.GetProperty("User").SetValue(vm, user);
            }
        }

        private void RefreshViewModels()
        {
            foreach(ViewModelBase vm in ViewModels)
            {
                vm.Refresh();
            }
        }

        private void UserPlayedSong(bool truth)
        {
            if (User.Credits > 0)
                User.Credits--;
            if (User.ID > 0)
                _userRepo.SaveUser(User);
            User = User;
        }

        private void DeletePlaylist(Playlist playlist)
        {
            _playlistRepository.DeletePlaylist(playlist);
            RefreshViewModels();
        }

        private void DeleteSong(Song song)
        {
            _songRepository.DeleteSong(song);
            RefreshViewModels();
        }

        private void CloseVariableViewModel()
        {
            VariableViewModel = null;
            RefreshViewModels();
        }

        #region LoginViewModelMethods
        private void SetLoginViewModel(bool truth)
        {
            VariableViewModel = new LoginUserViewModel();
            //OnPropertyChanged("VariableViewModel");
        }

        private void CloseLoginViewModel(bool truth)
        {
            VariableViewModel = null;
        } 
        #endregion

        #region CreatePlaylistViewMethods
        private void SetCreatePlaylistViewModel(bool truth)
        {
            if (truth)
            {
                VariableViewModel = new CreatePlaylistViewModel(User);
                //OnPropertyChanged("VariableViewModel");
            }
        }

        private void CloseCreatePlaylistView(bool truth)
        {
            VariableViewModel = null;
            if (truth)
            {
                // PlaylistListViewModel listens for this
                Messenger.Default.Send<bool>(true, "UpdatePlaylistListView");
            }
        }
        #endregion

        #region RegisterViewMethods
        private void SetRegisterViewModel(bool truth)
        {
            VariableViewModel = new RegisterViewModel();
        }

        private void CloseRegisterViewModel(bool truth)
        {
            VariableViewModel = null;
        }
        #endregion

        #region AddSongViewMethods
        private void SetAddNewSongViewModel(bool truth)
        {
            VariableViewModel = new AddSongViewModel();
        }

        private void CloseAddNewSongViewModel(bool truth)
        {
            VariableViewModel = null;
            //RefreshViewModels();
        }
        #endregion

        #region EditPlaylistViewMethods
        private void SetEditPlaylistViewModel(Playlist playlist)
        {
            VariableViewModel = new EditPlaylistViewModel(playlist, User);
        }

        private void CloseEditPlaylistView(bool truth)
        {
            VariableViewModel = null;
            //RefreshViewModels();
        }
        #endregion

        #region EditSongViewMethods
        private void SetEditSongViewModel(Song song)
        {
            VariableViewModel = new EditSongViewModel(song);
        }

        private void CloseEditSongView(bool truth)
        {
            VariableViewModel = null;
            //RefreshViewModels();
        }
        #endregion

        #region CreditsMethods
        private void SetCreditTransactionViewModel(bool truth)
        {
            VariableViewModel = new CreditTransactionViewModel(User);
        }

        private void CloseCreditTransactionView(bool truth)
        {
            VariableViewModel = null;
            if (truth)
            {
                UpdateViewModelsUser(User);
            }
        } 
        #endregion

        #region Properties
        public ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                if (_viewModels == null)
                {
                    _viewModels = new ObservableCollection<ViewModelBase>();
                }
                return _viewModels;
            }
        }

        public PlaylistListViewModel PlaylistListViewModel
        {
            get { return _playlistListViewModel; }
        }

        public SongListViewModel SongListViewModel
        {
            get { return _songListViewModel; }
        }

        public SongViewModel SongViewModel
        {
            get { return _songViewModel; }
        }

        public MenuViewModel MenuViewModel
        {
            get { return _menuViewModel; }
        }

        public ViewModelBase VariableViewModel
        {
            get { return _variableViewModel; }
            set { _variableViewModel = value; OnPropertyChanged("VariableViewModel"); }
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
                UpdateViewModelsUser(value);
                OnPropertyChanged("User");
                // In SongListViewModel
                Messenger.Default.Send<bool>(true, "NoCredits");
            }
        } 
        #endregion
    }
}
