using Jukebox.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Jukebox
{
    abstract public class Album
    {
        protected string _title;
        protected ObservableCollection<Song> _songs;
        protected string _image;
    }
}