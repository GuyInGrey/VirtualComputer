using System.Collections.Generic;

namespace Virtaul_Computer
{
    public class LogicGate
    {
        private static List<LogicGate> _GateTable = new List<LogicGate>();
        public static LogicGate[] GateTable => _GateTable.ToArray();

        public LogicGate In1Gate { get; set; }
        public LogicGate In2Gate { get; set; }

        public bool In1 => In1Gate.Check();
        public bool In2 => In2Gate.Check();

        public GateType GateType { get; set; }

        public bool IsButtonOrSwitch => 
            GateType == GateType.ON || GateType == GateType.OFF || GateType == GateType.BUTTON_OFF || GateType == GateType.BUTTON_ON;

        public LogicGate(GateType type, LogicGate in1, LogicGate in2)
        {
            GateType = type;
            In1Gate = in1;
            In2Gate = in2;

            _GateTable.Add(this);
        }

        public bool Check()
        {
            switch (GateType)
            {
                case GateType.AND:
                    if (In1Gate == null || In2Gate == null)
                    {
                        return false;
                    }
                    return In1 && In2;
                case GateType.OR:
                    if (In1Gate == null || In2Gate == null)
                    {
                        return false;
                    }
                    return In1 || In2;
                case GateType.NOT:
                    if (In1Gate == null)
                    {
                        return true;
                    }
                    return !In1;
                case GateType.NAND:
                    if (In1Gate == null || In2Gate == null)
                    {
                        return true;
                    }
                    return !(In1 && In2);
                case GateType.NOR:
                    if (In1Gate == null || In2Gate == null)
                    {
                        return true;
                    }
                    return !(In1 || In2);
                case GateType.XOR:
                    if (In1Gate == null || In2Gate == null)
                    {
                        return false;
                    }
                    return (In1 != In2); // Quicker way of doing it.
                    //return (!(In1 && In2)) && (!(!In1 && !In2)); // "Correct" way of doing it.
                case GateType.XNOR:
                    if (In1Gate == null || In2Gate == null)
                    {
                        return false;
                    }
                    return (In1 == In2);
                case GateType.ON:
                    return true;
                case GateType.OFF:
                    return false;
                case GateType.LIGHT:
                    if (In1Gate == null)
                    { 
                        return false;
                    }
                    return In1;
                case GateType.BUTTON_OFF:
                    return false;
                case GateType.BUTTON_ON:
                    return true;
                default:
                    return false;
            }
        }

        public void Remove()
        {
            _GateTable.Remove(this);

            foreach (var gate in _GateTable)
            {
                if (gate.In1Gate == this)
                {
                    gate.In1Gate = null;
                }
                if (gate.In2Gate == this)
                {
                    gate.In2Gate = null;
                }
            }
        }
    }
}