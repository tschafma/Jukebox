using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jukebox.Data;
using Jukebox.ViewModel;
using Jukebox.Helpers;
using System.Windows.Input;
using System.IO;

namespace Jukebox
{
    public class SongViewModel : ViewModelBase
    {
        private SongRepository _songRepo;

        private Song _song;
        private User _user;
        private string _timeStamp;
        private ICommand _playMediaCommand;
        private ICommand _pauseMediaCommand;

        public SongViewModel()
        {
            _song = null;
            _songRepo = new SongRepository();
            PlayMedia = new RelayCommand(new Action<object>(SendPlayMediaMessage));

            // listens to SongListViewModel.cs
            Messenger.Default.Register<Song>(this, UpdateCurrentSong, "UpdateCurrentSong");

            // SongView Code Behind Sends this
            Messenger.Default.Register<bool>(this, IncrementSong, "PlayNextSong");
            Messenger.Default.Register<TimeSpan>(this, UpdateSongTime, "TimeSpanFound");
            Messenger.Default.Register<int>(this, IncrementTimeStamp, "IncrementDuration");
        }

        public SongViewModel(Song song)
        {
            _song = song;
        }

        private void IncrementSong(bool truth)
        {
            if(User.Credits > 0)
            {
                if(Playlist == null)
                {
                    Song = null;
                    return;
                }
                int index = Playlist.Songs.IndexOf(Song);
                if (index + 1 < Playlist.Track_Count)
                    UpdateCurrentSong(Playlist.Songs[index + 1]);
                else
                    Song = null;
            } else
            {
                Messenger.Default.Send<bool>(true, "NoCredits");
            }
        }

        private void UpdateSongTime(TimeSpan span)
        {
            TimeSpan newSpan = TimeSpan.FromSeconds((int)span.TotalSeconds);
            string totalTime = newSpan.ToString(@"mm\:ss");
            Duration = totalTime;
            
        }

        private void IncrementTimeStamp(int val)
        {
            TimeStamp = new TimeSpan(0, 0, val).ToString(@"mm\:ss");
        }

        private void UpdateCurrentSong(Song song)
        {
            if (Song == song) return;
            Song = song;
            SendPlayMediaMessage();
        }

        // Media Players should listen for this message
        // SongView.xaml.cs listens to this
        private void SendPlayMediaMessage(object obj = null)
        {
            // MainViewModel listens to this
            Messenger.Default.Send<bool>(true, "UserCreditCheck");
            Messenger.Default.Send<bool>(true, "NoCredits");
            Messenger.Default.Send<bool>(true, "PlayPauseMedia");
        }

        protected override void OnRefresh()
        {
            //Song = _songRepo.GetSong(Song);
        }

        #region Properties
        public Song Song
        {
            get
            {
                if (_song == null)
                    _song = new Song("No Song Selected", "Pick a Song to play!");
                return _song;
            }
            set
            {
                if (value == null)
                    _song = new Song("No Song Selected", "Pick a Song to play!");
                else
                    _song = value;
                OnPropertyChanged("Song");
                OnPropertyChanged("Duration");
                OnPropertyChanged("Title");
                OnPropertyChanged("Artist");
                OnPropertyChanged("Path");
                OnPropertyChanged("Image");
                OnPropertyChanged("MediaSourcePath");
                OnPropertyChanged("ID");
                OnPropertyChanged("Image");
            }
        }

        public Playlist Playlist
        {
            get
            {
                if (Song.ParentPlaylist == null)
                    return null;
                return Song.ParentPlaylist;
            }
        }

        public string Title
        {
            get
            {
                if(Song.Title == null)
                    return "";
                return _song.Title;
            }
            set { Song.Title = value; }
        }

        public string ID
        {
            get { return Song.ID.ToString(); }
            set { Song.ID = Convert.ToInt32(value); }
        }

        public string Artist
        {
            get
            {
                if (Song.Artist == null)
                    return "";
                return Song.Artist;
            }
            set { Song.Artist = value; }
        }

        public string Duration
        {
            get { return TimeStamp + " / " + Song.Duration; }
            set
            {
                if (Song.Duration != value)
                {
                    Song.Duration = value;
                    SongRepository tempRepo = new SongRepository();
                    tempRepo.SaveSong(Song);
                    tempRepo.Dispose();
                    tempRepo = null;
                }
                
                OnPropertyChanged("Duration");
            }
        }

        public string TimeStamp
        {
            get
            {
                if (_timeStamp == null)
                    _timeStamp = "00:00";
                return _timeStamp;
            }
            set
            {
                _timeStamp = value;
                OnPropertyChanged("TimeStamp");
                OnPropertyChanged("Duration");
            }
        }

        /// <summary>
        /// Path to song's location in persistent storage
        /// </summary>
        public string Path
        {
            get
            {
                if (Song.Path == null || Song.Path == "Unknown")
                    return "";
                return Song.Path;
            }
            set { Song.Path = value; }
        }

        /// <summary>
        /// Used for injecting into some type of MediaElement
        /// </summary>
        public Uri MediaSourcePath
        {
            get
            {
                if (Path == null || Path == "")
                    return null;
                Uri baseUri = new Uri(Directory.GetCurrentDirectory() + "\\");
                return new Uri(baseUri, Path);
            }
        }

        /// <summary>
        /// Song's Image Path. Will either be of the song's album art, or the art of the song's containing playlist if no album art is present
        /// </summary>
        public string Image
        {
            get
            {
                if (Song.Image == "Unknown" || Song.Image == null)
                    if (Song.ParentPlaylist != null)
                        return _song.ParentPlaylist.Image;
                    else
                        return "";
                return Song.Image;
            }
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
                OnPropertyChanged("User");
            }
        }

        public ICommand PlayMedia
        {
            get { return _playMediaCommand; }
            private set { _playMediaCommand = value; }
        }

        public ICommand PauseMedia
        {
            get { return _pauseMediaCommand; }
            private set { _pauseMediaCommand = value; }
        }
        #endregion
    }
}