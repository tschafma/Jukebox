using Jukebox.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Jukebox
{
    public class PlaylistRepository : BaseRepository
    {
        private List<Playlist> _playlists;

        public PlaylistRepository()
        {
            connection = new SqlConnection(connectionString);
            _playlists = new List<Playlist>();
            StoreAllPlaylists();
        }

        protected override void OnDispose()
        {
            _playlists.Clear();
        }

        private List<Playlist> LoadPlaylists(SqlConnection connection, int userid = 0)
        {
            List<Playlist> _listToAdd = new List<Playlist>();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Playlists] WHERE User_ID=@userid", connection))
            {
                cmd.Parameters.AddWithValue("@userid", userid);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _listToAdd.Add(new Playlist(
                        reader["Playlist_Title"].ToString(),
                        reader["Playlist_Image"].ToString(),
                        Convert.ToInt32(reader["Playlist_ID"]),
                        Convert.ToInt32(reader["User_ID"])
                    ));
                }
                connection.Close();
            }
            return _listToAdd;
        }

        #region Public Methods
        public List<Playlist> GetStoredPlaylists()
        {
            return new List<Playlist>(_playlists);
        }

        public void StoreAllPlaylists()
        {
            _playlists.AddRange(LoadPlaylists(connection));
        }

        public void StoreUserPlaylists(int userid)
        {
            _playlists.AddRange(LoadPlaylists(connection, userid));
        }

        public void SavePlaylist(Playlist playlist)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Playlists] SET Playlist_Title=@title, Playlist_Image=@image, User_ID=@userid WHERE Playlist_ID = @playlistid", connection))
            {
                cmd.Parameters.AddWithValue("@title", playlist.Title);
                cmd.Parameters.AddWithValue("@image", playlist.Image);
                cmd.Parameters.AddWithValue("@userid", playlist.UserID);
                cmd.Parameters.AddWithValue("@playlistid", playlist.ID);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            using (SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Songs_For_Playlist] WHERE Playlist_ID=@playlistid", connection))
            {
                cmd.Parameters.AddWithValue("@playlistid", playlist.ID);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Songs_For_Playlist] VALUES (@songid, @playlistid)", connection))
            {
                for (int i = 0; i < playlist.Track_Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@playlistid", playlist.ID);
                    cmd.Parameters.AddWithValue("@songid", playlist.Songs[i].ID);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void AddNewPlaylist(Playlist playlist, int userid = 0)
        {
            int newid = 0;
            using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Playlists] OUTPUT INSERTED.Playlist_ID VALUES (@title, @image, @userid)", connection))
            {
                cmd.Parameters.AddWithValue("@title", playlist.Title);
                cmd.Parameters.AddWithValue("@image", playlist.Image);
                cmd.Parameters.AddWithValue("@userid", userid);
                connection.Open();
                newid = (int)cmd.ExecuteScalar();
                connection.Close();
                playlist.ID = newid;
            }

            foreach (Song song in playlist.Songs)
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Songs_For_Playlist] VALUES (@songid, @playlistid)", connection))
                {
                    cmd.Parameters.AddWithValue("@songid", song.ID);
                    cmd.Parameters.AddWithValue("@playlistid", playlist.ID);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeletePlaylist(Playlist playlist)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Playlists] WHERE Playlist_ID=@playlistid", connection))
            {
                cmd.Parameters.AddWithValue("@playlistid", playlist.ID);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            using (SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Songs_For_Playlist] WHERE Playlist_ID=@playlistid", connection))
            {
                cmd.Parameters.AddWithValue("@playlistid", playlist.ID);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        } 
        #endregion

    }
}