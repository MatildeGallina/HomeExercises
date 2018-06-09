using System;
using System.Collections.Generic;
using System.Text;

namespace _2_StatisticAnalizerWithObj
{
    public interface IInputOutput
    {
        uint ReadNumberInt();
        double ReadNumberDouble();
        void WriteString(string output);
    }
}
