using Jukebox.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Jukebox
{
    public class Playlist : Album
    {
        private int _id;
        private int _userid;

        #region Constructors
        public Playlist(string title, string image, int id, int userid)
        {
            _title = title;
            _image = image;
            _songs = new ObservableCollection<Song>();
            _id = id;
            _userid = userid;
        }

        public Playlist(string title)
        {
            _title = title;
            _image = "\\..\\..\\Media\\Images\\Playlist\\default.jpg";
            _songs = new ObservableCollection<Song>();
            _id = 0;
        }

        public Playlist(string title, ObservableCollection<Song> songs)
        {
            _title = title;
            _image = "\\..\\..\\Media\\Images\\Playlist\\default.jpg";
            _songs = songs;
            _id = 0;
        }

        public Playlist(string title, string image)
        {
            _title = title;
            _image = image;
            _songs = new ObservableCollection<Song>();
            _id = 0;
        }

        public Playlist(string title, string image, ObservableCollection<Song> songs)
        {
            _title = title;
            _image = image;
            _songs = songs;
            _id = 0;
        }

        public Playlist()
        {
            _title = "Unknown";
            _image = "\\..\\..\\Media\\Images\\Playlist\\default.jpg";
            _songs = new ObservableCollection<Song>();
            _id = 0;
        } 
        #endregion

        #region Properties
        public ObservableCollection<Song> Songs
        {
            get
            {
                return _songs;
            }

            set
            {
                _songs = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public int Track_Count
        {
            get
            {
                return Songs.Count;
            }
        }

        public string Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
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

        public int UserID
        {
            get
            {
                return _userid;
            }
            set
            {
                _userid = value;
            }
        }

        public string IsUserPlaylist
        {
            get
            {
                if (UserID != 0)
                    return "Black";
                return "Black";
            }
        }
        #endregion
    }
}