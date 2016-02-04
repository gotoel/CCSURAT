using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace CCSURAT_Server.ControlForms
{
    public partial class Fun : Form
    {
        private Zombie zombie;
        public Fun(Zombie zombie)
        {
            InitializeComponent();
            this.zombie = zombie;
            this.Text = zombie.IP + " - " + zombie.computerName + " - Fun Manager";
        }

        private void PlayNote(int frequency, int duration)
        {
            if(serverSideAudio.Checked)
                BackgroundBeep.Beep(frequency, duration);
            zombie.SendData("[[PIANO]]" + frequency + "|*|" + duration + "[[/PIANO]]");
        }


        #region PIANOKEYS
        private void button1_Click(object sender, EventArgs e)
        {
            PlayNote(261, 200);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayNote(277, 200);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlayNote(293, 200);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PlayNote(311, 200);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PlayNote(329, 200);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PlayNote(349, 200);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PlayNote(370, 200);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PlayNote(392, 200);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PlayNote(415, 200);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PlayNote(440, 200);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PlayNote(466, 200);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PlayNote(493, 200);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PlayNote(523, 200);
        }
        #endregion
    }

    // Threadded beeping class
    class BackgroundBeep
    {
        static Thread beepThread;
        static AutoResetEvent signalBeep;
        static int frequency, duration;

        static BackgroundBeep()
        {
            signalBeep = new AutoResetEvent(false);
            beepThread = new Thread(() =>
            {
                for (;;)
                {
                    signalBeep.WaitOne();
                    Console.Beep(frequency, duration);
                }
            }, 1);
            beepThread.IsBackground = true;
            beepThread.Start();
        }

        public static void Beep(int f, int d)
        {
            frequency = f;
            duration = d;
            signalBeep.Set();
        }
    }
}
