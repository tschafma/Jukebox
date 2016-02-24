using Jukebox.Helpers;
using Jukebox.Helpers.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Jukebox.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _username;

        private UserRepository _userRepo;

        private ICommand _registerNewUserCommand;
        private ICommand _closeRegisterViewCommand;

        public RegisterViewModel()
        {
            CloseRegisterViewCommand = new RelayCommand(new Action<object>(CloseRegisterView));
            RegisterNewUserCommand = new RelayCommand(new Action<object>(RegisterNewUser), Predicate => { if (Username == null || Username == "" || Username.Length < 6 || !UsernameRule.UsernameRegex.IsMatch(Username)) { return false; } else { return true; } });
            _userRepo = new UserRepository();
        }

        private void CloseRegisterView(object obj = null)
        {
            // MainViewModel listens to this
            Messenger.Default.Send<bool>(true, "CloseRegisterView");
        }

        /// <summary>
        /// Creates a new user, Adds them to the DB, logs them in, and closes the RegisterViewModel and RegisterView
        /// </summary>
        /// <param name="obj">Passes two Password boxes as an object[] array, which will be compared for equality</param>
        private void RegisterNewUser(object obj)
        {
            var passwordBoxes = (Object[])obj;
            var password = ((System.Windows.Controls.PasswordBox)passwordBoxes[0]).Password;
            var confirmPassword = ((System.Windows.Controls.PasswordBox)passwordBoxes[1]).Password;

            if (confirmPassword == password && password != "")
            {
                if(password.Length >= 6)
                {
                    User newUser = new User();
                    newUser.Username = Username;
                    newUser.Credits = 0;
                    newUser.IsAdmin = false;

                    newUser = _userRepo.AddUser(newUser, password);

                    Messenger.Default.Send<User>(newUser, "UserLogin");
                    CloseRegisterView();
                }
            }
        }

        #region Properties
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        public ICommand RegisterNewUserCommand
        {
            get { return _registerNewUserCommand; }
            set
            {
                _registerNewUserCommand = value;
            }
        }

        public ICommand CloseRegisterViewCommand
        {
            get { return _closeRegisterViewCommand; }
            set
            {
                _closeRegisterViewCommand = value;
            }
        } 
        #endregion
    }
}
