using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Type_Writer.Properties;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Type_Writer
{
    public partial class Type_Writer : Form
    {
        private string text;
        private string filePath;
        bool isSaved = false;

        public Type_Writer()
        {
            InitializeComponent();
            this.Load += LoadMainForm;
            this.Load += LoadFont;
            this.Load += LoadWindowPositionAndSize;
            this.FormClosing += ConfirmExit;
            this.FormClosing += SaveNewFont;
            this.FormClosing += SaveWindowPositionAndSize;
            txtText.KeyDown += SaveFileShortcut;
            txtText.KeyDown += SaveFileAsShortcut;
            txtText.KeyDown += OpenFileShortcut;
        }

        private void SaveFileShortcut(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Save_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void SaveFileAsShortcut(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.S)
            {
                SaveAs_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void OpenFileShortcut(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.O)
            {
                Open_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void LoadMainForm(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                filePath = args[1];
                string openedText = File.ReadAllText(filePath);
                txtText.Text = openedText;
                txtText.SelectionStart = 0;
                txtText.SelectionLength = 0;
                isSaved = true;
            }
            UpdateFormsNameOnChange(isSaved);
        }

        private void ConfirmExit(object sender, FormClosingEventArgs e)
        {
            if (isSaved == false)
            {
                DialogResult ConfirmExit = MessageBox.Show("Save before exiting?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (ConfirmExit == DialogResult.No)
                {
                    e.Cancel = false;
                }
                else if (ConfirmExit == DialogResult.Yes)
                {
                    Save_Click(sender, e);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void SaveWindowPositionAndSize(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.windowPos = this.Location;
            Properties.Settings.Default.windowSize = this.Size;
            Properties.Settings.Default.Save();
        }


        private void LoadWindowPositionAndSize(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.windowPos != null)
            {
                this.Location = Properties.Settings.Default.windowPos;
            }

            if (Properties.Settings.Default.windowSize != null)
            {
                this.Size = Properties.Settings.Default.windowSize;
            }
        }

        private void LoadFont(object sender, EventArgs e)
        {
            txtText.Font = Settings.Default.fontStyle;
        }

        private void SaveNewFont(object sender, FormClosingEventArgs e)
        {
            Settings.Default.fontStyle = txtText.Font;
            Settings.Default.Save();
        }

        public float GetFontSize()
        {
            return txtText.Font.Size;
        }

        public FontFamily GetFontStyle()
        {
            return txtText.Font.FontFamily;
        }

        private void Save()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Files (*.txt)|*.txt";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writter = new StreamWriter(saveFile.FileName))
                {
                    filePath = saveFile.FileName;
                    writter.WriteLine(txtText.Text);
                }
            }
            isSaved = true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Save();
            }
            else
            {
                text = txtText.Text;
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                File.WriteAllBytes(filePath, bytes);
                isSaved = true;
            }
            UpdateFormsNameOnChange(isSaved);
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpener = new OpenFileDialog();
            fileOpener.FilterIndex = 0;
            fileOpener.RestoreDirectory = true;
            if (fileOpener.ShowDialog() == DialogResult.OK)
            {
                filePath = fileOpener.FileName;
                string openedText = File.ReadAllText(filePath);
                txtText.Text = openedText;
                isSaved = true;
            }
            UpdateFormsNameOnChange(isSaved);
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            Save();
            UpdateFormsNameOnChange(isSaved);
        }

        private void EditFont_Click(object sender, EventArgs e)
        {
            EditFont editFontForm = new EditFont(txtText.Font.FontFamily, txtText.Font.Size);
            editFontForm.ShowDialog();
            txtText.Font = editFontForm.NewFont();
        }

        private void InvalidateIsSavedBoolean(object sender, EventArgs e)
        {
            isSaved = false;
            UpdateFormsNameOnChange(isSaved);
        }

        private string UpdateFormsNameOnChange(bool IsSaved)
        {
            if (IsSaved == false)
            {
                return this.Text = "TypeWriter *";
            }
            return this.Text = "TypeWriter";
        }
    }
}