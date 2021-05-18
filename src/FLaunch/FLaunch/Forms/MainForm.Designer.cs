namespace FLaunch.Forms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ntiMenu = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.trvShortcut = new System.Windows.Forms.TreeView();
            this.ilsIcon = new System.Windows.Forms.ImageList(this.components);
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.tmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiMinimize = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmMenu.SuspendLayout();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ntiMenu
            // 
            this.ntiMenu.ContextMenuStrip = this.ctmMenu;
            this.ntiMenu.Icon = ((System.Drawing.Icon)(resources.GetObject("ntiMenu.Icon")));
            this.ntiMenu.Visible = true;
            this.ntiMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ntiMenu_MouseUp);
            // 
            // ctmMenu
            // 
            this.ctmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiTitle,
            this.tss1,
            this.tmiExit});
            this.ctmMenu.Name = "ctmMenu";
            this.ctmMenu.Size = new System.Drawing.Size(91, 54);
            // 
            // tmiTitle
            // 
            this.tmiTitle.Name = "tmiTitle";
            this.tmiTitle.Size = new System.Drawing.Size(90, 22);
            // 
            // tss1
            // 
            this.tss1.Name = "tss1";
            this.tss1.Size = new System.Drawing.Size(87, 6);
            // 
            // tmiExit
            // 
            this.tmiExit.Name = "tmiExit";
            this.tmiExit.Size = new System.Drawing.Size(90, 22);
            this.tmiExit.Text = "&Exit";
            // 
            // trvShortcut
            // 
            this.trvShortcut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvShortcut.ImageIndex = 0;
            this.trvShortcut.ImageList = this.ilsIcon;
            this.trvShortcut.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.trvShortcut.Location = new System.Drawing.Point(0, 0);
            this.trvShortcut.Name = "trvShortcut";
            this.trvShortcut.SelectedImageIndex = 0;
            this.trvShortcut.Size = new System.Drawing.Size(262, 453);
            this.trvShortcut.TabIndex = 0;
            this.trvShortcut.DoubleClick += new System.EventHandler(this.trvShortcut_DoubleClick);
            this.trvShortcut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trvShortcut_KeyDown);
            // 
            // ilsIcon
            // 
            this.ilsIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilsIcon.ImageSize = new System.Drawing.Size(16, 16);
            this.ilsIcon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiFile});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(292, 24);
            this.mnuMenu.TabIndex = 2;
            this.mnuMenu.Visible = false;
            // 
            // tmiFile
            // 
            this.tmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiMinimize,
            this.tmiOpen,
            this.tmiRefresh,
            this.tmiSave});
            this.tmiFile.Name = "tmiFile";
            this.tmiFile.Size = new System.Drawing.Size(36, 20);
            this.tmiFile.Text = "&File";
            // 
            // tmiMinimize
            // 
            this.tmiMinimize.Name = "tmiMinimize";
            this.tmiMinimize.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tmiMinimize.Size = new System.Drawing.Size(153, 22);
            this.tmiMinimize.Text = "&Minimize";
            // 
            // tmiOpen
            // 
            this.tmiOpen.Name = "tmiOpen";
            this.tmiOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tmiOpen.Size = new System.Drawing.Size(153, 22);
            this.tmiOpen.Text = "&Open";
            // 
            // tmiRefresh
            // 
            this.tmiRefresh.Name = "tmiRefresh";
            this.tmiRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tmiRefresh.Size = new System.Drawing.Size(153, 22);
            this.tmiRefresh.Text = "&Refresh";
            // 
            // tmiSave
            // 
            this.tmiSave.Name = "tmiSave";
            this.tmiSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tmiSave.Size = new System.Drawing.Size(153, 22);
            this.tmiSave.Text = "&Save";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 453);
            this.Controls.Add(this.trvShortcut);
            this.Controls.Add(this.mnuMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ctmMenu.ResumeLayout(false);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon ntiMenu;
        private System.Windows.Forms.TreeView trvShortcut;
        private System.Windows.Forms.ContextMenuStrip ctmMenu;
        private System.Windows.Forms.ToolStripMenuItem tmiExit;
        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem tmiFile;
        private System.Windows.Forms.ToolStripMenuItem tmiMinimize;
        private System.Windows.Forms.ToolStripMenuItem tmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tmiRefresh;
        private System.Windows.Forms.ToolStripMenuItem tmiSave;
        private System.Windows.Forms.ToolStripMenuItem tmiTitle;
        private System.Windows.Forms.ToolStripSeparator tss1;
        private System.Windows.Forms.ImageList ilsIcon;
    }
}