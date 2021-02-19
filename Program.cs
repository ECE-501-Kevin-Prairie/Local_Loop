using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Runtime.InteropServices;

namespace ECE_501_Local_Loop
{
    class Program
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        static void Main(string[] args)
        {
            mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
            mciSendString("record recsound", "", 0, 0);
            Console.WriteLine("recording, press Enter to stop and save ...");
            Console.ReadLine();

            mciSendString("save recsound C:/result.wav", "", 0, 0);
            mciSendString("close recsound ", "", 0, 0);

            System.Media.SoundPlayer player = new System.Media.SoundPlayer("C:\\result.wav");
            player.PlaySync();
        }
    }
}
