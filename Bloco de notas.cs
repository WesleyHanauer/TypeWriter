﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bloco_de_notas
{
    public partial class Bloco_de_notas : Form
    {
        private string texto;
        private string caminho;

        public Bloco_de_notas()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void salvar()
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
        }

        private void salvarEVT(object sender, EventArgs e)
        {
            if (caminho == null)
            {
                salvar();
            }
            else {
                texto = txtTexto.Text;
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(texto);
                File.WriteAllBytes(caminho, bytes);
            }
        }

        private void abrirEVT(object sender, EventArgs e)
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

        private void salvarComoEVT(object sender, EventArgs e)
        {
            salvar();
        }
    }
}