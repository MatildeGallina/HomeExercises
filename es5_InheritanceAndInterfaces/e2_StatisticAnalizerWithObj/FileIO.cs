using System;
using System.Collections.Generic;
using System.Text;

namespace e2_StatisticAnalizerWithObj
{
    class FileIO : IInputOutput
    {
        public FileIO()
        {
        }

        // percorsi dei file sul costruttore


        public uint ReadNumberInt()
        {
            throw new NotImplementedException();
        }

        public void WriteString(string output)
        {
            throw new NotImplementedException();
        }

        double IInputOutput.ReadNumberDouble()
        {
            // legge safe da un file
            throw new NotImplementedException();
        }
    }
}
