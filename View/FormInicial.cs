using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramaAurora
{
    public partial class FormInicial : Form
    {
        public FormInicial()
        {
            InitializeComponent();
        }

        private void jogarComDadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJogarDado formJogarDado = new FormJogarDado();
            formJogarDado.MdiParent = this;
            formJogarDado.Show();
        }

        private void jogarComMaquinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJogarComMaquina formJogarComMaquina = new FormJogarComMaquina();
            formJogarComMaquina.MdiParent = this;
            formJogarComMaquina.Show();
        }
    }
}
