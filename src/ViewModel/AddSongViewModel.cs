using Jukebox.Data;
using Jukebox.Database.Respositories;
using Jukebox.Helpers;
using Jukebox.Helpers.Validation;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Jukebox
{
    public class AddSongViewModel : ViewModel.ViewModelBase
    {
        private string _title;
        private string _duration;
        private string _artist;
        private string _path;
        private string _selectedImage;

        private ICommand _addNewSongCommand;
        private ICommand _closeAddSongViewCommand;
        private ICommand _browseSongCommand;

        private ObservableCollection<string> _artCollection;

        private string _filter = "Audio files (*.wav;*.mp3;*.mp4;*.m4a)|*.wav;*.mp3;*.mp4;*.m4a";

        ArtRepository _artRepo;
        SongRepository _songRepo;

        public AddSongViewModel()
        {
            _artRepo = new ArtRepository();
            _artCollection = new ObservableCollection<string>(_artRepo.GetAllArt());

            _songRepo = new SongRepository();

            AddNewSongCommand = new RelayCommand(new Action<object>(AddNewSong), Predicate => {
                if(TitleRule.TitleRegex.IsMatch(Title) &&
                    TitleRule.TitleRegex.IsMatch(Artist) &&
                    DurationRule.DurationRegex.IsMatch(Duration) &&
                    RequiredRule.RequiredRegex.IsMatch(SongPath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
            CloseAddNewSongViewCommand = new RelayCommand(new Action<object>(CloseNewSongView));
            BrowseSongCommand = new RelayCommand(new Action<object>(BrowseSong));
        }

        private void AddNewSong(object obj)
        {
            Song song = new Song();
            song.Title = Title;
            song.Artist = Artist;
            song.Duration = Duration;
            song.Image = PathHelper.GetRelativePath(SelectedImage, Directory.GetCurrentDirectory() + "\\");
            song.Path = PathHelper.GetRelativePath(SongPath, Directory.GetCurrentDirectory() + "\\");

            _songRepo.SaveNewSong(song);
            CloseNewSongView();
        }

        private void CloseNewSongView(object obj = null)
        {
            Messenger.Default.Send<bool>(true, "CloseAddNewSongView");
        }

        private void BrowseSong(object obj)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = _filter;
            if(fd.ShowDialog() == true)
            {
                SongPath = fd.FileName;
                Title = fd.SafeFileName;
                OnPropertyChanged("SongPath");
                OnPropertyChanged("Title");
            }
        }

        #region Properties
        public string Title
        {
            get
            {
                if (_title == null)
                    _title = "";
                return _title;
            }
            set { _title = value; }
        }

        public string Artist
        {
            get
            {
                if (_artist == null)
                    _artist = "";
                return _artist;
            }
            set { _artist = value; }
        }

        public string Duration
        {
            get
            {
                if (_duration == null)
                    _duration = "";
                return _duration;
            }
            set { _duration = value; }
        }

        public string SongPath
        {
            get
            {
                if (_path == null)
                    _path = "";
                return _path;
            }
            set { _path = value; }
        }

        public ObservableCollection<string> ArtCollection
        {
            get { return _artCollection; }
            set { _artCollection = value; }
        }

        public string SelectedImage
        {
            get
            {
                if (_selectedImage == null)
                    return ArtCollection[0];
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

        public ICommand AddNewSongCommand
        {
            get { return _addNewSongCommand; }
            set { _addNewSongCommand = value; }
        }

        public ICommand CloseAddNewSongViewCommand
        {
            get { return _closeAddSongViewCommand; }
            set { _closeAddSongViewCommand = value; }
        }

        public ICommand BrowseSongCommand
        {
            get { return _browseSongCommand; }
            set { _browseSongCommand = value; }
        }
        #endregion
    }
}