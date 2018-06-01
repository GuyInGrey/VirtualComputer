using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Virtaul_Computer
{
    public class VisualLogicGate : LogicGate
    {
        public static List<VisualLogicGate> Gates { get; set; } = new List<VisualLogicGate>();
        public static Hashtable GateImages { get; } = new Hashtable();

        public static int GateSize = 100;

        public static int ellipseSize = 10;

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
                Location.Y + (GateSize / 2) - (ellipseSize / 2),
                ellipseSize,
                ellipseSize
        );

        public Rectangle In2NodeLocation => new Rectangle(
                Location.X - ellipseSize,
                Location.Y + GateSize,
                ellipseSize,
                ellipseSize
        );

        public Rectangle In1NodeLocation => new Rectangle(
                Location.X - ellipseSize,
                Location.Y - ellipseSize,
                ellipseSize,
                ellipseSize
        );

        public VisualLogicGate(GateType type) : this(type, null, null)
        {

        }

        public VisualLogicGate(GateType type, LogicGate in1, LogicGate in2) : base(type, in1, in2)
        {
            Gates.Add(this);
            Location = new Point(0, 0);
        }

        public void Draw(Graphics e)
        {
            if (GateType == GateType.LIGHT)
            {
                e.DrawImage((Bitmap)GateImages[Check() ? "LIGHT_ON" : "LIGHT_OFF"], Location.X, Location.Y, GateSize, GateSize);
            }
            else
            {
                e.DrawImage((Bitmap)GateImages[GateType.ToString()], Location.X, Location.Y, GateSize, GateSize);
            }

            var g1 = (VisualLogicGate)In1Gate;
            var g2 = (VisualLogicGate)In2Gate;

            if (g1 != null)
            {
                e.DrawLine(new Pen(g1.Check()? Color.Yellow : Color.Blue, 5f), Location, new Point(g1.Location.X + GateSize, g1.Location.Y + (GateSize / 2)));
            }
            if (g2 != null)
            {
                e.DrawLine(new Pen(g2.Check() ? Color.Yellow : Color.Blue, 5f), new Point(Location.X, Location.Y + GateSize), new Point(g2.Location.X + GateSize, g2.Location.Y + (GateSize / 2)));
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

        public void Remove()
        {
            Gates.Remove(this);

            foreach (var gate in Gates)
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