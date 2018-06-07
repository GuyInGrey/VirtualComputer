using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Virtaul_Computer
{
    public class VisualLogicGate : LogicGate
    {
        public static Dictionary<string, VisualLogicGate> _GateTable = new Dictionary<string, VisualLogicGate>();

        public static Hashtable GateImages { get; } = new Hashtable();

        public static int GateSize { get; set; } = 70;

        public static int EllipseSize { get; set; } = 15;

        public static int InputBoxOffset => GateSize / 4;

        [JsonIgnore]
        public bool In1 => In1Gate != null ? GetGate(In1Gate).Output : false;
        [JsonIgnore]
        public bool In2 => In2Gate != null ? GetGate(In2Gate).Output : false;

        static VisualLogicGate()
        {
            foreach (var f in Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\GateImages"))
            {
                GateImages.Add(Path.GetFileNameWithoutExtension(f), new Bitmap(f));
            }
        }

        public Point Location { get; set; }

        public Rectangle Out1NodeLocation => new Rectangle(
                Location.X + GateSize,
                Location.Y + (GateSize / 2) - (EllipseSize / 2),
                EllipseSize,
                EllipseSize
        );

        public Rectangle In2NodeLocation => new Rectangle(
                Location.X - EllipseSize,
                Location.Y + GateSize,
                EllipseSize,
                EllipseSize
        );

        public Rectangle In1NodeLocation => new Rectangle(
                Location.X - EllipseSize,
                Location.Y - EllipseSize,
                EllipseSize,
                EllipseSize
        );

        public VisualLogicGate(GateType type) : this(type, null, null)
        {

        }

        [JsonConstructor]
        public VisualLogicGate(GateType type, LogicGate in1, LogicGate in2) : base(type, in1, in2)
        {
            Location = new Point(0, 0);

            do
            {
                GUID = System.Guid.NewGuid().ToString();
            }
            while (_GateTable.ContainsKey(GUID));
        }

        public VisualLogicGate GenNewID(Dictionary<string, VisualLogicGate> table)
        {
            var oldID = GUID;
            
            do
            {
                GUID = Guid.NewGuid().ToString();
            }
            while (table.ContainsKey(GUID));

            foreach (var gate in table)
            {
                if (gate.Value.In1Gate == oldID)
                {
                    gate.Value.In1Gate = GUID;
                }
                if (gate.Value.In2Gate == oldID)
                {
                    gate.Value.In2Gate = GUID;
                }
            }

            return this;
        }

        public static VisualLogicGate GetGate(string guid)
        {
            if (guid == null)
            {
                return null;
            }

            return _GateTable[guid];
        }

        public void Draw(Graphics e)
        {
            if (GateType == GateType.LIGHT)
            {
                e.DrawImage((Bitmap)GateImages[Output ? "LIGHT_ON" : "LIGHT_OFF"], Location.X, Location.Y, GateSize, GateSize);
            }
            else
            {
                e.DrawImage((Bitmap)GateImages[GateType.ToString()], Location.X, Location.Y, GateSize, GateSize);
            }

            var g1 = GetGate(In1Gate);
            var g2 = GetGate(In2Gate);

            var tension = 0.3f;
            var onColor = Color.Cyan;
            var offColor = Color.White;

            if (g1 != null)
            {
                var points = new List<Point>
                {
                    new Point(Location.X - (EllipseSize / 2), Location.Y - (EllipseSize / 2)),
                    new Point(Location.X - (EllipseSize / 2) - 30, Location.Y - (EllipseSize / 2)),
                    new Point(g1.Location.X + GateSize + (EllipseSize / 2) + 30, g1.Location.Y + (GateSize / 2)),
                    new Point(g1.Location.X + GateSize + (EllipseSize / 2), g1.Location.Y + (GateSize / 2))
                };

                e.DrawCurve(new Pen(g1.Output ? onColor : offColor, 5f), points.ToArray(), tension);
                
                if (MainForm.Debug)
                {
                    foreach (var p in points)
                    {
                        e.FillRectangle(Brushes.Blue, new Rectangle(p.X, p.Y, 5, 5));
                    }
                }
            }
            if (g2 != null)
            {
                var points = new List<Point>
                {
                    new Point(Location.X - (EllipseSize / 2), Location.Y + (EllipseSize / 2) + GateSize),
                    new Point(Location.X - (EllipseSize / 2) - 30, Location.Y + (EllipseSize / 2) + GateSize),
                    new Point(g2.Location.X + GateSize + (EllipseSize / 2) + 30, g2.Location.Y + (GateSize / 2)),
                    new Point(g2.Location.X + GateSize + (EllipseSize / 2), g2.Location.Y + (GateSize / 2))
                };

                e.DrawCurve(new Pen(g2.Output ? onColor : offColor, 5f), points.ToArray(), tension);

                if (MainForm.Debug)
                {
                    foreach (var p in points)
                    {
                        e.FillRectangle(Brushes.Blue, new Rectangle(p.X, p.Y, 5, 5));
                    }
                }
            }
            
            e.DrawRectangle(new Pen(Color.Black, 3f), new Rectangle(Location, new Size(GateSize, GateSize)));

            if (GateType == GateType.BUTTON_OFF || GateType == GateType.BUTTON_ON || GateType == GateType.ON || GateType == GateType.OFF)
            {

            }
            else if (GateType == GateType.LIGHT || GateType == GateType.NOT)
            {
                e.DrawEllipse(new Pen(Color.Black, 3f), In1NodeLocation);
            }
            else
            {
                e.DrawEllipse(new Pen(Color.Black, 3f), In1NodeLocation);

                e.DrawEllipse(new Pen(Color.Black, 3f), In2NodeLocation);
            }

            e.DrawEllipse(new Pen(Color.Black, 3f), Out1NodeLocation);
        }

        public static List<Point> SplitLine(Point a, Point b, int count)
        {
            count = count + 1;

            var d = Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y)) / count;
            var fi = Math.Atan2(b.Y - a.Y, b.X - a.X);

            var points = new List<Point>(count + 1);

            for (var i = 0; i <= count; ++i)
            {
                points.Add(new Point((int)(a.X + i * d * Math.Cos(fi)), (int)(a.Y + i * d * Math.Sin(fi))));
            }

            return points;
        }

        public Rectangle InputBounds
        {
            get
            {
                var rec = new Rectangle(
                    new Point(Location.X + InputBoxOffset, Location.Y + InputBoxOffset),
                    new Size(GateSize - (InputBoxOffset * 2), GateSize - (InputBoxOffset * 2)));

                return rec;
            }
        }

        public Rectangle Bounds
        {
            get
            {
                var rec = new Rectangle(Location, new Size(GateSize, GateSize));

                return rec;
            }

        }

        public static void RecurseGates(Action<VisualLogicGate> toRun) => 
            RecurseGates(toRun, false);

        public static void RecurseGates(Action<VisualLogicGate> toRun, bool rerunIfModified)
        {
            Beginning:;

            try
            {
                foreach (var gateObject in _GateTable.Values)
                {
                    if (gateObject is VisualLogicGate gate)
                    {
                        toRun(gate);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                if (rerunIfModified)
                {
                    goto Beginning;
                }
            }
        }

        [JsonIgnore]
        public bool Output { get; private set; }

        public void Update() => Output = Check();

        private bool Check()
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
            _GateTable.Remove(GUID);

            RecurseGates(gate =>
            {
                if (gate.In1Gate == GUID)
                {
                    gate.In1Gate = null;
                }
                if (gate.In2Gate == GUID)
                {
                    gate.In2Gate = null;
                }
            });
        }
    }
}