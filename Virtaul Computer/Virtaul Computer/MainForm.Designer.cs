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
            this.aNDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nANDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xNORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sWITCHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bUTTONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lIGHTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aNDToolStripMenuItem,
            this.oRToolStripMenuItem,
            this.nOTToolStripMenuItem,
            this.nANDToolStripMenuItem,
            this.nORToolStripMenuItem,
            this.xORToolStripMenuItem,
            this.xNORToolStripMenuItem,
            this.sWITCHToolStripMenuItem,
            this.bUTTONToolStripMenuItem,
            this.lIGHTToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(812, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aNDToolStripMenuItem
            // 
            this.aNDToolStripMenuItem.Name = "aNDToolStripMenuItem";
            this.aNDToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aNDToolStripMenuItem.Tag = "AND";
            this.aNDToolStripMenuItem.Text = "AND";
            this.aNDToolStripMenuItem.Click += new System.EventHandler(this.GateCreate);
            // 
            // oRToolStripMenuItem
            // 
            this.oRToolStripMenuItem.Name = "oRToolStripMenuItem";
            this.oRToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.oRToolStripMenuItem.Tag = "OR";
            this.oRToolStripMenuItem.Text = "OR";
            this.oRToolStripMenuItem.Click += new System.EventHandler(this.GateCreate);
            // 
            // nOTToolStripMenuItem
            // 
            this.nOTToolStripMenuItem.Name = "nOTToolStripMenuItem";
            this.nOTToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.nOTToolStripMenuItem.Tag = "NOT";
            this.nOTToolStripMenuItem.Text = "NOT";
            this.nOTToolStripMenuItem.Click += new System.EventHandler(this.GateCreate);
            // 
            // nANDToolStripMenuItem
            // 
            this.nANDToolStripMenuItem.Name = "nANDToolStripMenuItem";
            this.nANDToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.nANDToolStripMenuItem.Tag = "NAND";
            this.nANDToolStripMenuItem.Text = "NAND";
            this.nANDToolStripMenuItem.Click += new System.EventHandler(this.GateCreate);
            // 
            // nORToolStripMenuItem
            // 
            this.nORToolStripMenuItem.Name = "nORToolStripMenuItem";
            this.nORToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.nORToolStripMenuItem.Tag = "NOR";
            this.nORToolStripMenuItem.Text = "NOR";
            this.nORToolStripMenuItem.Click += new System.EventHandler(this.GateCreate);
            // 
            // xORToolStripMenuItem
            // 
            this.xORToolStripMenuItem.Name = "xORToolStripMenuItem";
            this.xORToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.xORToolStripMenuItem.Tag = "XOR";
            this.xORToolStripMenuItem.Text = "XOR";
            this.xORToolStripMenuItem.Click += new System.EventHandler(this.GateCreate);
            // 
            // xNORToolStripMenuItem
            // 
            this.xNORToolStripMenuItem.Name = "xNORToolStripMenuItem";
            this.xNORToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.xNORToolStripMenuItem.Tag = "XNOR";
            this.xNORToolStripMenuItem.Text = "XNOR";
            this.xNORToolStripMenuItem.Click += new System.EventHandler(this.GateCreate);
            // 
            // sWITCHToolStripMenuItem
            // 
            this.sWITCHToolStripMenuItem.Name = "sWITCHToolStripMenuItem";
            this.sWITCHToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.sWITCHToolStripMenuItem.Tag = "OFF";
            this.sWITCHToolStripMenuItem.Text = "SWITCH";
            this.sWITCHToolStripMenuItem.Click += new System.EventHandler(this.GateCreate);
            // 
            // bUTTONToolStripMenuItem
            // 
            this.bUTTONToolStripMenuItem.Name = "bUTTONToolStripMenuItem";
            this.bUTTONToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.bUTTONToolStripMenuItem.Tag = "BUTTON_OFF";
            this.bUTTONToolStripMenuItem.Text = "BUTTON";
            this.bUTTONToolStripMenuItem.Click += new System.EventHandler(this.GateCreate);
            // 
            // lIGHTToolStripMenuItem
            // 
            this.lIGHTToolStripMenuItem.Name = "lIGHTToolStripMenuItem";
            this.lIGHTToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.lIGHTToolStripMenuItem.Tag = "LIGHT";
            this.lIGHTToolStripMenuItem.Text = "LIGHT";
            this.lIGHTToolStripMenuItem.Click += new System.EventHandler(this.GateCreate);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 817);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logic Gates";
            this.Load += new System.EventHandler(this.Monitor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aNDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nOTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nANDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xNORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sWITCHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bUTTONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lIGHTToolStripMenuItem;
    }
}

