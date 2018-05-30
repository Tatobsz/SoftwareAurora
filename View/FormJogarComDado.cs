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
    public partial class FormJogarDado : Form
    {
        public FormJogarDado()
        {
            InitializeComponent();
        }

        Dado Dado = new Dado();
        Categoria categoria = new Categoria();
        ErrorProvider erro = new ErrorProvider();

        public bool ValidarCamposSeExiste()
        {
            bool valido = true;

            if (int.Parse(txtDado1.Text) > 6 || int.Parse(txtDado1.Text) < 1)
            {
                valido = false;
                erro.SetError(txtDado1, "Insira um valor entre 1 e 6");
            }

            if (int.Parse(txtDado2.Text) > 6 || int.Parse(txtDado2.Text) < 1)
            {
                valido = false;
                erro.SetError(txtDado2, "Insira um valor entre 1 e 6");
            }

            if (int.Parse(txtDado3.Text) > 6 || int.Parse(txtDado3.Text) < 1)
            {
                valido = false;

                erro.SetError(txtDado3, "Insira um valor entre 1 e 6");
            }

            if (int.Parse(txtDado4.Text) > 6 || int.Parse(txtDado4.Text) < 1)
            {
                valido = false;
                erro.SetError(txtDado4, "Insira um valor entre 1 e 6");
            }

            if (int.Parse(txtDado5.Text) > 6 || int.Parse(txtDado5.Text) < 1)
            {
                valido = false;
                erro.SetError(txtDado5, "Insira um valor entre 1 e 6");
            }

            return valido;
        }

        public bool ValidarCamposSePreenchido()
        {
            bool valido = true;

            if (txtDado1.Text == "")
            {
                valido = false;
                erro.SetError(txtDado1, "O campo deve ser preenchido");
            }

            if (txtDado2.Text == "")
            {
                valido = false;
                erro.SetError(txtDado2, "O campo deve ser preenchido");
            }

            if (txtDado3.Text == "")
            {
                valido = false;

                erro.SetError(txtDado3, "O campo deve ser preenchido");
            }

            if (txtDado4.Text == "")
            {
                valido = false;
                erro.SetError(txtDado4, "O campo deve ser preenchido");
            }

            if (txtDado5.Text == "")
            {
                valido = false;
                erro.SetError(txtDado5, "O campo deve ser preenchido");
            }

            return valido;
        }

        private bool ValidarSeNumero()
        {
            bool valido = true;
            int testador;
            bool[]numeroInteiro = new bool[5];

            numeroInteiro[0] = int.TryParse(txtDado1.Text, out testador);
            numeroInteiro[1] = int.TryParse(txtDado2.Text, out testador);
            numeroInteiro[2] = int.TryParse(txtDado3.Text, out testador);
            numeroInteiro[3] = int.TryParse(txtDado4.Text, out testador);
            numeroInteiro[4] = int.TryParse(txtDado5.Text, out testador);

            if (!numeroInteiro[0])
            {
                valido = false;
                erro.SetError(txtDado1, "O campo aceita apenas números");
            }

            if (!numeroInteiro[1])
            {
                valido = false;
                erro.SetError(txtDado2, "O campo aceita apenas números");
            }

            if (!numeroInteiro[2])
            {
                valido = false;
                erro.SetError(txtDado3, "O campo aceita apenas números");
            }

            if (!numeroInteiro[3])
            {
                valido = false;
                erro.SetError(txtDado4, "O campo aceita apenas números");
            }
            
              if (!numeroInteiro[4])
            {
                valido = false;
                erro.SetError(txtDado5, "O campo aceita apenas números");
            }

            return valido;
        }

        public void LimparMenssagemErro()
        {
            erro.SetError(txtDado1, "");
            erro.SetError(txtDado2, "");
            erro.SetError(txtDado3, "");
            erro.SetError(txtDado4, "");
            erro.SetError(txtDado5, "");
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            Dado Dado = new Dado();

            lblResposta.Text = "";
            lblResposta.Visible = false;

            //categoria.testar(Dado);
            LimparMenssagemErro();

            if (ValidarCamposSePreenchido())
            {
                if(ValidarSeNumero())
                {
                    if (ValidarCamposSeExiste())
                    {
                        Dado.Faces[0] = int.Parse(txtDado1.Text);
                        Dado.Faces[1] = int.Parse(txtDado2.Text);
                        Dado.Faces[2] = int.Parse(txtDado3.Text);
                        Dado.Faces[3] = int.Parse(txtDado4.Text);
                        Dado.Faces[4] = int.Parse(txtDado5.Text);

                        Dado.FaceSequencia[0] = int.Parse(txtDado1.Text);
                        Dado.FaceSequencia[1] = int.Parse(txtDado2.Text);
                        Dado.FaceSequencia[2] = int.Parse(txtDado3.Text);
                        Dado.FaceSequencia[3] = int.Parse(txtDado4.Text);
                        Dado.FaceSequencia[4] = int.Parse(txtDado5.Text);


                        lblResposta.Text = "Indicamos que você use a categoria {0}, com {1} pontos";
                        lblResposta.Text = string.Format(lblResposta.Text, categoria.Jogada(Dado), categoria.pontosTotal);
                        lblResposta.Visible = true;
                    }
                }
            }
        }
    }
}