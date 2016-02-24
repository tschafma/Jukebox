using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jukebox
{
    public class User
    {
        private string _username;
        private int _credits;
        private bool _isAdmin;
        private int _id;

        public User()
        {
            _username = "Guest";
            _credits = 0;
            _isAdmin = false;
            _id = -1;
        }

        public User(string username, int credits, bool isAdmin, int id)
        {
            _username = username;
            _credits = credits;
            _isAdmin = isAdmin;
            _id = id;
        }

        #region Properties
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public int Credits
        {
            get
            {
                return _credits;
            }

            set
            {
                _credits = value;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return _isAdmin;
            }

            set
            {
                _isAdmin = value;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        } 
        #endregion
    }
}