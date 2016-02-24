using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Jukebox
{
    public class UserRepository : BaseRepository
    {
        private List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
            connection = new SqlConnection(connectionString);
        }

        private User LoadUser(string username, string password)
        {
            User user = null;
            using(SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Users] WHERE User_Username=@username AND User_Password=@password", connection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                connection.Open();
                SqlDataReader reader =  cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    connection.Close();
                    return user;
                }
                reader.Read();

                user = new User(reader["User_Username"].ToString(),
                    Convert.ToInt32(reader["User_Credits"]),
                    Convert.ToBoolean(reader["User_IsAdmin"]),
                    Convert.ToInt32(reader["User_ID"]));

                connection.Close();
                return user;
            }
        }

        private User AddNewUser(User user, string password)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Users] OUTPUT INSERTED.User_ID VALUES (@username, @credits, @isAdmin, @password)", connection))
            {
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@credits", user.Credits);
                cmd.Parameters.AddWithValue("@isAdmin", (user.IsAdmin ? 1 : 0));
                cmd.Parameters.AddWithValue("@password", password);

                connection.Open();
                user.ID =  (int)cmd.ExecuteScalar();
                connection.Close();
            }

            return user;
        }

        private void UpdateUser(User user)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Users] SET User_Username=@username, User_Credits=@credits, User_IsAdmin=@isadmin WHERE User_ID=@userid", connection))
            {
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@credits", user.Credits);
                cmd.Parameters.AddWithValue("@isadmin", user.IsAdmin ? 1 : 0);
                cmd.Parameters.AddWithValue("@userid", user.ID);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        #region Public Methods
        public User GetUser(string username, string password)
        {
            User user = LoadUser(username, password);
            return user;
        }

        public User AddUser(User user, string password)
        {
            user = AddNewUser(user, password);
            return user;
        }

        public void SaveUser(User user)
        {
            UpdateUser(user);
        } 
        #endregion
    }
}