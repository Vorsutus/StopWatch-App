using System;
using System.Diagnostics; //needed to use "Stopwatch"
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class SWProject : ContentPage
    {
        //Stopwatch measures elapsed time
        readonly Stopwatch stopwatch;

        public SWProject()
        {
            InitializeComponent();
            //create new instance of Stopwatch to measyure elapsed time
            stopwatch = new Stopwatch();

            //starting time on the TimeLabel
            TimeLabel.Text = "00:00:00.00";
        }

        private void Start_Clicked(object sender, EventArgs e)
        {
            //starts or resumes measuring elapsed time on Stopwatch
            stopwatch.Start();

            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                TimeLabel.Text = stopwatch.Elapsed.ToString("hh\\:mm\\:ss\\.ff");
                return true;
            }
            );
        }

        private void Stop_Clicked(object sender, EventArgs e)
        {
            stopwatch.Stop();
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            stopwatch.Reset();
        }
    }
}