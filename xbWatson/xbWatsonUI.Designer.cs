namespace xbWatson
{
	public partial class xbWatsonUI : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
			this.resources.ReleaseAllResources();
		}
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xbWatsonUI));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuEditCopySelection = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuEditCopyContents = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuEditClearWindow = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuEditSelectAll = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuEditLimitBufferLength = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuAddTimestamps = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuActions = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuActionsStart = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuActionsStop = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuActionsSelectConsoles = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigure = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnAssert = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnAssertPrompt = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnAssertBreak = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnAssertContinue = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnAssertRestart = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnException = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnExceptionPrompt = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnExceptionDump = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnExceptionContinue = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnExceptionRestart = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnRIP = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnRIPPrompt = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnRIPDump = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnRIPContinue = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureOnRIPRestart = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureAfterDump = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureAfterDumpContinue = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureAfterDumpRestart = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureDumpFormat = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureDumpFormatMini = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureDumpFormatFullHeap = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureConnectOnStart = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureDumpLocation = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuConfigureRestoreDefaults = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuWindows = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuWindowsTileVertically = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuWindowsTileHorizontally = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuWindowsCascade = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem ();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem [] {
            this.menuFile,
            this.menuEdit,
            this.menuActions,
            this.menuConfigure,
            this.menuWindows,
            this.menuHelp});
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem [] {
            this.menuFileSaveAs,
            this.menuFileExit});
            resources.ApplyResources(this.menuFile, "menuFile");
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
            resources.ApplyResources(this.menuFileSaveAs, "menuFileSaveAs");
            // 
            // menuFileExit
            // 
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            resources.ApplyResources(this.menuFileExit, "menuFileExit");
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem [] {
            this.menuEditCopySelection,
            this.menuEditCopyContents,
            this.menuEditClearWindow,
            this.menuEditSelectAll,
            this.menuEditLimitBufferLength,
            this.menuAddTimestamps,
            this.menuConfigureRestoreDefaults});
            resources.ApplyResources(this.menuEdit, "menuEdit");
            // 
            // menuEditCopySelection
            // 
            this.menuEditCopySelection.Click += new System.EventHandler(this.menuEditCopySelection_Click);
            resources.ApplyResources(this.menuEditCopySelection, "menuEditCopySelection");
            // 
            // menuEditCopyContents
            // 
            this.menuEditCopyContents.Click += new System.EventHandler(this.menuEditCopyContents_Click);
            resources.ApplyResources(this.menuEditCopyContents, "menuEditCopyContents");
            // 
            // menuEditClearWindow
            // 
            this.menuEditClearWindow.Click += new System.EventHandler(this.menuEditClearWindow_Click);
            resources.ApplyResources(this.menuEditClearWindow, "menuEditClearWindow");
            // 
            // menuEditSelectAll
            // 
            this.menuEditSelectAll.Click += new System.EventHandler(this.menuEditSelectAll_Click);
            resources.ApplyResources(this.menuEditSelectAll, "menuEditSelectAll");
            // 
            // menuEditLimitBufferLength
            // 
            this.menuEditLimitBufferLength.Click += new System.EventHandler(this.menuEditLimitBufferLength_Click);
            resources.ApplyResources(this.menuEditLimitBufferLength, "menuEditLimitBufferLength");
            // 
            // menuAddTimestamps
            // 
            this.menuAddTimestamps.Click += new System.EventHandler(this.menuAddTimestamps_Click);
            resources.ApplyResources(this.menuAddTimestamps, "menuAddTimestamps");
            // 
            // menuActions
            // 
            this.menuActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem [] {
            this.menuActionsStart,
            this.menuActionsStop,
            this.menuActionsSelectConsoles});
            resources.ApplyResources(this.menuActions, "menuActions");
            // 
            // menuActionsStart
            // 
            this.menuActionsStart.Click += new System.EventHandler(this.menuActionsStart_Click);
            resources.ApplyResources(this.menuActionsStart, "menuActionsStart");
            // 
            // menuActionsStop
            // 
            this.menuActionsStop.Click += new System.EventHandler(this.menuActionsStop_Click);
            resources.ApplyResources(this.menuActionsStop, "menuActionsStop");
            // 
            // menuActionsSelectConsoles
            // 
            this.menuActionsSelectConsoles.Click += new System.EventHandler(this.menuActionsSelectConsoles_Click);
            resources.ApplyResources(this.menuActionsSelectConsoles, "menuActionsSelectConsoles");
            // 
            // menuConfigure
            // 
            this.menuConfigure.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem [] {
            this.menuConfigureOnAssert,
            this.menuConfigureOnException,
            this.menuConfigureOnRIP,
            this.menuConfigureAfterDump,
            this.menuConfigureDumpFormat,
            this.menuConfigureConnectOnStart,
            this.menuConfigureDumpLocation,
            this.menuConfigureRestoreDefaults});
            resources.ApplyResources(this.menuConfigure, "menuConfigure");
            // 
            // menuConfigureOnAssert
            // 
            this.menuConfigureOnAssert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfigureOnAssertPrompt,
            this.menuConfigureOnAssertBreak,
            this.menuConfigureOnAssertContinue,
            this.menuConfigureOnAssertRestart});
            resources.ApplyResources(this.menuConfigureOnAssert, "menuConfigureOnAssert");
            // 
            // menuConfigureOnAssertPrompt
            // 
            this.menuConfigureOnAssertPrompt.Click += new System.EventHandler(this.menuConfigureOnAssertPrompt_Click);
            resources.ApplyResources(this.menuConfigureOnAssertPrompt, "menuConfigureOnAssertPrompt");
            // 
            // menuConfigureOnAssertBreak
            // 
            this.menuConfigureOnAssertBreak.Click += new System.EventHandler(this.menuConfigureOnAssertBreak_Click);
            resources.ApplyResources(this.menuConfigureOnAssertBreak, "menuConfigureOnAssertBreak");
            // 
            // menuConfigureOnAssertContinue
            // 
            this.menuConfigureOnAssertContinue.Click += new System.EventHandler(this.menuConfigureOnAssertContinue_Click);
            resources.ApplyResources(this.menuConfigureOnAssertContinue, "menuConfigureOnAssertContinue");
            // 
            // menuConfigureOnAssertRestart
            // 
            this.menuConfigureOnAssertRestart.Click += new System.EventHandler(this.menuConfigureOnAssertRestart_Click);
            resources.ApplyResources(this.menuConfigureOnAssertRestart, "menuConfigureOnAssertRestart");
            // 
            // menuConfigureOnException
            // 
            this.menuConfigureOnException.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfigureOnExceptionPrompt,
            this.menuConfigureOnExceptionDump,
            this.menuConfigureOnExceptionContinue,
            this.menuConfigureOnExceptionRestart});
            resources.ApplyResources(this.menuConfigureOnException, "menuConfigureOnException");
            // 
            // menuConfigureOnExceptionPrompt
            // 
            this.menuConfigureOnExceptionPrompt.Click += new System.EventHandler(this.menuConfigureOnExceptionPrompt_Click);
            resources.ApplyResources(this.menuConfigureOnExceptionPrompt, "menuConfigureOnExceptionPrompt");
            // 
            // menuConfigureOnExceptionDump
            // 
            this.menuConfigureOnExceptionDump.Click += new System.EventHandler(this.menuConfigureOnExceptionDump_Click);
            resources.ApplyResources(this.menuConfigureOnExceptionDump, "menuConfigureOnExceptionDump");
            // 
            // menuConfigureOnExceptionContinue
            // 
            this.menuConfigureOnExceptionContinue.Click += new System.EventHandler(this.menuConfigureOnExceptionContinue_Click);
            resources.ApplyResources(this.menuConfigureOnExceptionContinue, "menuConfigureOnExceptionContinue");
            // 
            // menuConfigureOnExceptionRestart
            // 
            this.menuConfigureOnExceptionRestart.Click += new System.EventHandler(this.menuConfigureOnExceptionRestart_Click);
            resources.ApplyResources(this.menuConfigureOnExceptionRestart, "menuConfigureOnExceptionRestart");
            // 
            // menuConfigureOnRIP
            // 
            this.menuConfigureOnRIP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfigureOnRIPPrompt,
            this.menuConfigureOnRIPDump,
            this.menuConfigureOnRIPContinue,
            this.menuConfigureOnRIPRestart});
            resources.ApplyResources(this.menuConfigureOnRIP, "menuConfigureOnRIP");
            // 
            // menuConfigureOnRIPPrompt
            // 
            this.menuConfigureOnRIPPrompt.Click += new System.EventHandler(this.menuConfigureOnRIPPrompt_Click);
            resources.ApplyResources(this.menuConfigureOnRIPPrompt, "menuConfigureOnRIPPrompt");
            // 
            // menuConfigureOnRIPDump
            // 
            this.menuConfigureOnRIPDump.Click += new System.EventHandler(this.menuConfigureOnRIPDump_Click);
            resources.ApplyResources(this.menuConfigureOnRIPDump, "menuConfigureOnRIPDump");
            // 
            // menuConfigureOnRIPContinue
            // 
            this.menuConfigureOnRIPContinue.Click += new System.EventHandler(this.menuConfigureOnRIPContinue_Click);
            resources.ApplyResources(this.menuConfigureOnRIPContinue, "menuConfigureOnRIPContinue");
            // 
            // menuConfigureOnRIPRestart
            // 
            this.menuConfigureOnRIPRestart.Click += new System.EventHandler(this.menuConfigureOnRIPRestart_Click);
            resources.ApplyResources(this.menuConfigureOnRIPRestart, "menuConfigureOnRIPRestart");
            // 
            // menuConfigureAfterDump
            // 
            this.menuConfigureAfterDump.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfigureAfterDumpContinue,
            this.menuConfigureAfterDumpRestart});
            resources.ApplyResources(this.menuConfigureAfterDump, "menuConfigureAfterDump");
            // 
            // menuConfigureAfterDumpContinue
            // 
            this.menuConfigureAfterDumpContinue.Click += new System.EventHandler(this.menuConfigureAfterDumpContinue_Click);
            resources.ApplyResources(this.menuConfigureAfterDumpContinue, "menuConfigureAfterDumpContinue");
            // 
            // menuConfigureAfterDumpRestart
            // 
            this.menuConfigureAfterDumpRestart.Click += new System.EventHandler(this.menuConfigureAfterDumpRestart_Click);
            resources.ApplyResources(this.menuConfigureAfterDumpRestart, "menuConfigureAfterDumpRestart");
            // 
            // menuConfigureDumpFormat
            // 
            this.menuConfigureDumpFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfigureDumpFormatMini,
            this.menuConfigureDumpFormatFullHeap});
            resources.ApplyResources(this.menuConfigureDumpFormat, "menuConfigureDumpFormat");
            // 
            // menuConfigureDumpFormatMini
            // 
            this.menuConfigureDumpFormatMini.Click += new System.EventHandler(this.menuConfigureDumpFormatMini_Click);
            resources.ApplyResources(this.menuConfigureDumpFormatMini, "menuConfigureDumpFormatMini");
            // 
            // menuConfigureDumpFormatFullHeap
            // 
            this.menuConfigureDumpFormatFullHeap.Click += new System.EventHandler(this.menuConfigureDumpFormatFullHeap_Click);
            resources.ApplyResources(this.menuConfigureDumpFormatFullHeap, "menuConfigureDumpFormatFullHeap");
            // 
            // menuConfigureConnectOnStart
            // 
            this.menuConfigureConnectOnStart.Checked = true;
            this.menuConfigureConnectOnStart.Click += new System.EventHandler(this.menuConfigureConnectOnStart_Click);
            resources.ApplyResources(this.menuConfigureConnectOnStart, "menuConfigureConnectOnStart");
            // 
            // menuConfigureDumpLocation
            // 
            this.menuConfigureDumpLocation.Click += new System.EventHandler(this.menuConfigureDumpLocation_Click);
            resources.ApplyResources(this.menuConfigureDumpLocation, "menuConfigureDumpLocation");
            // 
            // menuConfigureRestoreDefaults
            // 
            this.menuConfigureRestoreDefaults.Click += new System.EventHandler(this.menuConfigureRestoreDefaults_Click);
            resources.ApplyResources(this.menuConfigureRestoreDefaults, "menuConfigureRestoreDefaults");
            // 
            // menuWindows
            // 
            this.menuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem [] {
            this.menuWindowsTileVertically,
            this.menuWindowsTileHorizontally,
            this.menuWindowsCascade});
            resources.ApplyResources(this.menuWindows, "menuWindows");
            // 
            // menuWindowsTileVertically
            // 
            this.menuWindowsTileVertically.Click += new System.EventHandler(this.menuWindowsTileVertically_Click);
            resources.ApplyResources(this.menuWindowsTileVertically, "menuWindowsTileVertically");
            // 
            // menuWindowsTileHorizontally
            // 
            this.menuWindowsTileHorizontally.Click += new System.EventHandler(this.menuWindowsTileHorizontally_Click);
            resources.ApplyResources(this.menuWindowsTileHorizontally, "menuWindowsTileHorizontally");
            // 
            // menuWindowsCascade
            // 
            this.menuWindowsCascade.Click += new System.EventHandler(this.menuWindowsCascade_Click);
            resources.ApplyResources(this.menuWindowsCascade, "menuWindowsCascade");
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem [] {
            this.menuHelpAbout});
            resources.ApplyResources(this.menuHelp, "menuHelp");
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            resources.ApplyResources(this.menuHelpAbout, "menuHelpAbout");
            // 
            // xbWatsonUI
            // 
            resources.ApplyResources(this, "$this");
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Controls.Add(this.mainMenuStrip);
            this.Name = "xbWatsonUI";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.xbWatsonUI_Closing);
            this.Load += new System.EventHandler(this.xbWatson_Load);
            this.ResumeLayout(false);

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
        private System.ComponentModel.IContainer components;
	}
}
