using FLaunch.Logic;
using System;
using System.Windows.Forms;
using static FLaunch.Logic.CommonConst;
using static FLaunch.Logic.CommonUtil;

namespace FLaunch.Forms
{
    /// <summary>
    /// MainForm
    /// </summary>
    public partial class MainForm : Form
    {
        #region Member
        /// <summary>
        /// ExitFlag
        /// </summary>
        private bool _exitFlag;

        /// <summary>
        /// App Settings
        /// </summary>
        private AppSettings _settings;
        #endregion

        #region Constructor & Form Event
        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// LoadEvent
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            //initial draw setting
            Opacity = 0;

            //hotkey bind
            if (!new HotKeyManager().EnableHotkey(Handle))
            {
                ShowMessage("Failed to allocate a hotkey.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Appname
            ntiMenu.Text = AppName;
            Text = AppName;
            tmiTitle.Text = AppName;

            //Event handle
            tmiMinimize.Click += MenuClick;
            tmiOpen.Click += MenuClick;
            tmiRefresh.Click += MenuClick;
            tmiSave.Click += MenuClick;
            tmiTitle.Click += MenuClick;
            tmiExit.Click += MenuClick;

            //Load settings
            var stm = new SettingManager();
            _settings = stm.Load() ?? new AppSettings
            {
                WindowSize = Size,
                WindowLocation = Location
            };

            //Tree 
            RefreshTree();
        }

        /// <summary>
        /// ShownEvent
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void MainForm_Shown(object sender, System.EventArgs e)
        {
            HideWindow();
            Opacity = 1;
        }
        /// <summary>
        /// ClosingEvent
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_exitFlag)
            {
                e.Cancel = true;
                HideWindow();
            }
        }

        /// <summary>
        /// ClosedEvent
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            new HotKeyManager().DisableHotkey(Handle);
        }
        #endregion

        #region Control Event
        /// <summary>
        /// Notifyicon MouseUp
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void ntiMenu_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { ToggleWindow(); }
        }

        /// <summary>
        /// MenuClick
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void MenuClick(object sender, EventArgs e)
        {
            var name = (sender as ToolStripMenuItem)?.Name;
            if (String.IsNullOrEmpty(name)) { return; }

            switch (name)
            {
                case "tmiMinimize":
                    HideWindow();
                    break;
                case "tmiOpen":
                    OpenShortcutDir();
                    break;
                case "tmiRefresh":
                    RefreshTree();
                    break;
                case "tmiSave":
                    SaveSetting();
                    break;
                case "tmiTitle":
                    About();
                    break;
                case "tmiExit":
                    ExitApp();
                    break;
            }
        }

        /// <summary>
        /// TreeView double click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void trvShortcut_DoubleClick(object sender, EventArgs e)
        {
            if (ShortcutUtil.ExecuteOpen(trvShortcut)) { HideWindow(); }
        }

        /// <summary>
        /// TreeView key down
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void trvShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            bool all;
            if (e.KeyData == Keys.Enter)
            {
                all = false;
            }
            else if (e.KeyData == (Keys.A | Keys.Control))
            {
                all = true;
            }
            else { return; }
            if (ShortcutUtil.ExecuteOpen(trvShortcut, all)) { HideWindow(); }

        }

        /// <summary>
        /// Hotkey event
        /// </summary>
        /// <param name="message">Msg</param>
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);
            if (message.Msg == HotKeyManager.MsgId && (int)message.WParam == HotKeyManager.HotKeyId)
            {
                ToggleWindow();
            }

        }
        #endregion

        #region Method
        /// <summary>
        /// Toggle show/hide
        /// </summary>
        private void ToggleWindow()
        {
            if (Visible)
            {
                if (ActiveForm == null) //NotActive
                {
                    Activate();
                    trvShortcut.Focus();
                }
                else //Active
                {
                    HideWindow();
                }
            }
            else //Hide
            {
                Location = _settings.WindowLocation;
                Size = _settings.WindowSize;
                Visible = true;
                Activate();
                trvShortcut.Focus();
            }
        }

        /// <summary>
        /// Hide
        /// </summary>
        private void HideWindow()
        {
            Visible = false;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        /// <summary>
        /// Open shortcut dir
        /// </summary>
        private void OpenShortcutDir()
        {
            ShortcutUtil.OpenShortcutDirFromExplorer();
        }

        /// <summary>
        /// Refresh tree
        /// </summary>
        private void RefreshTree()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SuspendLayout();
                ShortcutUtil.CreateTreeViewNodes(trvShortcut, ilsIcon);
                trvShortcut.ExpandAll();
                if (trvShortcut.Nodes.Count > 0)
                {
                    trvShortcut.SelectedNode = trvShortcut.Nodes[0];
                }
            }
            finally
            {
                ResumeLayout(true);
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Save setting
        /// </summary>
        private void SaveSetting()
        {
            _settings.WindowLocation = Location;
            _settings.WindowSize = Size;
            var stm = new SettingManager();
            stm.Save(_settings);
        }

        /// <summary>
        /// Show about message
        /// </summary>
        private void About()
        {
            const double divideForMib = 1048576;
            const string capFormat = "#,0.###";
            var mem = (GC.GetTotalMemory(false) / divideForMib).ToString(capFormat);
            ShowMessage(String.Format($@"FLaunch ヽ(･∀･)ﾉ

Ctrl + H : Open & Close the window (Hotkey)
Ctrl + W : Close the window 
Enter or DoubleClick : Open the shortcut
Ctrl + A : Open the all shortcut
Ctrl + O : Open the shortcut directory
Ctrl + S : Save the position and size of the window

GC.GetTotalMemory : {mem} MiB"));
        }

        /// <summary>
        /// ExitApp
        /// </summary>
        private void ExitApp()
        {
            ntiMenu.Visible = false;
            _exitFlag = true;
            Close();
        }
        #endregion
    }
}