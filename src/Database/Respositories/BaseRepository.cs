using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Jukebox
{
    public abstract class BaseRepository : IDisposable
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["JukeboxDatabase"].ConnectionString;
        protected SqlConnection connection;

        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {
            
        }
    }
}