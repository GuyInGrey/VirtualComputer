using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Collections;

namespace Virtaul_Computer
{
    public partial class MainForm : Form
    {
        public static bool Debug { get; set; } = false;
        public static bool DrawGrid { get; set; } = false;

        public DateTime MouseButtonDownTime { get; set; }
        public bool IsMouseButtonDown { get; set; }
        public Point MouseDownLocation { get; set; } = new Point(0, 0);
        public VisualLogicGate SelectedGate { get; set; }
        public Size GrabOffset { get; set; }
        
        public bool IsConnectionBeingDragged { get; set; }
        public VisualLogicGate ConnectionDraggingFrom { get; set; }

        public int ViewX { get; set; } = 0;
        public int ViewY { get; set; } = 0;
        public float ViewSize { get; set; } = 1f;

        public bool _Running { get; set; } = true;
        public bool Running
        {
            get => _Running;
            set
            {
                _Running = value;
                if (_Running)
                {
                    drawPanel.Invalidate();
                }
            }
        }

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

                In1Gate = gate.GUID
            };

            VisualLogicGate._GateTable.Add(gate.GUID, gate);
            VisualLogicGate._GateTable.Add(light.GUID, light);
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            if (Running)
            {
                //Scale Limits
                if (ViewSize > 2.5)
                {
                    ViewSize = 2.5f;
                }

                if (ViewSize < 0.5f)
                {
                    ViewSize = 0.5f;
                }

                if (DownKeys.Contains(Keys.Left))
                {
                    ViewX += 4;
                }
                if (DownKeys.Contains(Keys.Right))
                {
                    ViewX -= 4;
                }
                if (DownKeys.Contains(Keys.Up))
                {
                    ViewY += 4;
                }
                if (DownKeys.Contains(Keys.Down))
                {
                    ViewY -= 4;
                }

                //Camera
                e.Graphics.ScaleTransform(1 / ViewSize, 1 / ViewSize);
                e.Graphics.TranslateTransform(ViewX, ViewY);

                // Make Sure Antialiasing is on.
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

                //Draw Grid
                if (DrawGrid)
                {
                    var countX = 5 * ViewSize;
                    var countY = 5 * ViewSize;

                    var gridImage = (Bitmap)VisualLogicGate.GateImages["GRID"];
                    for (var x = 0; x < countX; x++)
                    {
                        for (var y = 0; y < countY; y++)
                        {
                            e.Graphics.DrawImage(gridImage, new Point((160 * x) - ViewX, (160 * y) - ViewY));
                        }
                    }
                }

                // Tell each gate to draw.

                VisualLogicGate.RecurseGates(vGate =>
                {
                    vGate.Draw(e.Graphics);

                //Draw Bound Box
                if (Debug)
                    {
                        e.Graphics.DrawRectangle(Pens.Red, vGate.InputBounds);
                    }
                });

                // If you are currently dragging a connection, draw it.
                if (IsConnectionBeingDragged && ConnectionDraggingFrom != null)
                {
                    e.Graphics.DrawLine(new Pen(Color.Orange, 5f), ConnectionDraggingFrom.Out1NodeLocation.Location, mouseLocation);
                }

                // Begin next frame render.
                drawPanel.Invalidate();

                VisualLogicGate.RecurseGates(gate =>
                {
                    gate.Update();
                });
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '+':
                    ViewSize /= 1.1f;
                    break;
                case '-':
                    ViewSize *= 1.1f;
                    break;
            }
        }

        List<Keys> DownKeys = new List<Keys>();

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            while (!DownKeys.Contains(e.KeyCode))
            {
                DownKeys.Add(e.KeyCode);
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            while (DownKeys.Contains(e.KeyCode))
            {
                DownKeys.Remove(e.KeyCode);
            }
        }

        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseButtonDown = false;

            if (SelectedGate != null)
            {
                if (SelectedGate.IsButtonOrSwitch)
                {
                    //Switch toggling.
                    if (SelectedGate.InputBounds.Contains(MouseDownLocation))
                    {
                        if (SelectedGate.GateType == GateType.ON)
                        {
                            SelectedGate.GateType = GateType.OFF;
                        }
                        else if (SelectedGate.GateType == GateType.OFF)
                        {
                            SelectedGate.GateType = GateType.ON;
                        }

                        //Button goes off when mouse button is raised.
                        if (SelectedGate.GateType == GateType.BUTTON_ON)
                        {
                            SelectedGate.GateType = GateType.BUTTON_OFF;
                        }
                    }
                }
            }
        }

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownLocation = mouseLocation;
            MouseButtonDownTime = DateTime.Now;
            IsMouseButtonDown = true;

            var foundGate = false;

            VisualLogicGate.RecurseGates(vGate =>
            {
                if (vGate.InputBounds.Contains(MouseDownLocation))
                {
                    if (vGate.GateType == GateType.BUTTON_OFF)
                    {
                        vGate.GateType = GateType.BUTTON_ON;
                    }
                }

                if (vGate.Bounds.Contains(MouseDownLocation))
                {
                    foundGate = true;
                    SelectedGate = vGate;
                    GrabOffset = new Size(MouseDownLocation.X - vGate.Location.X, MouseDownLocation.Y - vGate.Location.Y);
                }
            });

            if (!foundGate)
            {
                SelectedGate = null;
            }
        }

        Point mouseLocation;

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point((int)(e.Location.X * ViewSize) - ViewX, (int)(e.Location.Y * ViewSize) - ViewY);

            if (SelectedGate != null)
            {
                if (IsMouseButtonDown)
                {
                    if (SelectedGate.IsButtonOrSwitch)
                    {
                        if (!SelectedGate.InputBounds.Contains(MouseDownLocation))
                        {
                            SelectedGate.Location = new Point(mouseLocation.X - GrabOffset.Width, mouseLocation.Y - GrabOffset.Height);
                        }
                    }
                    else
                    {
                        SelectedGate.Location = new Point(mouseLocation.X - GrabOffset.Width, mouseLocation.Y - GrabOffset.Height);
                    }
                }
            }
        }

        private void DrawPanel_MouseClick(object sender, MouseEventArgs e) =>
            VisualLogicGate.RecurseGates(vGate =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (vGate.Out1NodeLocation.Contains(mouseLocation) && !IsConnectionBeingDragged)
                    {
                        IsConnectionBeingDragged = true;
                        ConnectionDraggingFrom = vGate;
                    }
                    else if (vGate.In1NodeLocation.Contains(mouseLocation) && IsConnectionBeingDragged && ConnectionDraggingFrom != null)
                    {
                        IsConnectionBeingDragged = false;
                        vGate.In1Gate = ConnectionDraggingFrom.GUID;
                    }
                    else if (vGate.In2NodeLocation.Contains(mouseLocation) && IsConnectionBeingDragged && ConnectionDraggingFrom != null)
                    {
                        IsConnectionBeingDragged = false;
                        vGate.In2Gate = ConnectionDraggingFrom.GUID;
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                if (vGate.In1NodeLocation.Contains(mouseLocation))
                {
                    vGate.In1Gate = null;
                }
                else if (vGate.In2NodeLocation.Contains(mouseLocation))
                {
                    vGate.In2Gate = null;
                }
                else if (vGate.Bounds.Contains(mouseLocation))
                {
                    vGate.Remove();
                }
                }
            });

        private void GateCreate(object sender, EventArgs e)
        {
            var typeString = ((ToolStripMenuItem)sender).Tag.ToString();
            var type = (GateType)Enum.Parse(typeof(GateType), typeString);

            var gate = new VisualLogicGate(type)
            {
                Location = new Point(-ViewX, -ViewY)
            };

            VisualLogicGate._GateTable.Add(gate.GUID, gate);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Running = false;
            var json = JsonConvert.SerializeObject(VisualLogicGate._GateTable, Formatting.Indented, Settings);

            var save = new SaveFileDialog
            {
                CheckPathExists = true,
                Filter = "Logic File (*.logic)|*.logic",
                OverwritePrompt = true,
                Title = "Save the logic map.",
                ValidateNames = true
            };

            var result = save.ShowDialog();

            if (result == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, json);
                MessageBox.Show("Saved successfully as: \n" + Path.GetFileName(save.FileName), "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Running = true;
        }

        public JsonSerializerSettings Settings
        {
            get
            {
                var s = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return s;
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Running = false;

            var open = new OpenFileDialog
            {
                CheckPathExists = true,
                Filter = "Logic File (*.logic)|*.logic",
                Title = "Open a logic map.",
                ValidateNames = true
            };

            var result = open.ShowDialog();
            var json = "";

            if (result == DialogResult.OK)
            {
                json = File.ReadAllText(open.FileName);
            }

            var table = JsonConvert.DeserializeObject<Dictionary<string, VisualLogicGate>>(json, Settings);

            VisualLogicGate._GateTable = table;

            Running = true;
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Running = false;
            var result = MessageBox.Show("Are you sure you want to clear the entire board and start anew? Unsaved changes will be lost.", 
                "Are you sure?", 
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Warning, 
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                VisualLogicGate.RecurseGates(gate =>
                {
                    gate.Remove();
                }, true);
            }
            Running = true;
        }

        private void loadAsModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Running = false;

            var open = new OpenFileDialog
            {
                CheckPathExists = true,
                Filter = "Logic File (*.logic)|*.logic",
                Title = "Open a logic map.",
                ValidateNames = true
            };

            var result = open.ShowDialog();
            var json = "";

            if (result == DialogResult.OK)
            {
                json = File.ReadAllText(open.FileName);

                var table = JsonConvert.DeserializeObject<Dictionary<string, VisualLogicGate>>(json, Settings);

                foreach (var gate in table)
                {
                    gate.Value.Location = new Point(
                        gate.Value.Location.X - ViewX,
                        gate.Value.Location.Y - ViewY
                        );
                }

                var newTable = new Dictionary<string, VisualLogicGate>();

                foreach (var pair in table)
                {
                    var newGate = pair.Value.GenNewID(table);
                    newTable.Add(newGate.GUID, newGate);
                }

                foreach (var pair in newTable)
                {
                    VisualLogicGate._GateTable.Add(pair.Key, pair.Value);
                }
            }

            Running = true;
        }
    }
}