using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

namespace MSIXWinFormsLIBVLC
{
    public partial class Form1 : Form
    {
        public LibVLC _libVLC;
        public MediaPlayer _mp;

        public Form1()
        {
            Core.Initialize();

            InitializeComponent();
            var videoView = new VideoView();

            Controls.Add(videoView);

            videoView.Dock = DockStyle.Fill;
            _libVLC = new LibVLC();
            _mp = new MediaPlayer(_libVLC) { EnableHardwareDecoding = true };
            videoView.MediaPlayer = _mp;
            Load += Form1_Load;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mp.Stop();
            _mp.Dispose();
            _libVLC.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var media = new Media(_libVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
            _mp.Play(media);
            media.Dispose();
        }
    }
}