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
    public partial class FormJogarComMaquina : Form
    {
        public FormJogarComMaquina()
        {
            InitializeComponent();
        }

        Categoria categoria = new Categoria();

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            Dado Dado = new Dado();

            label1.Text = Convert.ToString(Dado.RodarDados());
            label2.Text = Convert.ToString(Dado.RodarDados());
            label3.Text = Convert.ToString(Dado.RodarDados());
            label4.Text = Convert.ToString(Dado.RodarDados());
            label5.Text = Convert.ToString(Dado.RodarDados());

            Dado.Faces[0] = int.Parse(label1.Text);
            Dado.Faces[1] = int.Parse(label2.Text);
            Dado.Faces[2] = int.Parse(label3.Text);
            Dado.Faces[3] = int.Parse(label4.Text);
            Dado.Faces[4] = int.Parse(label5.Text);

            Dado.FaceSequencia[0] = int.Parse(label1.Text);
            Dado.FaceSequencia[1] = int.Parse(label2.Text);
            Dado.FaceSequencia[2] = int.Parse(label3.Text);
            Dado.FaceSequencia[3] = int.Parse(label4.Text);
            Dado.FaceSequencia[4] = int.Parse(label5.Text);

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;

            lblResposta.Text = "Indicamos que você use a categoria {0}, com {1} pontos";
            lblResposta.Text = string.Format(lblResposta.Text, categoria.Jogada(Dado), categoria.pontosTotal);
            lblResposta.Visible = true;
        }
    }
}


        