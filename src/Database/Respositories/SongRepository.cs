using Jukebox.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Jukebox
{
    public class SongRepository : BaseRepository
    {
        private List<Song> _songs;

        public SongRepository()
        {
            _songs = new List<Song>();
        }

        public SongRepository(int playlistid)
        {
            connection = new SqlConnection(connectionString);
            _songs = LoadSongs(connection, playlistid);
        }

        private List<Song> LoadSongs(SqlConnection connection, int playlistid = 0)
        {
            if(connection == null)
                connection = new SqlConnection(connectionString);

            bool existsPlaylistid = false;
            string query;

            if (playlistid != 0 && playlistid != 1)
            {
                query = "SELECT * FROM [dbo].[Songs] s LEFT JOIN [dbo].[Songs_For_Playlist] spl ON s.Song_ID=spl.Song_ID WHERE spl.Playlist_ID=@playlistid";
                existsPlaylistid = true;
            }
            else
            {
                query = "SELECT * FROM [dbo].[Songs]";
            }

            List<Song> _songsToAdd = new List<Song>();
            using(SqlCommand cmd = new SqlCommand(query, connection))
            {
                if(existsPlaylistid)
                    cmd.Parameters.AddWithValue("@playlistid", playlistid);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _songsToAdd.Add(new Song(
                        Convert.ToInt32(reader["Song_ID"]),
                        reader["Song_Title"].ToString(),
                        reader["Song_Duration"].ToString(),
                        reader["Song_Artist"].ToString(),
                        reader["Song_Image"].ToString(),
                        reader["Song_Path"].ToString(),
                        null
                    ));
                }
                connection.Close();
            }
            return _songsToAdd;
        }

        private Song RetrieveSpecificSong(SqlConnection connection, Song song)
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);

            Song newSong = new Song();

            using(SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Songs] WHERE Song_ID=@songid", connection))
            {
                cmd.Parameters.AddWithValue("@songid", song.ID);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        newSong.ID = Convert.ToInt32(reader["Song_ID"]);
                        newSong.Title = reader["Song_Title"].ToString();
                        newSong.Artist = reader["Song_Artist"].ToString();
                        newSong.Duration = reader["Song_Duration"].ToString();
                        newSong.Image = reader["Song_Image"].ToString();
                        newSong.Path = reader["Song_Path"].ToString();
                        newSong.ParentPlaylist = song.ParentPlaylist;
                    }
                }
                else
                {
                    newSong = null;
                }
            }
            return newSong;
        }

        private Song AddSong(SqlConnection connection, Song song)
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);

            using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Songs] OUTPUT INSERTED.Song_ID VALUES (@title, @artist, @path, @duration, @image)", connection))
            {
                cmd.Parameters.AddWithValue("@title", song.Title);
                cmd.Parameters.AddWithValue("@artist", song.Artist);
                cmd.Parameters.AddWithValue("@path", song.Path);
                cmd.Parameters.AddWithValue("@duration", song.Duration);
                cmd.Parameters.AddWithValue("@image", song.Image);

                connection.Open();
                int newid = (int)cmd.ExecuteScalar();
                song.ID = newid;
                connection.Close();
            }

            return song;
        }

        private void UpdateSong(SqlConnection connection, Song song)
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);

            using (SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Songs] SET Song_Title=@title, Song_Artist=@artist, Song_Duration=@duration, Song_Image=@image WHERE Song_ID=@songid", connection))
            {
                cmd.Parameters.AddWithValue("@title", song.Title);
                cmd.Parameters.AddWithValue("@artist", song.Artist);
                cmd.Parameters.AddWithValue("@duration", song.Duration);
                cmd.Parameters.AddWithValue("@image", song.Image);
                cmd.Parameters.AddWithValue("@songid", song.ID);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void DeleteSongFromDB(SqlConnection connection, Song song)
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);

            using(SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Songs] WHERE Song_ID=@songid", connection))
            {
                cmd.Parameters.AddWithValue("@songid", song.ID);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            using (SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Songs_For_Playlist] WHERE Song_ID=@songid", connection))
            {
                cmd.Parameters.AddWithValue("@songid", song.ID);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Public interface for selecting songs from a particular Playlist (by ID)
        /// </summary>
        /// <param name="playlistid">Integer ID must match the Playlist's ID in the Database</param>
        /// <returns></returns>
        public List<Song> GetSongsFromPlaylist(int playlistid)
        {
            List<Song> _songsToAdd = LoadSongs(connection, playlistid);
            return _songsToAdd;
        }

        public List<Song> GetAllSongs()
        {
            List<Song> _songsToAdd = LoadSongs(connection);
            return _songsToAdd;
        }

        public Song GetSong(Song song)
        {
            return RetrieveSpecificSong(connection, song);
        }

        /// <summary>
        /// Get all songs currently stored in the Repository
        /// </summary>
        /// <returns>List of current songs in Repository</returns>
        public List<Song> GetSongs()
        {
            return new List<Song>(_songs);
        }

        public Song SaveNewSong(Song song)
        {
            return AddSong(connection, song);
        }

        public void SaveSong(Song song)
        {
            UpdateSong(connection, song);
        }

        public void DeleteSong(Song song)
        {
            DeleteSongFromDB(connection, song);
        }

        protected override void OnDispose()
        {
            _songs.Clear();
        }
    }
}