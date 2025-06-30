namespace xbWatson
{
	public partial class xbWatsonUI : global::System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xbWatsonUI));
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            menuFile = new System.Windows.Forms.ToolStripMenuItem();
            menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            menuEditCopySelection = new System.Windows.Forms.ToolStripMenuItem();
            menuEditCopyContents = new System.Windows.Forms.ToolStripMenuItem();
            menuEditClearWindow = new System.Windows.Forms.ToolStripMenuItem();
            menuEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            menuEditLimitBufferLength = new System.Windows.Forms.ToolStripMenuItem();
            menuAddTimestamps = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuActions = new System.Windows.Forms.ToolStripMenuItem();
            menuActionsStart = new System.Windows.Forms.ToolStripMenuItem();
            menuActionsStop = new System.Windows.Forms.ToolStripMenuItem();
            menuActionsSelectConsoles = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigure = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnAssert = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnAssertPrompt = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnAssertBreak = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnAssertContinue = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnAssertRestart = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnException = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnExceptionPrompt = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnExceptionDump = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnExceptionContinue = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnExceptionRestart = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnRIP = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnRIPPrompt = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnRIPDump = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnRIPContinue = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureOnRIPRestart = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureAfterDump = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureAfterDumpContinue = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureAfterDumpRestart = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureDumpFormat = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureDumpFormatMini = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureDumpFormatFullHeap = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureConnectOnStart = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureDumpLocation = new System.Windows.Forms.ToolStripMenuItem();
            menuConfigureRestoreDefaults = new System.Windows.Forms.ToolStripMenuItem();
            menuWindows = new System.Windows.Forms.ToolStripMenuItem();
            menuWindowsTileVertically = new System.Windows.Forms.ToolStripMenuItem();
            menuWindowsTileHorizontally = new System.Windows.Forms.ToolStripMenuItem();
            menuWindowsCascade = new System.Windows.Forms.ToolStripMenuItem();
            menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menuFile, menuEdit, menuActions, menuConfigure, menuWindows, menuHelp });
            resources.ApplyResources(mainMenuStrip, "mainMenuStrip");
            mainMenuStrip.Name = "mainMenuStrip";
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuFileSaveAs, menuFileExit });
            menuFile.Name = "menuFile";
            resources.ApplyResources(menuFile, "menuFile");
            // 
            // menuFileSaveAs
            // 
            menuFileSaveAs.Name = "menuFileSaveAs";
            resources.ApplyResources(menuFileSaveAs, "menuFileSaveAs");
            menuFileSaveAs.Click += menuFileSaveAs_Click;
            // 
            // menuFileExit
            // 
            menuFileExit.Name = "menuFileExit";
            resources.ApplyResources(menuFileExit, "menuFileExit");
            menuFileExit.Click += menuFileExit_Click;
            // 
            // menuEdit
            // 
            menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuEditCopySelection, menuEditCopyContents, menuEditClearWindow, menuEditSelectAll, menuEditLimitBufferLength, menuAddTimestamps, toolStripSeparator1, darkModeToolStripMenuItem });
            menuEdit.Name = "menuEdit";
            resources.ApplyResources(menuEdit, "menuEdit");
            // 
            // menuEditCopySelection
            // 
            menuEditCopySelection.Name = "menuEditCopySelection";
            resources.ApplyResources(menuEditCopySelection, "menuEditCopySelection");
            menuEditCopySelection.Click += menuEditCopySelection_Click;
            // 
            // menuEditCopyContents
            // 
            menuEditCopyContents.Name = "menuEditCopyContents";
            resources.ApplyResources(menuEditCopyContents, "menuEditCopyContents");
            menuEditCopyContents.Click += menuEditCopyContents_Click;
            // 
            // menuEditClearWindow
            // 
            menuEditClearWindow.Name = "menuEditClearWindow";
            resources.ApplyResources(menuEditClearWindow, "menuEditClearWindow");
            menuEditClearWindow.Click += menuEditClearWindow_Click;
            // 
            // menuEditSelectAll
            // 
            menuEditSelectAll.Name = "menuEditSelectAll";
            resources.ApplyResources(menuEditSelectAll, "menuEditSelectAll");
            menuEditSelectAll.Click += menuEditSelectAll_Click;
            // 
            // menuEditLimitBufferLength
            // 
            menuEditLimitBufferLength.Name = "menuEditLimitBufferLength";
            resources.ApplyResources(menuEditLimitBufferLength, "menuEditLimitBufferLength");
            menuEditLimitBufferLength.Click += menuEditLimitBufferLength_Click;
            // 
            // menuAddTimestamps
            // 
            menuAddTimestamps.Name = "menuAddTimestamps";
            resources.ApplyResources(menuAddTimestamps, "menuAddTimestamps");
            menuAddTimestamps.Click += menuAddTimestamps_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // darkModeToolStripMenuItem
            // 
            darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            resources.ApplyResources(darkModeToolStripMenuItem, "darkModeToolStripMenuItem");
            darkModeToolStripMenuItem.Click += darkModeToolStripMenuItem_Click;
            // 
            // menuActions
            // 
            menuActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuActionsStart, menuActionsStop, menuActionsSelectConsoles });
            menuActions.Name = "menuActions";
            resources.ApplyResources(menuActions, "menuActions");
            // 
            // menuActionsStart
            // 
            menuActionsStart.Name = "menuActionsStart";
            resources.ApplyResources(menuActionsStart, "menuActionsStart");
            menuActionsStart.Click += menuActionsStart_Click;
            // 
            // menuActionsStop
            // 
            resources.ApplyResources(menuActionsStop, "menuActionsStop");
            menuActionsStop.Name = "menuActionsStop";
            menuActionsStop.Click += menuActionsStop_Click;
            // 
            // menuActionsSelectConsoles
            // 
            menuActionsSelectConsoles.Name = "menuActionsSelectConsoles";
            resources.ApplyResources(menuActionsSelectConsoles, "menuActionsSelectConsoles");
            menuActionsSelectConsoles.Click += menuActionsSelectConsoles_Click;
            // 
            // menuConfigure
            // 
            menuConfigure.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuConfigureOnAssert, menuConfigureOnException, menuConfigureOnRIP, menuConfigureAfterDump, menuConfigureDumpFormat, menuConfigureConnectOnStart, menuConfigureDumpLocation, menuConfigureRestoreDefaults });
            menuConfigure.Name = "menuConfigure";
            resources.ApplyResources(menuConfigure, "menuConfigure");
            // 
            // menuConfigureOnAssert
            // 
            menuConfigureOnAssert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuConfigureOnAssertPrompt, menuConfigureOnAssertBreak, menuConfigureOnAssertContinue, menuConfigureOnAssertRestart });
            menuConfigureOnAssert.Name = "menuConfigureOnAssert";
            resources.ApplyResources(menuConfigureOnAssert, "menuConfigureOnAssert");
            // 
            // menuConfigureOnAssertPrompt
            // 
            menuConfigureOnAssertPrompt.Name = "menuConfigureOnAssertPrompt";
            resources.ApplyResources(menuConfigureOnAssertPrompt, "menuConfigureOnAssertPrompt");
            menuConfigureOnAssertPrompt.Click += menuConfigureOnAssertPrompt_Click;
            // 
            // menuConfigureOnAssertBreak
            // 
            menuConfigureOnAssertBreak.Name = "menuConfigureOnAssertBreak";
            resources.ApplyResources(menuConfigureOnAssertBreak, "menuConfigureOnAssertBreak");
            menuConfigureOnAssertBreak.Click += menuConfigureOnAssertBreak_Click;
            // 
            // menuConfigureOnAssertContinue
            // 
            menuConfigureOnAssertContinue.Name = "menuConfigureOnAssertContinue";
            resources.ApplyResources(menuConfigureOnAssertContinue, "menuConfigureOnAssertContinue");
            menuConfigureOnAssertContinue.Click += menuConfigureOnAssertContinue_Click;
            // 
            // menuConfigureOnAssertRestart
            // 
            menuConfigureOnAssertRestart.Name = "menuConfigureOnAssertRestart";
            resources.ApplyResources(menuConfigureOnAssertRestart, "menuConfigureOnAssertRestart");
            menuConfigureOnAssertRestart.Click += menuConfigureOnAssertRestart_Click;
            // 
            // menuConfigureOnException
            // 
            menuConfigureOnException.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuConfigureOnExceptionPrompt, menuConfigureOnExceptionDump, menuConfigureOnExceptionContinue, menuConfigureOnExceptionRestart });
            menuConfigureOnException.Name = "menuConfigureOnException";
            resources.ApplyResources(menuConfigureOnException, "menuConfigureOnException");
            // 
            // menuConfigureOnExceptionPrompt
            // 
            menuConfigureOnExceptionPrompt.Name = "menuConfigureOnExceptionPrompt";
            resources.ApplyResources(menuConfigureOnExceptionPrompt, "menuConfigureOnExceptionPrompt");
            menuConfigureOnExceptionPrompt.Click += menuConfigureOnExceptionPrompt_Click;
            // 
            // menuConfigureOnExceptionDump
            // 
            menuConfigureOnExceptionDump.Name = "menuConfigureOnExceptionDump";
            resources.ApplyResources(menuConfigureOnExceptionDump, "menuConfigureOnExceptionDump");
            menuConfigureOnExceptionDump.Click += menuConfigureOnExceptionDump_Click;
            // 
            // menuConfigureOnExceptionContinue
            // 
            menuConfigureOnExceptionContinue.Name = "menuConfigureOnExceptionContinue";
            resources.ApplyResources(menuConfigureOnExceptionContinue, "menuConfigureOnExceptionContinue");
            menuConfigureOnExceptionContinue.Click += menuConfigureOnExceptionContinue_Click;
            // 
            // menuConfigureOnExceptionRestart
            // 
            menuConfigureOnExceptionRestart.Name = "menuConfigureOnExceptionRestart";
            resources.ApplyResources(menuConfigureOnExceptionRestart, "menuConfigureOnExceptionRestart");
            menuConfigureOnExceptionRestart.Click += menuConfigureOnExceptionRestart_Click;
            // 
            // menuConfigureOnRIP
            // 
            menuConfigureOnRIP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuConfigureOnRIPPrompt, menuConfigureOnRIPDump, menuConfigureOnRIPContinue, menuConfigureOnRIPRestart });
            menuConfigureOnRIP.Name = "menuConfigureOnRIP";
            resources.ApplyResources(menuConfigureOnRIP, "menuConfigureOnRIP");
            // 
            // menuConfigureOnRIPPrompt
            // 
            menuConfigureOnRIPPrompt.Name = "menuConfigureOnRIPPrompt";
            resources.ApplyResources(menuConfigureOnRIPPrompt, "menuConfigureOnRIPPrompt");
            menuConfigureOnRIPPrompt.Click += menuConfigureOnRIPPrompt_Click;
            // 
            // menuConfigureOnRIPDump
            // 
            menuConfigureOnRIPDump.Name = "menuConfigureOnRIPDump";
            resources.ApplyResources(menuConfigureOnRIPDump, "menuConfigureOnRIPDump");
            menuConfigureOnRIPDump.Click += menuConfigureOnRIPDump_Click;
            // 
            // menuConfigureOnRIPContinue
            // 
            menuConfigureOnRIPContinue.Name = "menuConfigureOnRIPContinue";
            resources.ApplyResources(menuConfigureOnRIPContinue, "menuConfigureOnRIPContinue");
            menuConfigureOnRIPContinue.Click += menuConfigureOnRIPContinue_Click;
            // 
            // menuConfigureOnRIPRestart
            // 
            menuConfigureOnRIPRestart.Name = "menuConfigureOnRIPRestart";
            resources.ApplyResources(menuConfigureOnRIPRestart, "menuConfigureOnRIPRestart");
            menuConfigureOnRIPRestart.Click += menuConfigureOnRIPRestart_Click;
            // 
            // menuConfigureAfterDump
            // 
            menuConfigureAfterDump.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuConfigureAfterDumpContinue, menuConfigureAfterDumpRestart });
            menuConfigureAfterDump.Name = "menuConfigureAfterDump";
            resources.ApplyResources(menuConfigureAfterDump, "menuConfigureAfterDump");
            // 
            // menuConfigureAfterDumpContinue
            // 
            menuConfigureAfterDumpContinue.Name = "menuConfigureAfterDumpContinue";
            resources.ApplyResources(menuConfigureAfterDumpContinue, "menuConfigureAfterDumpContinue");
            menuConfigureAfterDumpContinue.Click += menuConfigureAfterDumpContinue_Click;
            // 
            // menuConfigureAfterDumpRestart
            // 
            menuConfigureAfterDumpRestart.Name = "menuConfigureAfterDumpRestart";
            resources.ApplyResources(menuConfigureAfterDumpRestart, "menuConfigureAfterDumpRestart");
            menuConfigureAfterDumpRestart.Click += menuConfigureAfterDumpRestart_Click;
            // 
            // menuConfigureDumpFormat
            // 
            menuConfigureDumpFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuConfigureDumpFormatMini, menuConfigureDumpFormatFullHeap });
            menuConfigureDumpFormat.Name = "menuConfigureDumpFormat";
            resources.ApplyResources(menuConfigureDumpFormat, "menuConfigureDumpFormat");
            // 
            // menuConfigureDumpFormatMini
            // 
            menuConfigureDumpFormatMini.Name = "menuConfigureDumpFormatMini";
            resources.ApplyResources(menuConfigureDumpFormatMini, "menuConfigureDumpFormatMini");
            menuConfigureDumpFormatMini.Click += menuConfigureDumpFormatMini_Click;
            // 
            // menuConfigureDumpFormatFullHeap
            // 
            menuConfigureDumpFormatFullHeap.Name = "menuConfigureDumpFormatFullHeap";
            resources.ApplyResources(menuConfigureDumpFormatFullHeap, "menuConfigureDumpFormatFullHeap");
            menuConfigureDumpFormatFullHeap.Click += menuConfigureDumpFormatFullHeap_Click;
            // 
            // menuConfigureConnectOnStart
            // 
            menuConfigureConnectOnStart.Checked = true;
            menuConfigureConnectOnStart.CheckState = System.Windows.Forms.CheckState.Checked;
            menuConfigureConnectOnStart.Name = "menuConfigureConnectOnStart";
            resources.ApplyResources(menuConfigureConnectOnStart, "menuConfigureConnectOnStart");
            menuConfigureConnectOnStart.Click += menuConfigureConnectOnStart_Click;
            // 
            // menuConfigureDumpLocation
            // 
            menuConfigureDumpLocation.Name = "menuConfigureDumpLocation";
            resources.ApplyResources(menuConfigureDumpLocation, "menuConfigureDumpLocation");
            menuConfigureDumpLocation.Click += menuConfigureDumpLocation_Click;
            // 
            // menuConfigureRestoreDefaults
            // 
            menuConfigureRestoreDefaults.Name = "menuConfigureRestoreDefaults";
            resources.ApplyResources(menuConfigureRestoreDefaults, "menuConfigureRestoreDefaults");
            menuConfigureRestoreDefaults.Click += menuConfigureRestoreDefaults_Click;
            // 
            // menuWindows
            // 
            menuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuWindowsTileVertically, menuWindowsTileHorizontally, menuWindowsCascade });
            menuWindows.Name = "menuWindows";
            resources.ApplyResources(menuWindows, "menuWindows");
            // 
            // menuWindowsTileVertically
            // 
            menuWindowsTileVertically.Name = "menuWindowsTileVertically";
            resources.ApplyResources(menuWindowsTileVertically, "menuWindowsTileVertically");
            menuWindowsTileVertically.Click += menuWindowsTileVertically_Click;
            // 
            // menuWinleHorizontally";
            resources.ApplyResources(menuWindowsTileHorizontally, "menuWindowsTileHorizontally");
            menuWindowsTileHorizontally.Click += menuWindowsTileHorizontally_Click;
            // 
            // menuWindowsCascade
            // 
            menuWindowsCascade.Name = "menuWindowsCascade";
            resources.ApplyResources(menuWindowsCascade, "menuWindowsCascade");
            menuWindowsCascade.Click += menuWindowsCascade_Click;
            // 
            // menuHelp
            // 
            menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuHelpAbout });
            menuHelp.Name = "menuHelp";
            resources.ApplyResources(menuHelp, "menuHelp");
            // 
            // menuHelpAbout
            // 
            menuHelpAbout.Name = "menuHelpAbout";
            resources.ApplyResources(menuHelpAbout, "menuHelpAbout");
            menuHelpAbout.Click += menuHelpAbout_Click;
            // 
            // xbWatsonUI
            // 
            resources.ApplyResources(this, "$this");
            Controls.Add(mainMenuStrip);
            IsMdiContainer = true;
            KeyPreview = true;
            MainMenuStrip = mainMenuStrip;
            Name = "xbWatsonUI";
            FormClosing += xbWatsonUI_FormClosing;
            Load += xbWatson_Load;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private global::System.Windows.Forms.MenuStrip mainMenuStrip;
		private global::System.Windows.Forms.ToolStripMenuItem  menuFile;
		private global::System.Windows.Forms.ToolStripMenuItem  menuFileExit;
		private global::System.Windows.Forms.ToolStripMenuItem  menuActions;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigure;
		private global::System.Windows.Forms.ToolStripMenuItem  menuActionsStart;
		private global::System.Windows.Forms.ToolStripMenuItem  menuHelp;
		private global::System.Windows.Forms.ToolStripMenuItem  menuHelpAbout;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnAssert;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnAssertPrompt;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnAssertContinue;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnAssertRestart;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnException;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnExceptionPrompt;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnExceptionDump;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnExceptionContinue;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnExceptionRestart;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnRIP;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnRIPPrompt;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnRIPDump;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnRIPContinue;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnRIPRestart;
		private global::System.Windows.Forms.ToolStripMenuItem  menuWindows;
		private global::System.Windows.Forms.ToolStripMenuItem  menuWindowsTileVertically;
		private global::System.Windows.Forms.ToolStripMenuItem  menuActionsSelectConsoles;
		private global::System.Windows.Forms.ToolStripMenuItem  menuActionsStop;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureOnAssertBreak;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureDumpLocation;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureDumpFormat;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureDumpFormatMini;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureDumpFormatFullHeap;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureRestoreDefaults;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureAfterDump;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureAfterDumpContinue;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureAfterDumpRestart;
		private global::System.Windows.Forms.ToolStripMenuItem  menuWindowsTileHorizontally;
		private global::System.Windows.Forms.ToolStripMenuItem  menuWindowsCascade;
		private global::System.Windows.Forms.ToolStripMenuItem  menuConfigureConnectOnStart;
		private global::System.Windows.Forms.ToolStripMenuItem  menuEdit;
		private global::System.Windows.Forms.ToolStripMenuItem  menuEditClearWindow;
		private global::System.Windows.Forms.ToolStripMenuItem  menuEditSelectAll;
		private global::System.Windows.Forms.ToolStripMenuItem  menuEditLimitBufferLength;
		private global::System.Windows.Forms.ToolStripMenuItem  menuAddTimestamps;
		private global::System.Windows.Forms.ToolStripMenuItem  menuFileSaveAs;
		private global::System.Windows.Forms.ToolStripMenuItem  menuEditCopySelection;
        private global::System.Windows.Forms.ToolStripMenuItem  menuEditCopyContents;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem darkModeToolStripMenuItem;
    }
}
