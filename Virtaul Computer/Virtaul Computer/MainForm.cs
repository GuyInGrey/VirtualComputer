using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Virtaul_Computer
{
    public partial class MainForm : Form
    {
        public DateTime MouseButtonDownTime { get; set; }
        public bool IsMouseButtonDown { get; set; }
        public VisualLogicGate SelectedGate { get; set; }
        public Size GrabOffset { get; set; }
        
        public bool IsConnectionBeingDragged { get; set; }
        public VisualLogicGate ConnectionDraggingFrom { get; set; }

        public MainForm() => 
            InitializeComponent();

        private void Monitor_Load(object sender, EventArgs e)
        {
            // Double Buffer Main Draw Panel
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           | BindingFlags.Instance | BindingFlags.NonPublic, null,
           drawPanel, new object[] { true });

            // Make Default Gates
            var gate = new VisualLogicGate(GateType.OFF)
            {
                Location = new Point(30, 30)
            };

            var light = new VisualLogicGate(GateType.LIGHT)
            {
                Location = new Point(200, 30),

                In1Gate = gate
            };
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            // Make Sure Antialiasing is on.
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //Draw Grid
            var gridImage = (Bitmap)VisualLogicGate.GateImages["GRID"];
            for (var x = 0; x < 5; x++)
            {
                for (var y = 0; y < 5; y++)
                {
                    e.Graphics.DrawImage(gridImage, new Point(160 * x, 160 * y));
                }
            }

            // Tell each gate to draw.
            foreach (var gate in VisualLogicGate.Gates)
            {
                gate.Draw(e.Graphics);
            }

            // If you are currently dragging a connection, draw it.
            if (IsConnectionBeingDragged && ConnectionDraggingFrom != null)
            {
                e.Graphics.DrawLine(new Pen(Color.Orange, 5f), ConnectionDraggingFrom.Out1NodeLocation.Location, mouseLocation);
            }

            // Begin next frame render.
            drawPanel.Invalidate();
        }

        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseButtonDown = false;

            if (SelectedGate != null)
            {
                if (SelectedGate.GateType == GateType.ON)
                {
                    SelectedGate.GateType = GateType.OFF;
                }
                else if (SelectedGate.GateType == GateType.OFF)
                {
                    SelectedGate.GateType = GateType.ON;
                }
            }
            
            var rec = new Rectangle(SelectedGate.Location, new Size(VisualLogicGate.GateSize, VisualLogicGate.GateSize));

            if (rec.Contains(e.Location))
            {
                if (SelectedGate.GateType == GateType.BUTTON_ON)
                {
                    SelectedGate.GateType = GateType.BUTTON_OFF;
                }
            }
        }

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MouseButtonDownTime = DateTime.Now;
            IsMouseButtonDown = true;

            foreach (var gate in VisualLogicGate.Gates)
            {
                var rec = new Rectangle(gate.Location, new Size(VisualLogicGate.GateSize, VisualLogicGate.GateSize));

                if (rec.Contains(e.Location))
                {
                    SelectedGate = gate;
                    GrabOffset = new Size(e.Location.X - gate.Location.X, e.Location.Y - gate.Location.Y);

                    if (gate.GateType == GateType.BUTTON_OFF)
                    {
                        gate.GateType = GateType.BUTTON_ON;
                    }
                }
            }
        }

        Point mouseLocation;

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            mouseLocation = e.Location;

            if (IsMouseButtonDown)
            {
                var between = DateTime.Now - MouseButtonDownTime;
                
                SelectedGate.Location = new Point(e.Location.X - GrabOffset.Width, e.Location.Y - GrabOffset.Height);
            }
        }

        private void DrawPanel_MouseClick(object sender, MouseEventArgs e)
        {
            restartLoop:;

            foreach (var gate in VisualLogicGate.Gates)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (gate.Out1NodeLocation.Contains(e.Location) && !IsConnectionBeingDragged)
                    {
                        IsConnectionBeingDragged = true;
                        ConnectionDraggingFrom = gate;
                    }
                    else if (gate.In1NodeLocation.Contains(e.Location) && IsConnectionBeingDragged && ConnectionDraggingFrom != null)
                    {
                        IsConnectionBeingDragged = false;
                        gate.In1Gate = ConnectionDraggingFrom;
                    }
                    else if (gate.In2NodeLocation.Contains(e.Location) && IsConnectionBeingDragged && ConnectionDraggingFrom != null)
                    {
                        IsConnectionBeingDragged = false;
                        gate.In2Gate = ConnectionDraggingFrom;
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (gate.In1NodeLocation.Contains(e.Location))
                    {
                        gate.In1Gate = null;
                    }
                    else if (gate.In2NodeLocation.Contains(e.Location))
                    {
                        gate.In2Gate = null;
                    }
                    else if ((new Rectangle(gate.Location, new Size(VisualLogicGate.GateSize, VisualLogicGate.GateSize))).Contains(e.Location))
                    {
                        gate.Remove();
                        goto restartLoop;
                    }
                }
            }
        }

        private void GateCreate(object sender, EventArgs e)
        {
            var typeString = ((ToolStripMenuItem)sender).Tag.ToString();
            var type = (GateType)Enum.Parse(typeof(GateType), typeString);

            var gate = new VisualLogicGate(type);
        }
    }
}