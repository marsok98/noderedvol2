using System;
using System.Collections.Generic;
using System.Text;

namespace noderedvol2
{
    public class DataFromPLC
    {
       public bool iStart;
        bool iStop;
        bool iRight;
        bool iLeft;
        public double iSetPoint;
        bool oLightRight;
        bool oLightLeft;
        double oPresentValue;
    }
}
