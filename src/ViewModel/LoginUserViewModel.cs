using Jukebox.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Jukebox.ViewModel
{
    public class LoginUserViewModel : ViewModelBase
    {
        private string _username;

        private UserRepository _userRepo;

        private ICommand _loginUser;
        private ICommand _closeLoginView;

        public LoginUserViewModel()
        {
            CloseLoginView = new RelayCommand(new Action<object>(CloseLoginViewMessage));
            LoginUser = new RelayCommand(new Action<object>(LoginUserMessage), Predicate => { if (Username == null || Username == "") { return false; } else { return true; } });
        }

        private void LoginUserMessage(object obj)
        {
            var password = ((System.Windows.Controls.PasswordBox)obj).Password;
            _userRepo = new UserRepository();
            User user = _userRepo.GetUser(Username, password);
            if(user != null)
            {
                // MainViewModel should lisent to this
                Messenger.Default.Send<User>(user, "UserLogin");
            }
            Messenger.Default.Send<bool>(true, "CloseLoginView");
        }

        private void CloseLoginViewMessage(object obj)
        {
            Messenger.Default.Send<bool>(true, "CloseLoginView");
        }

        #region Properties
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public ICommand LoginUser
        {
            get { return _loginUser; }
            set { _loginUser = value; }
        }

        public ICommand CloseLoginView
        {
            get { return _closeLoginView; }
            set { _closeLoginView = value; }
        }
        #endregion
    }
}
