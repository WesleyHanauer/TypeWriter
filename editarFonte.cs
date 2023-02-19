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
    public partial class editarFonte : Form
    {
        private static Bloco_de_notas bloco = new Bloco_de_notas();
        private float tamanhoFonte = bloco.getTamanhoFonte();
        private FontFamily estiloFonte = bloco.getEstiloFonte();

        public editarFonte(FontFamily estiloFonte, float tamanhoFonte)
        {
            InitializeComponent();

            this.estiloFonte = estiloFonte;
            this.tamanhoFonte = tamanhoFonte;

            //Adiciona as opções de fonte e tamanhos ao COMBO BOX e mostra a fonte e tamanho atual quando o form inicializa.

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


        public Font novaFonte()
        {
            string fontFamilyString = (string)CBestiloFonte.SelectedItem;
            FontFamily fontFamily = new FontFamily(fontFamilyString);
            Font fonte = new Font(fontFamily, (int)CBtamanhoFonte.SelectedItem, FontStyle.Regular);
            return fonte;
        }
    }
}
