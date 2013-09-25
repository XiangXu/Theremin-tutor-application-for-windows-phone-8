using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Windows.Threading;
using Microsoft.Xna.Framework;
using DSP;
using WPScadaControlsV2;
using Microsoft.Phone.Shell;

namespace Theremin
{
    public partial class MainPage : PhoneApplicationPage
    {
        Microphone microphone = Microphone.Default;
        byte[] buffer;
        MemoryStream stream = new MemoryStream();
        private int minimumThreshold = 500;
        double value;

        public MainPage()
        {
            InitializeComponent();

            //Prevent application from being lock screen
            PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
            phoneAppService.UserIdleDetectionMode = IdleDetectionMode.Disabled;

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(50);
            dt.Tick += delegate { try { FrameworkDispatcher.Update(); } catch { } };
            dt.Start();
            microphone.BufferReady += new EventHandler<EventArgs>(microphone_BufferReady);
            ApplicationTitle.Text = "Theremin Tutor";
        }

        void microphone_BufferReady(object sender, EventArgs e)
        {
            if (buffer.Length <= 0) return;

            // Retrieve audio data
            microphone.GetData(buffer);

            //find the biggest value in spectrum array.

            double[] sampleBuffer = new double[DSP.Utilities.NextPowerOfTwo((uint)buffer.Length)];

            int index = 0;

            for (int i = 0; i < 2048; i += 2)
            {
                sampleBuffer[index] = Convert.ToDouble(BitConverter.ToInt16((byte[])buffer, i)); index++;
            }

            double[] spectrum = DSP.FourierTransform.Spectrum(ref sampleBuffer);

            double max = 0;
            index = 0;
            for (int i = 1; i < spectrum.Length; i++)
            {
                if (spectrum[i] > max)
                {
                    max = spectrum[i];
                    index = i;
                }
            }

            //find the closest frequency
            double interval = 8000.0 / spectrum.Length;
            double frequency = interval * index;

            double[] midiHz = MusicalNotes.Notes();
            double[] myNotes = new double[100];
            for (int i = 12; i <= 111; i++)
            {
                myNotes[i - 12] = midiHz[i];
            }
            double t = Math.Abs(myNotes[0] - frequency);
            index = 0;
            for (int i = 1; i < myNotes.Length; i++)
            {
                double temp = Math.Abs(myNotes[i] - frequency);
                if (temp < t)
                {
                    t = temp;
                    index = i;
                }
            }

            //set the value to scale
            scale.Minimum = 0;
            scale.Maximum = 2000;
            if (value > 2000)
            {
                value = 2000;
            }
            needle.Value = frequency;

            string[] notes = new string[]{"C0", "C#0/Db0", "D0", "D#0/Eb0", "E0", "F0", "F#0/Gb0", "G0", "G#0/Ab0", "A0",
                                                              "A#0/Bb0", "B0", "C1", "C#1/Db1", "D1", "D#1/Eb1", "E1", "F1", "F#1/Gb1", "G1",
                                                              "G#1/Ab1", "A1", "A#1/Bb1", "B1", "C2", "C#2/Db2", "D2", "D#2/Eb2", "E2", "F2",
                                                              "F#2/Gb2", "G2", "G#2/Ab2", "A2", "A#2/Bb2", "B2", "C3", "C#3/Db3", "D3", "D#3/Eb3",
                                                              "E3", "F3", "F#3/Gb3", "G3", "G#3/Ab3", "A3", "A#3/Bb3", "B3", "C4", "C#4/Db4",
                                                              "D4", "D#4/Eb4", "E4", "F4", "F#4/Gb4", "G4", "G#4/Ab4", "A4", "A#4/Bb4", "B4",
                                                              "C5", "C#5/Db5", "D5", "D#5/Eb5", "E5", "F5", "F#5/Gb5", "G5", "G#5/Ab5", "A5",
                                                              "A#5/Bb5", "B5", "C6", "C#6/Db6", "D6", "D#6/Eb6", "E6", "F6", "F#6/Gb6", "G6",
                                                              "G#6/Ab6", "A6", "A#6/Bb6", "B6", "C7", "C#7/Db7", "D7", "D#7/Eb7", "E7", "F7",
                                                              "F#7/Gb7", "G7", "G#7/Ab7", "A7", "A#7/Bb7", "B7", "C8", "C#8/Db8", "D8", "D#8/Eb8"};
            Notes.Text = notes[index];
            CurrentFrequency.Text = frequency.ToString();
            stream.Write(buffer, 0, buffer.Length);
        }

        private void Record_Click_Click(object sender, RoutedEventArgs e)
        {
            if (microphone.State == MicrophoneState.Stopped)
            {
                microphone.BufferDuration = TimeSpan.FromMilliseconds(1000);
                buffer = new byte[microphone.GetSampleSizeInBytes(microphone.BufferDuration)];
                microphone.Start();
                System.Diagnostics.Debug.WriteLine("Threshold setted to:" + minimumThreshold);
            }
        }

        private void Stop_Click_Click(object sender, RoutedEventArgs e)
        {
            if (microphone.State == MicrophoneState.Started)
            {
                microphone.Stop();
            }
        }
    }
}