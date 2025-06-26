namespace xbWatson
{
    public partial class xbWatson : global::System.Windows.Forms.Form
    {
        private global::System.ComponentModel.IContainer components;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new global::System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xbWatson));
            this.log = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuCopySelection = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuCopyContents = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuClearWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuSaveContents = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuLimitBufferLength = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuAddTimestamps = new System.Windows.Forms.ToolStripMenuItem();

            this.SuspendLayout();

            // log
            this.log.BackColor = System.Drawing.SystemColors.Window;
            this.log.ContextMenuStrip = this.contextMenuStrip;
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log.Location = new System.Drawing.Point(0, 0);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(792, 566);
            this.log.TabIndex = 0;
            this.log.Text = "";
            this.log.MouseDown += new System.Windows.Forms.MouseEventHandler(this.log_MouseDown);

            // contextMenuStrip
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.contextMenuCopySelection,
                this.contextMenuCopyContents,
                this.contextMenuClearWindow,
                this.contextMenuSelectAll,
                this.toolStripSeparator1,
                this.contextMenuSaveContents,
                this.contextMenuLimitBufferLength,
                this.contextMenuAddTimestamps
            });
            this.contextMenuStrip.Name = "contextMenuStrip";

            // contextMenuCopySelection
            this.contextMenuCopySelection.Name = "contextMenuCopySelection";
            this.contextMenuCopySelection.Size = new System.Drawing.Size(180, 22);
            this.contextMenuCopySelection.Text = "Copy Selection";
            this.contextMenuCopySelection.Click += new System.EventHandler(this.contextMenuCopySelection_Click);

            // contextMenuCopyContents
            this.contextMenuCopyContents.Name = "contextMenuCopyContents";
            this.contextMenuCopyContents.Size = new System.Drawing.Size(180, 22);
            this.contextMenuCopyContents.Text = "Copy Contents";
            this.contextMenuCopyContents.Click += new System.EventHandler(this.contextMenuCopyContents_Click);

            // contextMenuClearWindow
            this.contextMenuClearWindow.Name = "contextMenuClearWindow";
            this.contextMenuClearWindow.Size = new System.Drawing.Size(180, 22);
            this.contextMenuClearWindow.Text = "Clear Window";
            this.contextMenuClearWindow.Click += new System.EventHandler(this.contextMenuClearWindow_Click);

            // contextMenuSelectAll
            this.contextMenuSelectAll.Name = "contextMenuSelectAll";
            this.contextMenuSelectAll.Size = new System.Drawing.Size(180, 22);
            this.contextMenuSelectAll.Text = "Select All";
            this.contextMenuSelectAll.Click += new System.EventHandler(this.contextMenuSelectAll_Click);

            // toolStripSeparator1
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);

            // contextMenuSaveContents
            this.contextMenuSaveContents.Name = "contextMenuSaveContents";
            this.contextMenuSaveContents.Size = new System.Drawing.Size(180, 22);
            this.contextMenuSaveContents.Text = "Save As";
            this.contextMenuSaveContents.Click += new System.EventHandler(this.contextMenuSaveContents_Click);

            // contextMenuLimitBufferLength
            this.contextMenuLimitBufferLength.Name = "contextMenuLimitBufferLength";
            this.contextMenuLimitBufferLength.Size = new System.Drawing.Size(180, 22);
            this.contextMenuLimitBufferLength.Text = "Limit Buffer Length";
            this.contextMenuLimitBufferLength.Click += new System.EventHandler(this.contextMenuLimitBufferLength_Click);

            // contextMenuAddTimestamps
            this.contextMenuAddTimestamps.Name = "contextMenuAddTimestamps";
            this.contextMenuAddTimestamps.Size = new System.Drawing.Size(180, 22);
            this.contextMenuAddTimestamps.Text = "Add Timestamps";
            this.contextMenuAddTimestamps.Click += new System.EventHandler(this.contextMenuAddTimestamps_Click);

            // xbWatson form
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.log);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "xbWatson";
            this.Text = "xbWatson";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.xbWatson_Closing);
            this.ResumeLayout(false);
        }

        private global::System.Windows.Forms.RichTextBox log;
        private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private global::System.Windows.Forms.ToolStripMenuItem contextMenuCopySelection;
        private global::System.Windows.Forms.ToolStripMenuItem contextMenuCopyContents;
        private global::System.Windows.Forms.ToolStripMenuItem contextMenuClearWindow;
        private global::System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll;
        private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private global::System.Windows.Forms.ToolStripMenuItem contextMenuSaveContents;
        private global::System.Windows.Forms.ToolStripMenuItem contextMenuLimitBufferLength;
        private global::System.Windows.Forms.ToolStripMenuItem contextMenuAddTimestamps;
    }
}
