using System;
using System.Collections.Generic;
using System.Text;

namespace e2_StatisticAnalizerWithObj
{
    public interface IInputOutput
    {
        uint ReadNumberInt();
        double ReadNumberDouble();
        void WriteString(string output);
    }
}
