using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Virtaul_Computer
{
    public class LogicGate
    {
        public string GUID { get; set; }

        public string In1Gate { get; set; }
        public string In2Gate { get; set; }

        public GateType GateType { get; set; }

        [JsonIgnore]
        public bool IsButtonOrSwitch => 
            GateType == GateType.ON || GateType == GateType.OFF || GateType == GateType.BUTTON_OFF || GateType == GateType.BUTTON_ON;

        public LogicGate(GateType type, LogicGate in1, LogicGate in2)
        {
            GateType = type;

            if (in1 != null)
            {
                In1Gate = in1.GUID;
            }
            else
            {
                In1Gate = null;
            }
            if (in2 != null)
            {
                In2Gate = in2.GUID;
            }
            else
            {
                In2Gate = null;
            }
        }
    }
}