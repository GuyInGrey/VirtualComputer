namespace Virtaul_Computer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.drawPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createGateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aNDToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.oRToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nOTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nANDToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nORToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xORToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xNORToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sWITCHToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bUTTONToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lIGHTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAsModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.BackColor = System.Drawing.Color.Gray;
            this.drawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawPanel.Location = new System.Drawing.Point(0, 27);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(800, 800);
            this.drawPanel.TabIndex = 0;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPanel_Paint);
            this.drawPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseClick);
            this.drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseDown);
            this.drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseMove);
            this.drawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.createGateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.loadAsModuleToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // createGateToolStripMenuItem
            // 
            this.createGateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aNDToolStripMenuItem1,
            this.oRToolStripMenuItem1,
            this.nOTToolStripMenuItem1,
            this.nANDToolStripMenuItem1,
            this.nORToolStripMenuItem1,
            this.xORToolStripMenuItem1,
            this.xNORToolStripMenuItem1,
            this.sWITCHToolStripMenuItem1,
            this.bUTTONToolStripMenuItem1,
            this.lIGHTToolStripMenuItem1});
            this.createGateToolStripMenuItem.Name = "createGateToolStripMenuItem";
            this.createGateToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.createGateToolStripMenuItem.Text = "Create Gate";
            // 
            // aNDToolStripMenuItem1
            // 
            this.aNDToolStripMenuItem1.Name = "aNDToolStripMenuItem1";
            this.aNDToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.aNDToolStripMenuItem1.Tag = "AND";
            this.aNDToolStripMenuItem1.Text = "AND";
            this.aNDToolStripMenuItem1.Click += new System.EventHandler(this.GateCreate);
            // 
            // oRToolStripMenuItem1
            // 
            this.oRToolStripMenuItem1.Name = "oRToolStripMenuItem1";
            this.oRToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.oRToolStripMenuItem1.Tag = "OR";
            this.oRToolStripMenuItem1.Text = "OR";
            this.oRToolStripMenuItem1.Click += new System.EventHandler(this.GateCreate);
            // 
            // nOTToolStripMenuItem1
            // 
            this.nOTToolStripMenuItem1.Name = "nOTToolStripMenuItem1";
            this.nOTToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.nOTToolStripMenuItem1.Tag = "NOT";
            this.nOTToolStripMenuItem1.Text = "NOT";
            this.nOTToolStripMenuItem1.Click += new System.EventHandler(this.GateCreate);
            // 
            // nANDToolStripMenuItem1
            // 
            this.nANDToolStripMenuItem1.Name = "nANDToolStripMenuItem1";
            this.nANDToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.nANDToolStripMenuItem1.Tag = "NAND";
            this.nANDToolStripMenuItem1.Text = "NAND";
            this.nANDToolStripMenuItem1.Click += new System.EventHandler(this.GateCreate);
            // 
            // nORToolStripMenuItem1
            // 
            this.nORToolStripMenuItem1.Name = "nORToolStripMenuItem1";
            this.nORToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.nORToolStripMenuItem1.Tag = "NOR";
            this.nORToolStripMenuItem1.Text = "NOR";
            this.nORToolStripMenuItem1.Click += new System.EventHandler(this.GateCreate);
            // 
            // xORToolStripMenuItem1
            // 
            this.xORToolStripMenuItem1.Name = "xORToolStripMenuItem1";
            this.xORToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.xORToolStripMenuItem1.Tag = "XOR";
            this.xORToolStripMenuItem1.Text = "XOR";
            this.xORToolStripMenuItem1.Click += new System.EventHandler(this.GateCreate);
            // 
            // xNORToolStripMenuItem1
            // 
            this.xNORToolStripMenuItem1.Name = "xNORToolStripMenuItem1";
            this.xNORToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.xNORToolStripMenuItem1.Tag = "XNOR";
            this.xNORToolStripMenuItem1.Text = "XNOR";
            this.xNORToolStripMenuItem1.Click += new System.EventHandler(this.GateCreate);
            // 
            // sWITCHToolStripMenuItem1
            // 
            this.sWITCHToolStripMenuItem1.Name = "sWITCHToolStripMenuItem1";
            this.sWITCHToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.sWITCHToolStripMenuItem1.Tag = "OFF";
            this.sWITCHToolStripMenuItem1.Text = "SWITCH";
            this.sWITCHToolStripMenuItem1.Click += new System.EventHandler(this.GateCreate);
            // 
            // bUTTONToolStripMenuItem1
            // 
            this.bUTTONToolStripMenuItem1.Name = "bUTTONToolStripMenuItem1";
            this.bUTTONToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.bUTTONToolStripMenuItem1.Tag = "BUTTON_OFF";
            this.bUTTONToolStripMenuItem1.Text = "BUTTON";
            this.bUTTONToolStripMenuItem1.Click += new System.EventHandler(this.GateCreate);
            // 
            // lIGHTToolStripMenuItem1
            // 
            this.lIGHTToolStripMenuItem1.Name = "lIGHTToolStripMenuItem1";
            this.lIGHTToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.lIGHTToolStripMenuItem1.Tag = "LIGHT";
            this.lIGHTToolStripMenuItem1.Text = "LIGHT";
            this.lIGHTToolStripMenuItem1.Click += new System.EventHandler(this.GateCreate);
            // 
            // loadAsModuleToolStripMenuItem
            // 
            this.loadAsModuleToolStripMenuItem.Name = "loadAsModuleToolStripMenuItem";
            this.loadAsModuleToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.loadAsModuleToolStripMenuItem.Text = "Load As Module";
            this.loadAsModuleToolStripMenuItem.Click += new System.EventHandler(this.loadAsModuleToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 832);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logic Gates";
            this.Load += new System.EventHandler(this.Monitor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createGateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aNDToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem oRToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nOTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nANDToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nORToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xORToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xNORToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sWITCHToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bUTTONToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lIGHTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadAsModuleToolStripMenuItem;
    }
}

