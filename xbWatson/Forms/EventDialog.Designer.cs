namespace xbWatson.Forms
{
    public partial class EventDialog : global::System.Windows.Forms.Form
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventDialog));
            rebootButton = new System.Windows.Forms.Button();
            messageLabel = new System.Windows.Forms.Label();
            middleButton = new System.Windows.Forms.Button();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            continueButton = new System.Windows.Forms.Button();
            pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // rebootButton
            // 
            rebootButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            rebootButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            rebootButton.Location = new System.Drawing.Point(78, 235);
            rebootButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rebootButton.Name = "rebootButton";
            rebootButton.Size = new System.Drawing.Size(140, 28);
            rebootButton.TabIndex = 11;
            rebootButton.Text = "Reboot Xbox";
            // 
            // messageLabel
            // 
            messageLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            messageLabel.Location = new System.Drawing.Point(80, 23);
            messageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new System.Drawing.Size(485, 185);
            messageLabel.TabIndex = 10;
            // 
            // middleButton
            // 
            middleButton.DialogResult = System.Windows.Forms.DialogResult.No;
            middleButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            middleButton.Location = new System.Drawing.Point(225, 235);
            middleButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            middleButton.Name = "middleButton";
            middleButton.Size = new System.Drawing.Size(140, 28);
            middleButton.TabIndex = 8;
            middleButton.Text = "Save Dump";
            // 
            // continueButton
            // 
            continueButton.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            continueButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            continueButton.Location = new System.Drawing.Point(372, 235);
            continueButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            continueButton.Name = "continueButton";
            continueButton.Size = new System.Drawing.Size(140, 28);
            continueButton.TabIndex = 9;
            continueButton.Text = "Continue";
            continueButton.Click += button_Click;
            // 
            // pictureBox
            // 
            pictureBox.Image = (System.Drawing.Image)resources.GetObject("pictureBox.Image");
            pictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            pictureBox.Location = new System.Drawing.Point(24, 23);
            pictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(37, 55);
            pictureBox.TabIndex = 12;
            pictureBox.TabStop = false;
            // 
            // EventDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = continueButton;
            ClientSize = new System.Drawing.Size(590, 295);
            Controls.Add(pictureBox);
            Controls.Add(rebootButton);
            Controls.Add(messageLabel);
            Controls.Add(middleButton);
            Controls.Add(continueButton);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EventDialog";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        private global::System.ComponentModel.IContainer components;

        private global::System.Windows.Forms.Button rebootButton;

        private global::System.Windows.Forms.Label messageLabel;

        private global::System.Windows.Forms.Button middleButton;

        private global::System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

        private global::System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}
