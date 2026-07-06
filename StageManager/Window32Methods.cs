using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
//using System.Threading.Tasks;

namespace StageManager
{
    public class Window32Methods
    {
        [DllImport("winmm.dll", EntryPoint = "waveOutGetVolume")]
        public static extern int WaveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll", EntryPoint = "waveOutSetVolume")]
        public static extern int WaveOutSetVolume(IntPtr hwo, uint dwVolume);


    }
}
