using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Type_Writer
{
    public partial class EditFont : Form
    {
        private static Type_Writer TypeWriter = new Type_Writer();
        private float fontSize = TypeWriter.GetFontSize();
        private FontFamily fontStyle = TypeWriter.GetFontStyle();

        public EditFont(FontFamily fontStyle, float fontSize)
        {
            InitializeComponent();
            this.Load += ConfigureComboBoxes;
            this.fontStyle = fontStyle;
            this.fontSize = fontSize;
        }

        private void ConfigureComboBoxes(object sender, EventArgs e)
        {
            for (int i = 8; i <= 72; i += 4)
            {
                CBfontSize.Items.Add(i);
            }

            CBfontSize.SelectedItem = (int)fontSize;

            InstalledFontCollection installedFonts = new InstalledFontCollection();
            FontFamily[] fontFamilies = installedFonts.Families;

            foreach (FontFamily fontFamily in fontFamilies)
            {
                CBfontStyle.Items.Add(fontFamily.Name);
            }

            CBfontStyle.SelectedItem = fontStyle.Name;
        }

        public Font NewFont()
        {
            string fontFamilyString = (string)CBfontStyle.SelectedItem;
            FontFamily fontFamily = new FontFamily(fontFamilyString);
            Font font = new Font(fontFamily, (int)CBfontSize.SelectedItem, FontStyle.Regular);
            return font;
        }
    }
}