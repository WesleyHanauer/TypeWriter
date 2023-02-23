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

namespace Bloco_de_notas
{
    public partial class EditarFonte : Form
    {
        private static Bloco_de_notas bloco = new Bloco_de_notas();
        private float tamanhoFonte = bloco.GetTamanhoFonte();
        private FontFamily estiloFonte = bloco.GetEstiloFonte();

        public EditarFonte(FontFamily estiloFonte, float tamanhoFonte)
        {
            InitializeComponent();

            this.Load += InicializarComponentes;
            this.estiloFonte = estiloFonte;
            this.tamanhoFonte = tamanhoFonte;
        }

        private void InicializarComponentes(object sender, EventArgs e)
        {
            for (int i = 8; i <= 72; i += 4)
            {
                CBtamanhoFonte.Items.Add(i);
            }

            CBtamanhoFonte.SelectedItem = (int)tamanhoFonte;

            InstalledFontCollection fontesInstaladas = new InstalledFontCollection();
            FontFamily[] fontFamilies = fontesInstaladas.Families;

            foreach (FontFamily fontFamily in fontFamilies)
            {
                CBestiloFonte.Items.Add(fontFamily.Name);
            }

            CBestiloFonte.SelectedItem = estiloFonte.Name;
        }

        public Font NovaFonte()
        {
            string fontFamilyString = (string)CBestiloFonte.SelectedItem;
            FontFamily fontFamily = new FontFamily(fontFamilyString);
            Font fonte = new Font(fontFamily, (int)CBtamanhoFonte.SelectedItem, FontStyle.Regular);
            return fonte;
        }
    }
}
