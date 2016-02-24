using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jukebox.Database.Respositories
{
    public class ArtRepository : BaseRepository
    {
        private List<string> _artPaths;

        private string _playlistArt = "..\\..\\Media\\Images\\Playlist";
        private string _albumArt = "..\\..\\Media\\Images\\Album";
        private string _filter = "*.jpg";

        public ArtRepository()
        {
            _artPaths = new List<string>();
        }

        protected override void OnDispose()
        {
            _artPaths.Clear();
        }

        private List<string> LoadArtPaths(string path, string filter)
        {
            List<string> paths = new List<string>();
            string[] files = Directory.GetFiles(path, filter);
            for (int i = 0; i < files.Length; i++)
            {
                paths.Add(Path.GetFullPath(files[i]));
            }
            return paths;
        }

        #region Public Methods
        public List<string> GetPlaylistArt()
        {
            return LoadArtPaths(_playlistArt, _filter);
        }

        public List<string> GetAlbumArt()
        {
            return LoadArtPaths(_albumArt, _filter);
        }

        public List<string> GetAllArt()
        {
            List<string> paths = new List<string>();
            paths.InsertRange(0, GetPlaylistArt());
            paths.InsertRange(paths.Count - 1, GetAlbumArt());
            return paths;
        } 
        #endregion

        public List<string> ArtPaths
        {
            get
            {
                if (_artPaths == null)
                    _artPaths = new List<string>();
                return _artPaths;
            }
        }
    }
}
