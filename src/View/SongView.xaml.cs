using Jukebox.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Jukebox.View
{
    /// <summary>
    /// Interaction logic for SongView.xaml
    /// </summary>
    public partial class SongView : UserControl
    {
        private DispatcherTimer _timer;

        public SongView()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0,0,1);
            _timer.Tick += _timer_Tick;
            Messenger.Default.Register<bool>(this, ControlMedia, "PlayPauseMedia");
        }

        private void ControlMedia(bool play)
        {
            if (play)
            {
                _timer.Start();
                this.MediaPlayer.Play();
            }
            else
            {
                this.MediaPlayer.Pause();
            }
        }

        private void MediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            DurationSlider.Value = 0;
            Messenger.Default.Send<bool>(true, "PlayNextSong");
        }

        private void MediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (MediaPlayer.NaturalDuration.HasTimeSpan)
            {
                double seconds = MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                TimeSpan span = new TimeSpan(0, 0, (int)seconds);
                DurationSlider.Value = 0;
                DurationSlider.Maximum = (int)span.TotalSeconds;
                Messenger.Default.Send<TimeSpan>(span, "TimeSpanFound");
            }
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            DurationSlider.Value += 1;
            Messenger.Default.Send<int>((int)DurationSlider.Value, "IncrementDuration");
        }
    }
}
