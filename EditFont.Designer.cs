namespace Type_Writer
{
    partial class EditFont
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFont));
            this.CBfontSize = new System.Windows.Forms.ComboBox();
            this.CBfontStyle = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CBfontSize
            // 
            this.CBfontSize.FormattingEnabled = true;
            this.CBfontSize.Location = new System.Drawing.Point(159, 12);
            this.CBfontSize.Name = "CBfontSize";
            this.CBfontSize.Size = new System.Drawing.Size(72, 21);
            this.CBfontSize.TabIndex = 0;
            // 
            // CBfontStyle
            // 
            this.CBfontStyle.FormattingEnabled = true;
            this.CBfontStyle.Location = new System.Drawing.Point(12, 43);
            this.CBfontStyle.Name = "CBfontStyle";
            this.CBfontStyle.Size = new System.Drawing.Size(219, 21);
            this.CBfontStyle.TabIndex = 1;
            // 
            // EditaFont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(243, 73);
            this.Controls.Add(this.CBfontStyle);
            this.Controls.Add(this.CBfontSize);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditFont";
            this.Text = "Font";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CBfontSize;
        private System.Windows.Forms.ComboBox CBfontStyle;
    }
}