namespace xbWatson
{
	public partial class ConsoleConnectionManagerDialog : global::System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleConnectionManagerDialog));
            label1 = new System.Windows.Forms.Label();
            textBoxConsoleName = new System.Windows.Forms.TextBox();
            buttonAdd = new System.Windows.Forms.Button();
            buttonDefaults = new System.Windows.Forms.Button();
            buttonOK = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            checkedListBoxMachines = new System.Windows.Forms.CheckedListBox();
            buttonRemove = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // textBoxConsoleName
            // 
            resources.ApplyResources(textBoxConsoleName, "textBoxConsoleName");
            textBoxConsoleName.Name = "textBoxConsoleName";
            // 
            // buttonAdd
            // 
            resources.ApplyResources(buttonAdd, "buttonAdd");
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonDefaults
            // 
            resources.ApplyResources(buttonDefaults, "buttonDefaults");
            buttonDefaults.Name = "buttonDefaults";
            buttonDefaults.Click += buttonDefaults_Click;
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            // checkedListBoxMachines
            // 
            resources.ApplyResources(checkedListBoxMachines, "checkedListBoxMachines");
            checkedListBoxMachines.Name = "checkedListBoxMachines";
            checkedListBoxMachines.ItemCheck += checkedListBoxMachines_ItemCheck;
            // 
            // buttonRemove
            // 
            resources.ApplyResources(buttonRemove, "buttonRemove");
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Click += buttonRemove_Click;
            // 
            // ConsoleConnectionManagerDialog
            // 
            resources.ApplyResources(this, "$this");
            CancelButton = buttonCancel;
            Controls.Add(buttonRemove);
            Controls.Add(checkedListBoxMachines);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(buttonDefaults);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxConsoleName);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConsoleConnectionManagerDialog";
            ShowInTaskbar = false;
            ResumeLayout(false);
            PerformLayout();
        }

        private global::System.Windows.Forms.Label label1;
		private global::System.Windows.Forms.Button buttonAdd;
		private global::System.Windows.Forms.Button buttonDefaults;
		private global::System.Windows.Forms.Button buttonOK;
		private global::System.Windows.Forms.Button buttonCancel;
		private global::System.Windows.Forms.Button buttonRemove;
		private global::System.Windows.Forms.CheckedListBox checkedListBoxMachines;
		private global::System.Windows.Forms.TextBox textBoxConsoleName;
        private global::System.Resources.ResourceManager resources;
	}
}
