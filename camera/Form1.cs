using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace camera
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FilterInfoCollection fil;
        VideoCaptureDevice vid;
        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            vid = new VideoCaptureDevice(fil[carCam.selectedIndex].MonikerString);
            vid.NewFrame += vid_NewFrame;
            vid.Start();
        }

        void vid_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pic.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fil = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in fil)
                carCam.AddItem(filterInfo.Name);
            carCam.selectedIndex = 0;
            vid = new VideoCaptureDevice();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (vid.IsRunning == true)
                vid.Stop();
        }
    }
}
