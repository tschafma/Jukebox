using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jukebox.ViewModel;

namespace Jukebox
{
    public class UserViewModel : ViewModelBase
    {
        private User _user;

        public UserViewModel()
        {

        }

        public UserViewModel(User user)
        {
            _user = user;
        }

        #region Properties
        public User User
        {
            get
            {
                return _user;
            }

            set
            {
            }
        }

        public string Credits
        {
            get
            {
                return _user.Credits.ToString();
            }

            set
            {
                _user.Credits = Convert.ToInt32(value);
            }
        }

        public string ID
        {
            get
            {
                return _user.ID.ToString();
            }

            set
            {
                _user.ID = Convert.ToInt32(value);
            }
        }

        public bool isAdmin
        {
            get
            {
                return _user.IsAdmin;
            }

            set
            {
                _user.IsAdmin = value;
            }
        }

        public string Username
        {
            get
            {
                return _user.Username;
            }

            set
            {
                _user.Username = value;
            }
        } 
        #endregion
    }
}