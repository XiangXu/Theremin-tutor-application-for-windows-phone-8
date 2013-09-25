using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Theremin
{
    class MusicalNotes
    {
        public static double[] Notes() 
        {
            double[] midiHz = new double[128];
            double a = 440;

            for (int i = 0; i < 128; i++)
            {
                midiHz[i] = (a / 32) * (Math.Pow(2.0, ((i - 9) / 12.0)));
            }

            return midiHz;
        }
    }
}
