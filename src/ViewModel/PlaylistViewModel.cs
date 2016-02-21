using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jukebox.Data;
using Jukebox.ViewModel;
using System.Collections.ObjectModel;

namespace Jukebox
{
    public class PlaylistViewModel : ViewModelBase
    {
        private Playlist _playlist;

        public PlaylistViewModel()
        {

        }

        public PlaylistViewModel(Playlist playlist)
        {
            Playlist = playlist;
        }

        #region Properties
        public Playlist Playlist
        {
            get
            {
                return _playlist;
            }

            set
            {
                _playlist = value;
            }
        }

        public string Title
        {
            get { return Playlist.Title; }
            set { Playlist.Title = value; }
        }

        public string ID
        {
            get { return Playlist.ID.ToString(); }
            set { Playlist.ID = Convert.ToInt32(value); }
        }

        public string Image
        {
            get { return Playlist.Image; }
            set { Playlist.Image = value; }
        }

        public ObservableCollection<Song> Songs
        {
            get { return Playlist.Songs; }
            set { Playlist.Songs = value; }
        } 

        public string Track_Count
        {
            get { return Playlist.Track_Count.ToString(); }
        }
        #endregion
    }
}