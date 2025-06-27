namespace xbWatson
{
	public partial class DumpLocationDialog : global::System.Windows.Forms.Form
	{
		private global::System.ComponentModel.Container components;
		protected override void Dispose(bool disposing)
		{
			this.resources.ReleaseAllResources();
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DumpLocationDialog));
            label1 = new System.Windows.Forms.Label();
            textBoxPath = new System.Windows.Forms.TextBox();
            buttonOK = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            buttonPath = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // textBoxPath
            // 
            resources.ApplyResources(textBoxPath, "textBoxPath");
            textBoxPath.Name = "textBoxPath";
            // 
            // buttonOK
            // 
            resources.ApplyResources(buttonOK, "buttonOK");
            buttonOK.Name = "buttonOK";
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(buttonCancel, "buttonCancel");
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonPath
            // 
            resources.ApplyResources(buttonPath, "buttonPath");
            buttonPath.Name = "buttonPath";
            buttonPath.Click += buttonPath_Click;
            // 
            // DumpLocationDialog
            // 
            resources.ApplyResources(this, "$this");
            CancelButton = buttonCancel;
            Controls.Add(buttonPath);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(textBoxPath);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DumpLocationDialog";
            ShowInTaskbar = false;
            ResumeLayout(false);
            PerformLayout();
        }

        private global::System.Windows.Forms.Label label1;
		private global::System.Windows.Forms.Button buttonOK;
		private global::System.Windows.Forms.Button buttonCancel;
		private global::System.Windows.Forms.TextBox textBoxPath;
		private global::System.Windows.Forms.Button buttonPath;
        private global::System.Resources.ResourceManager resources;
	}
}
