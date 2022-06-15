using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Pratica5 {
    public partial class FormOrdenacao : Form {
        int[] vet = new int[500]; // vetor interno para a animação

        public FormOrdenacao() {
            InitializeComponent();
            panel.Paint += new PaintEventHandler(panel_Paint);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel, new object[] { true });
        }

        private void panel_Paint(object sender, PaintEventArgs e) {
            for (int i = 0; i < vet.Length; i++) {
                e.Graphics.DrawLine(Pens.Brown, i, 299, i, 299 - vet[i]);
            }
        }

        private void bolhaToolStripMenuItem_Click(object sender, EventArgs e) {
            
        }

        // TODO: animação e estatísticas dos demais métodos de ordenação

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(this, 
                "Prática 5 2022/1 - Métodos de Ordenação\n\n" +
                "Desenvolvido por:\n72200790 - João Vitor de Oliveira Mendes\n" +
                "Prof. Virgílio Borges de Oliveira\n\n" +
                "Algoritmos e Estruturas de Dados\n" +
                "Faculdade COTEMIG\n" +
                "Apenas para fins didáticos.", 
                "", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void iniciaAnimacao(Action a, int ordem) {
            if (bgw.IsBusy != true) {
                switch (ordem)
                {
                    case 1:
                        Preenchimento.Aleatorio(vet, 300);
                        break;
                    case 2:
                        Preenchimento.Crescente(vet, 300);
                        break;
                    case 3:
                        Preenchimento.Decrescente(vet, 300);
                        break;
                }
                bgw.RunWorkerAsync(a);
            }
            else {
                MessageBox.Show(this,
                   "Aguarde o fim da execução atual...",
                   "Prática 5 2022/1 - Métodos de Ordenação",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
            }
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e) {
            Action a = (Action)e.Argument;
            a();
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            MessageBox.Show(this,
               "Animação concluída!",
               "Prática 5 2022/1 - Métodos de Ordenação",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        private void bolhaToolStripMenuItem1_Click_1(object sender, EventArgs e) {
            
            
        }

        private void crescenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Bolha(vet, panel), 2);
        }

        private void decrescenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Bolha(vet, panel), 3);
        }

        private void aleatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Bolha(vet, panel), 1);
        }

        private void aleatorioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.selecao(vet, panel), 1);
        }

        private void crescenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.selecao(vet, panel), 2);
        }

        private void decrescenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.selecao(vet, panel), 3);
        }

        private void aleatorioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.insercao(vet, panel), 1);
        }

        private void crescenteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.insercao(vet, panel), 2);
        }

        private void decrescenteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.insercao(vet, panel), 3);
        }

        private void aleatorioToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.shellSort(vet, panel), 1);
        }

        private void crescenteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.shellSort(vet, panel), 2);
        }

        private void decrescenteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.shellSort(vet, panel), 3);
        }

        private void aleatorioToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.heapSort(vet, panel), 1);
        }

        private void crescenteToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.heapSort(vet, panel), 2);
        }

        private void decrescenteToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.heapSort(vet, panel), 3);
        }

        private void aleatorioToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.quickSort(vet, 0, vet.Length - 1, panel), 1);
        }

        private void crescenteToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.quickSort(vet, 0, vet.Length - 1, panel), 2);
        }

        private void decrescenteToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.quickSort(vet, 0, vet.Length - 1, panel), 3);
        }

        private void aleatorioToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.mergeSort(vet, 0, vet.Length - 1, panel), 1);
        }

        private void crescenteToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.mergeSort(vet, 0, vet.Length - 1, panel), 2);
        }

        private void decrescenteToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.mergeSort(vet, 0, vet.Length - 1, panel), 3);
        }

        private void aleatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Aleatorio(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.Bolha(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Aleatório" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método Bolha",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void crescenteToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Crescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.Bolha(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Crescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método Bolha",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void decrscenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Decrescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.Bolha(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Decrescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método Bolha",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void aleatórioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Aleatorio(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.selecao(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Aleatório" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método Seleção",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void crescenteToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Crescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.selecao(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Crescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método Seleção",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void decrescenteToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Decrescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.selecao(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Decrescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método Seleção",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void aleatórioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Aleatorio(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.insercao(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Aleatorio" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método Inserção",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void crescenteToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Crescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.insercao(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Crescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método Inserção",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void decrescenteToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Decrescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.insercao(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Decrescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método Inserção",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void aleatórioToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Aleatorio(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.shellSort(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Aleatorio" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método Seleção",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void crescenteToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Crescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.shellSort(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Crescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método Seleção",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void decrescenteToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Decrescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.shellSort(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Decrescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método Seleção",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void aleatórioToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Aleatorio(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.heapSort(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Aleatorio" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método HeapSort",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void crescenteToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Crescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.heapSort(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Crescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método HeapSort",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void decrescenteToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Decrescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.heapSort(vetor);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Decrescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método HeapSort",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void aleatórioToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Aleatorio(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.quickSort(vetor, 0, vetor.Length -1);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Aleatorio" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método QuickSort",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void crescenteToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Crescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.quickSort(vetor, 0, vetor.Length - 1);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Crescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método QuickSort",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void decrescenteToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Decrescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.quickSort(vetor, 0, vetor.Length - 1);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Decrescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método QuickSort",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void aleatórioToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Aleatorio(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.mergeSort(vetor, 0, vetor.Length - 1);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Aleatorio" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método MergeSort",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void crescenteToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            OrdenacaoEstatistica.cont_c = 0;
            OrdenacaoEstatistica.cont_t = 0;
            try
            {
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Crescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.mergeSort(vetor, 0, vetor.Length - 1);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Crescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método MergeSort",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }

        private void decrescenteToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            try
            {
                OrdenacaoEstatistica.cont_c = 0;
                OrdenacaoEstatistica.cont_t = 0;
                int[] vetor = new int[int.Parse(textBox1.Text)];
                Preenchimento.Decrescente(vetor, 1000);
                var stopwatch = new Stopwatch();
                stopwatch.Start(); // inicia cronômetro
                OrdenacaoEstatistica.mergeSort(vetor, 0, vetor.Length - 1);
                stopwatch.Stop(); // interrompe cronômetro
                long elapsed_time = stopwatch.ElapsedMilliseconds;
                MessageBox.Show(this,
                      "Tamanho do vetor: " + vetLengthTxt.Text +
                      "\nOrdenação inicial: Decrescente" +
                      "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                      "\nNº de comparações: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_c) +
                      "\nNº de trocas: " + String.Format("{0:n0}", OrdenacaoEstatistica.cont_t),
                      "Estatísticas do Método MergeSort",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor digite um Tamanho do Vetor válido", "AVISO", MessageBoxButtons.OK);
            }
        }
    }
}
