using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jukebox.Data
{
    public class Song
    {
        private string _title;
        private string _duration;
        private string _artist;
        private string _path;
        private string _image;
        private int _id;

        private bool _isSelected;

        private Playlist _parentPlaylist;

        #region Constructors
        public Song(string title)
        {
            _title = title;
            _duration = "00:00";
            _artist = "Unknown";
            _path = "Unknown";
            _id = 0;
        }

        public Song(string title, string artist)
        {
            _title = title;
            _duration = "00:00";
            _artist = artist;
            _path = "Unknown";
            _id = 0;
        }

        public Song()
        {
            _title = "Unknown";
            _duration = "00:00";
            _artist = "Unknown";
            _image = "Unknown";
            _path = "Unknown";
            _id = 0;
        }

        public Song(int id, string title, string duratiion, string artist, string image, string path, Playlist parentPlaylist)
        {
            _id = id;
            _title = title;
            _duration = duratiion;
            _artist = artist;
            _image = image;
            _path = path;
            _parentPlaylist = parentPlaylist;
        }
        #endregion

        #region Properties
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

        public string Duration
        {
            get
            {
                return _duration;
            }

            set
            {
                _duration = value;
            }
        }

        public string Artist
        {
            get
            {
                return _artist;
            }

            set
            {
                _artist = value;
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

        public string Path
        {
            get
            {
                return _path;
            }

            set
            {
                _path = value;
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

        public Playlist ParentPlaylist
        {
            get
            {
                return _parentPlaylist;
            }
            set
            {
                _parentPlaylist = value;
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }
        #endregion
    }
}
