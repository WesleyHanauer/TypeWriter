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
using Bloco_de_notas.Properties;
using System.Runtime;

namespace Bloco_de_notas
{
    public partial class Bloco_de_notas : Form
    {
        private string texto;
        private string caminho;
        bool salvo = false;
        Font estiloFonteSalva = Settings.Default.fonteEstilo;

        public Bloco_de_notas()
        {
            InitializeComponent();
            this.FormClosing += ConfirmarSaida;
            this.Load += carregarBlocoDeNotas;
        }

        public float GetTamanhoFonte()
        {
            return txtTexto.Font.Size;
        }

        public FontFamily GetEstiloFonte()
        {
            return txtTexto.Font.FontFamily;
        }

        private void carregarBlocoDeNotas(object sender, EventArgs e)
        {
            txtTexto.Font = Settings.Default.fonteEstilo;
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                caminho = args[1];
                string textoAberto = File.ReadAllText(caminho);
                txtTexto.Text = textoAberto;
                txtTexto.SelectionStart = 0;
                txtTexto.SelectionLength = 0;
                salvo = true;
            }
        }

        private void Salvar()
        {
            SaveFileDialog salvarArquivo = new SaveFileDialog();
            salvarArquivo.Filter = "Text Files (*.txt)|*.txt";
            salvarArquivo.FilterIndex = 0;
            salvarArquivo.RestoreDirectory = true;

            if (salvarArquivo.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter escritor = new StreamWriter(salvarArquivo.FileName))
                {
                    caminho = salvarArquivo.FileName;
                    escritor.WriteLine(txtTexto.Text);
                }
            }
            salvo = true;
        }

        private void SalvarEVT(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(caminho))
            {
                Salvar();
            }
            else
            {
                texto = txtTexto.Text;
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                File.WriteAllBytes(caminho, bytes);
                salvo = true;
            }
        }

        private void AbrirEVT(object sender, EventArgs e)
        {
            OpenFileDialog abrirArquivo = new OpenFileDialog();
            abrirArquivo.FilterIndex = 0;
            abrirArquivo.RestoreDirectory = true;
            if (abrirArquivo.ShowDialog() == DialogResult.OK)
            {
                caminho = abrirArquivo.FileName;
                string textoAberto = File.ReadAllText(caminho);
                txtTexto.Text = textoAberto;
            }
        }

        private void SalvarComoEVT(object sender, EventArgs e)
        {
            Salvar();
        }

        private void EditarFonteEVT(object sender, EventArgs e)
        {
            EditarFonte editarFonteForm = new EditarFonte(txtTexto.Font.FontFamily, txtTexto.Font.Size);
            editarFonteForm.ShowDialog();
            txtTexto.Font = editarFonteForm.NovaFonte();
        }

        private void ConfirmarSaida(object sender, FormClosingEventArgs e)
        {
            Settings.Default.fonteEstilo = txtTexto.Font;
            Settings.Default.Save();
            if (salvo == false)
            {
                DialogResult ConfirmarSaida = MessageBox.Show("Salvar antes de sair?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (ConfirmarSaida == DialogResult.No)
                {
                    e.Cancel = false;
                }
                else if(ConfirmarSaida == DialogResult.Yes)
                {
                    SalvarEVT(sender, e);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void DesvalidarBoolSalvo(object sender, EventArgs e)
        {
            salvo = false;
        }
    }
}