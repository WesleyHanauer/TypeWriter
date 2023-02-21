namespace Bloco_de_notas
{
    partial class EditarFonte
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
            this.CBtamanhoFonte = new System.Windows.Forms.ComboBox();
            this.CBestiloFonte = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CBtamanhoFonte
            // 
            this.CBtamanhoFonte.FormattingEnabled = true;
            this.CBtamanhoFonte.Location = new System.Drawing.Point(159, 12);
            this.CBtamanhoFonte.Name = "CBtamanhoFonte";
            this.CBtamanhoFonte.Size = new System.Drawing.Size(72, 21);
            this.CBtamanhoFonte.TabIndex = 0;
            // 
            // CBestiloFonte
            // 
            this.CBestiloFonte.FormattingEnabled = true;
            this.CBestiloFonte.Location = new System.Drawing.Point(12, 43);
            this.CBestiloFonte.Name = "CBestiloFonte";
            this.CBestiloFonte.Size = new System.Drawing.Size(219, 21);
            this.CBestiloFonte.TabIndex = 1;
            // 
            // editarFonte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(243, 73);
            this.Controls.Add(this.CBestiloFonte);
            this.Controls.Add(this.CBtamanhoFonte);
            this.Name = "editarFonte";
            this.Text = "Fonte";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CBtamanhoFonte;
        private System.Windows.Forms.ComboBox CBestiloFonte;
    }
}